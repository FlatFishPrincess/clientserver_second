using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
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

            List<Student> selectedStudentList = new List<Student>();
            foreach (DataGridViewRow row in dataGridViewStudent.SelectedRows)
            {
                Console.WriteLine(context.Students.Find(row.Cells[0].Value).StudentFirstName);
                selectedStudentList.Add(context.Students.Find(row.Cells[0].Value));
            }

            List<Cours> selectedCourseList = new List<Cours>();
            foreach (DataGridViewRow row in dataGridViewCourse.SelectedRows)
            {
                int courseID = int.Parse(row.Cells[0].Value.ToString());
                string departmentID = row.Cells[1].Value.ToString();
                Cours selectedCourse = context.Courses.Find(courseID, departmentID);
                Console.WriteLine(selectedCourse.CourseName);
                selectedCourseList.Add(selectedCourse);
                //Console.WriteLine(context.Courses.Find(row.Cells[0].Value));
            }

            foreach (Cours c in selectedCourseList)
            {
                foreach (Student s in selectedStudentList)
                    s.Courses.Add(c);
            }
               
            context.SaveChanges();

            var courseList = (from student in context.Students
                             from course in student.Courses
                              select course.CourseName + " " + student.StudentFirstName).ToList();
            foreach(String s in courseList)
            {
                Console.WriteLine(s.ToString());
            }
            
            updateRegistration();
        }

        private void updateRegistration()
        {
            
            // dataGridViewRegistration
            var studentRegistration = from student in context.Students
                                      from course in student.Courses
                                      orderby student.StudentId
                                      select new StudentCourseRegistration
                                      {
                                          StudentID = student.StudentId,
                                          StudentFirstName = student.StudentFirstName,
                                          StudentLastName = student.StudentLastName,
                                          DepartmentName = course.Department.DepartmentName,
                                          CourseID = course.CourseId,
                                          CourseName = course.CourseName
                                      };
            dataGridViewRegistration.DataSource = studentRegistration.ToList();
            dataGridViewRegistration.Refresh(); 
        }

        private void AddStudentBtn_Click(object sender, EventArgs e)
        {
            // register student
            string firstName = firstNameTxt.Text.ToString();
            string lastName = lastNameTxt.Text.ToString();
            string departmentId = DepartmentList.SelectedItem.ToString();

            Student newStudent = new Student
            {
                StudentFirstName = firstName,
                StudentLastName = lastName,
                StudentMajor = departmentId
            };
            context.Students.Add(newStudent);
            context.SaveChanges();
            updateGridView();
        }

        private void updateGridView()
        {

            // upgdate student gridview 
            dataGridViewStudent.Refresh();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            seedData();
        }

        private void updateDepartment()
        {
            // DepartmentList
            var departmentList = from department in context.Departments
                                 select department.DepartmentId;
            foreach(String s in departmentList)
            {
                DepartmentList.Items.Add(s);
            }
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
