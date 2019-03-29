using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentRegistrationConsoleApp.EF_Classes;
using System.Diagnostics;
using System.Data.Entity; // need this for Load methods
using static System.Console;

namespace StudentRegistrationConsoleApp
{
    class StudentRegistrationConsoleAppProgram
    {

        static StudentRegistrationEntities context = new StudentRegistrationEntities();

        static void Main(string[] args)
        {
            CreateRegistrationDataTables();
        }

        static private void CreateRegistrationDataTables()
        {
            // create db context and all dbset tables


            // enable database logging (sql statements) in output window

            context.Database.Log = s => Debug.Write(s); // a delegate that writes a message to output

            context.Database.Delete();
            context.Database.Create();


            WriteLine("Database tables have been cleared, check them in SQL Server Explorer then hit enter");
            ReadLine();

            // students data

            List<Student> students = new List<Student>()
            {
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

            // departments data

            List<Department> departments = new List<Department>()
            {
                new Department { DepartmentId = "CSIS", DepartmentName = "Computing Studies" },
                new Department { DepartmentId = "ACCT", DepartmentName = "Accounting" },
                new Department { DepartmentId = "MKTG", DepartmentName = "Marketing" },
                new Department { DepartmentId = "FINC", DepartmentName = "Finance" },
            };

            // courses data

            List<Course> courses = new List<Course>()
            {
                new Course { CourseId = 101, CourseDepartmentId = "CSIS", CourseName = "Programming I"},
                new Course { CourseId = 102, CourseDepartmentId = "CSIS", CourseName = "Programming II" },
                new Course { CourseId = 101, CourseDepartmentId = "ACCT", CourseName = "Accounting I" },
                new Course { CourseId = 102, CourseDepartmentId = "ACCT", CourseName = "Accounting II" },
                new Course { CourseId = 101, CourseDepartmentId = "FINC", CourseName = "Corporate Finance" },
            };

            // register students for a few courses

            students[0].Courses.Add(courses[0]);
            students[1].Courses.Add(courses[0]);
            students[0].Courses.Add(courses[1]);
            students[0].Courses.Add(courses[4]);

            // populate the database tables

            context.Students.AddRange(students);
            context.Departments.AddRange(departments);
            context.Courses.AddRange(courses);

            context.SaveChanges();

            // Let's look at all of the students who have registered for courses

            WriteLine("Students registered for courses");

            foreach (Student student in context.Students)
            {
                if (student.Courses.Count > 0)
                {
                    WriteLine(student);
                    WriteLine("Registered for:");
                    foreach (Course course in student.Courses)
                        WriteLine($"\t{course.CourseId} {course.CourseDepartmentId} {course.CourseName}");
                }
            }

            // now let's look at all of the courses offered by each department
            // notice how we didn't need to initialize these!

            WriteLine("Courses offered by Departments");
            foreach (Department department in context.Departments)
            {
                if (department.Courses.Count > 0)
                {
                    WriteLine($"{department.DepartmentId} {department.DepartmentName}");
                    foreach (Course course in department.Courses)
                        WriteLine($"\t{course.CourseId} {course.CourseName}");
                }
            }

            // let's look at all students with an accounting major
            // Examine the SQL output, and notice that a SELECT statement is generated for this

            WriteLine("All students with ACCT major");
            var studentsInAccounting =
                from student in context.Students
                where student.StudentMajor == "ACCT"
                select student;

            WriteLine($"Found {studentsInAccounting.Count()} students in {studentsInAccounting.First<Student>().StudentMajor}");

            foreach (Student student in studentsInAccounting)
                WriteLine(student);

            ReadLine();
        }

        /// <summary>
        /// Delete all student registration data, and make sure IDENTITY is reseeded
        /// </summary>
        static private void DeleteAllStudentRegistrationData()
        {
            // clear all the tables
            // load each into memory, clear the table, then sync back to db

            context.Students.Load();
            context.Departments.Load();
            context.Courses.Load();

            // reset so student ID numbering starts at 1
            // only reset if the table was previously empty

            if (context.Students.Count() > 0)
            {
                context.Database.ExecuteSqlCommand($"DBCC CHECKIDENT('[dbo].[Students]', RESEED, 0)");
                WriteLine("Identity seed on Students table reset");
            }

            // need to clear all registrations first due to constraints

            foreach (Student s in context.Students)
                s.Courses.Clear();
            context.SaveChanges();

            context.Courses.Local.Clear();
            context.Departments.Local.Clear();
            context.Students.Local.Clear();
            context.SaveChanges();
        }
    }
}
