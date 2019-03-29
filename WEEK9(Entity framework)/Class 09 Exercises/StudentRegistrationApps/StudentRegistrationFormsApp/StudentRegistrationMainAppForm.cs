using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StudentRegistrationFormsApp.EF_Classes;
using System.Diagnostics;
using System.Data.Entity; // need this for ToBindingList() and Load()
using System.Collections.ObjectModel;

namespace StudentRegistrationFormsApp
{
    public partial class FormStudentRegistration : Form
    {
        private StudentRegistrationEntities context; // save DB context here

        public FormStudentRegistration()
        {
            InitializeComponent();

            // set up the database

            context = new StudentRegistrationEntities();
            // set up database log to write to output window in VS

            context.Database.Log = s => Debug.Write(s);
            context.SaveChanges();

            // delete db if exists, then create

            context.Database.Delete();
            context.Database.Create();
        }

        /// <summary>
        /// Seed tables with data
        /// </summary>
        private void SeedRegistrationDataTables()
        {
            // seed student data into Students table

            List<Student> students = new List<Student>() {
                new Student { StudentFirstName = "Svetlana", StudentLastName = "Rostov", StudentMajor = "CSIS" },
                new Student { StudentFirstName = "Claire", StudentLastName = "Bloome", StudentMajor = "ACCT" },
                new Student { StudentFirstName = "Sven", StudentLastName = "Baertschi", StudentMajor = "MKTG" },
                new Student { StudentFirstName = "Cesar", StudentLastName = "Chavez", StudentMajor = "FINC" },
                new Student { StudentFirstName = "Debra", StudentLastName = "Manning", StudentMajor = "CSIS" },
                new Student { StudentFirstName = "Fadi", StudentLastName = "Hadari", StudentMajor = "ACCT" },
                new Student { StudentFirstName = "Hanyeng", StudentLastName = "Fen", StudentMajor = "MKTG" },
                new Student { StudentFirstName = "Hugo", StudentLastName = "Victor", StudentMajor = "FINC" },
                new Student { StudentFirstName = "Lance", StudentLastName = "Armstrong", StudentMajor = "MKTG" },
                new Student { StudentFirstName = "Terry", StudentLastName = "Matthews", StudentMajor = "CSIS" },
                new Student { StudentFirstName = "Eugene", StudentLastName = "Fei", StudentMajor = "FINC" },
                new Student { StudentFirstName = "Michael", StudentLastName = "Thorson", StudentMajor = "CSIS" },
                new Student { StudentFirstName = "Simon", StudentLastName = "Li", StudentMajor = "CSIS" },
            };

            context.Students.AddRange(students);

            // seed departments data

            List<Department> departments = new List<Department>()  {
                new Department { DepartmentId = "CSIS", DepartmentName = "Computing Studies" },
                new Department { DepartmentId = "ACCT", DepartmentName = "Accounting" },
                new Department { DepartmentId = "MKTG", DepartmentName = "Marketing" },
                new Department { DepartmentId = "FINC", DepartmentName = "Finance" },
            };

            context.Departments.AddRange(departments);

            // seed courses data

            List<Course> courses = new List<Course>() {
                new Course { CourseId = 101, CourseDepartmentId = "CSIS", CourseName = "Programming I"},
                new Course { CourseId = 102, CourseDepartmentId = "CSIS", CourseName = "Programming II" },
                new Course { CourseId = 101, CourseDepartmentId = "ACCT", CourseName = "Accounting I" },
                new Course { CourseId = 102, CourseDepartmentId = "ACCT", CourseName = "Accounting II" },
                new Course { CourseId = 101, CourseDepartmentId = "FINC", CourseName = "Corporate Finance" },
            };

            context.Courses.AddRange(courses);
            context.SaveChanges();

            // set up initial registration
            // note that we can add a student to a course or
            // add a course to a student, both will work and set up proper links

            courses[0].Students.Add(students[0]);
            courses[0].Students.Add(students[1]);
            courses[1].Students.Add(students[0]);
            courses[4].Students.Add(students[0]);

            students[2].Courses.Add(courses[2]);

            context.SaveChanges();

            // need Load() for BindingList, which allows the gridviews to be sorted/edited
            //  and sync'd to database

            context.Students.Load();
            context.Courses.Load();

            // show the Students and Courses tables

            dataGridViewStudents.DataSource = context.Students.Local.ToBindingList();
            dataGridViewCourses.DataSource = context.Courses.Local.ToBindingList();

            // set up registration gridview

            UpdateRegistration();
            context.SaveChanges();
        }

        /// <summary>
        /// Reset the database manually by clearing each table
        /// This method is not used, easier to delete and recreate db
        /// </summary>
        private void DeleteAllStudentRegistrationData()
        {
            // reset so student ID numbering starts at 1
            // only reset if the table was previously empty

            if (context.Students.Count() > 0)
                context.Database.ExecuteSqlCommand($"DBCC CHECKIDENT('[dbo].[Students]', RESEED, 0)");

            // zero out the database tables

            // first clear the list of students linked to courses

            foreach (Course c in context.Courses)
                c.Students.Clear();

            // now zero the courses and departments

            context.Courses.RemoveRange(context.Courses);
            context.Departments.RemoveRange(context.Departments);

            context.SaveChanges();

            // finally, zero the students 

            context.Students.RemoveRange(context.Students);

            context.SaveChanges();

        }
        // when the form loads, initialize the databse and seed all the forms

        private void FormStudentRegistration_Load(object sender, EventArgs e)
        {
            SeedRegistrationDataTables();
        }

        // sync any changes in the forms with the database

        private void ButtonUpdate_Click(object sender, EventArgs e)
        {
            context.SaveChanges();

            dataGridViewCourses.Refresh();
            dataGridViewStudents.Refresh();

            // need to update registration as well
            UpdateRegistration();
 
        }

        // update the registration gridview

        private void UpdateRegistration()
        {
            // Notice no need to use a join in EF, as the parent-child link exists
            //  so we can just walk from parent to child (Student to Courses)
            // If we use an anonymous class, the gridview can't be sorted or edited by the user
            // So we use StudentCourseRegistration and set the fields from the Students and Courses tables

            var studentRegistrations =
                 from student in context.Students
                 from studentreg in student.Courses
                 orderby student.StudentLastName
                 select new StudentCourseRegistration
                 {
                     StudentID = student.StudentId,
                     StudentLastName = student.StudentLastName,
                     CourseID = studentreg.CourseId,
                     Department = studentreg.CourseDepartmentId,
                     CourseName = studentreg.CourseName,
                 };

            // set gridview datasource to a List

            dataGridViewStudentRegistration.DataSource = studentRegistrations.ToList();

        }

        // Register students, and update the registration gridview 
        // user selects rows in Students and Courses gridviews
        // then we register all at once

        private void ButtonRegister_Click(object sender, EventArgs e)
        {
            // make sure rows have been selected in each gridview

            if (dataGridViewStudents.SelectedRows.Count == 0 ||
                dataGridViewCourses.SelectedRows.Count == 0)
                return;

            // get the selected students and keep in a list
            //  match selected StudentId

            List<Student> studentsToRegister = new List<Student>();
            foreach (DataGridViewRow row in dataGridViewStudents.SelectedRows)
                studentsToRegister.Add(context.Students.Find(row.Cells[0].Value));

            // same for courses, match against CourseId and DepartmentId (compound key)

            List<Course> coursesToRegister = new List<Course>();
            foreach (DataGridViewRow row in dataGridViewCourses.SelectedRows)
                coursesToRegister.Add(context.Courses.Find(row.Cells[0].Value, row.Cells[1].Value));

            // The nice thing about EF is that you could add to Course.Students or Student.Courses
            //   will do the latter
            // Note check to see if student is already registered.

            foreach (Course c in coursesToRegister)
                foreach (Student s in studentsToRegister)
                {
                    if (s.Courses.Contains(c))
                        MessageBox.Show($"Student Id {s.StudentId} already registered for {c.CourseName}");
                    else s.Courses.Add(c);
                }

            context.SaveChanges();
            UpdateRegistration();
        }

        // Used to populate the registration gridview
        //   gridview columns are in order of the fields below.
        //   note use of annotation for DisplayName which sets the column header text
        private class StudentCourseRegistration
        {
            [DisplayName("Student ID")]
            public int StudentID { get; set; }
            [DisplayName("Last Name")]
            public string StudentLastName { get; set; }
            [DisplayName("Course ID")]
            public int CourseID { get; set; }
            [DisplayName("Course Name")]
            public string CourseName { get; set; }
            [DisplayName("Department")]
            public string Department { get; set; }

        }

        // Really not necessary, but allows addition of a student using a separate form
        //   show the form as a dialog, and if the user hits Add, add the student to the database

        private void ButtonAddStudent_Click(object sender, EventArgs e)
        {
            AddStudentForm addStudentForm = new AddStudentForm();
 
            var result = addStudentForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                context.Students.Add(addStudentForm.GetStudent());
                context.SaveChanges();
            }

            addStudentForm.Close();
        }
    }
}
