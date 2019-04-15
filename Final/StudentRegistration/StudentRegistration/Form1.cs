using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentRegistration
{
    public partial class Form1 : Form
    {
        StudentRegistrationModel context;
        public Form1()
        {
            InitializeComponent();

            context = new StudentRegistrationModel();
            
            // if exist, then delete and create again
            context.Database.Delete();
            context.Database.Create();

            addStudentBtn.Click += AddStudentBtn_Click;
            updateBtn.Click += UpdateBtn_Click;
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            //get selected data 
            // dataGridViewStudent.SelectedRows;
            List<Student> selectedStudents = new List<Student>();
            foreach(DataGridViewRow row in dataGridViewStudent.SelectedRows)
            {
                Console.WriteLine(row.Cells[0].Value);
                selectedStudents.Add(context.Students.Find(row.Cells[0].Value));
            }
            List<Cours> selectedCourses = new List<Cours>();
            foreach (DataGridViewRow row in dataGridViewCourse.SelectedRows)
            {
                Console.WriteLine(context.Courses.Find(row.Cells[0].Value, row.Cells[1].Value));
                selectedCourses.Add(context.Courses.Find(row.Cells[0].Value, row.Cells[1].Value));
            }

            foreach (Cours c in selectedCourses)
            {
                foreach (Student s in selectedStudents){
                    s.Courses.Add(c);
                }
            }   
               
            context.SaveChanges();
            updateRegistration();

            context.Database.Log = (s => Debug.Write("updated!!!!!!!!  " + s));
        }

        private void updateRegistration()
        {
            var studentRegistration = from student in context.Students
                                      from course in student.Courses
                                      orderby student.StudentFirstName
                                      select new StudentCourseRegistration
                                      {
                                          StudentID = student.StudentId,
                                          StudentFirstName = student.StudentFirstName,
                                          StudentLastName = student.StudentLastName,
                                          CourseID = course.CourseId,
                                          CourseName = course.CourseName,
                                          DepartmentName = course.Department.DepartmentName
                                      };

            dataGridViewRegistration.DataSource = studentRegistration.ToList();
            dataGridViewRegistration.Refresh();

        }

        private void AddStudentBtn_Click(object sender, EventArgs e)
        {
            // register student
            string firstName = firstNameTxt.Text;
            string lastName = lastNameTxt.Text;
            string depId = DepartmentList.SelectedItem.ToString();
            Console.WriteLine(depId);

            // create a new stduent obj 
            Student newStudent = new Student
            {
                StudentFirstName = firstName,
                StudentLastName = lastName,
                StudentMajor = depId
            };

            context.Students.Add(newStudent);
            context.SaveChanges();
            updateGridView();
        }

        private void updateGridView()
        {
            dataGridViewStudent.Refresh();          

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            seedData();
        }

        private void updateDepartment()
        {
            // DepartmentList
            var departmentIdList = (from department in context.Departments
                                    select department.DepartmentId).ToList();
            foreach (String did in departmentIdList)
                DepartmentList.Items.Add(did);
            
        }

        private void seedData()
        {
            // Seed student
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
            context.SaveChanges();
           
            List<Department> departments = new List<Department>()  {
                new Department { DepartmentId = "CSIS", DepartmentName = "Computing Studies" },
                new Department { DepartmentId = "ACCT", DepartmentName = "Accounting" },
                new Department { DepartmentId = "MKTG", DepartmentName = "Marketing" },
                new Department { DepartmentId = "FINC", DepartmentName = "Finance" },
            };

            context.Departments.AddRange(departments);
            context.SaveChanges();

            List<Cours> courses = new List<Cours>() {
                new Cours { CourseId = 101, CourseDepartmentId = "CSIS", CourseName = "Programming I"},
                new Cours { CourseId = 102, CourseDepartmentId = "CSIS", CourseName = "Programming II" },
                new Cours { CourseId = 103, CourseDepartmentId = "ACCT", CourseName = "Accounting I" },
                new Cours { CourseId = 104, CourseDepartmentId = "ACCT", CourseName = "Accounting II" },
                new Cours { CourseId = 105, CourseDepartmentId = "FINC", CourseName = "Corporate Finance" },
            };

            context.Courses.AddRange(courses);
            context.SaveChanges();

            context.Students.Load();
            context.Courses.Load();

            dataGridViewStudent.DataSource = context.Students.Local.ToBindingList();
            dataGridViewCourse.DataSource = context.Courses.Local.ToBindingList();


            Student myStudent = context.Students.FirstOrDefault(s => s.StudentFirstName.Equals("Svetlana"));
            context.Students.Remove(myStudent);
            context.SaveChanges();

            updateGridView();
            updateDepartment();
        }

        private class StudentCourseRegistration
        {
            [DisplayName("Student ID")]
            public int StudentID { get; set; }
            [DisplayName("Last Name")]
            public string StudentLastName { get; set; }
            [DisplayName("First Name")]
            public string StudentFirstName { get; set; }
            [DisplayName("Course ID")]
            public int CourseID { get; set; }
            [DisplayName("Course Name")]
            public string CourseName { get; set; }
            [DisplayName("Department")]
            public string DepartmentName { get; set; }

        }
    }

}
