using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrationApp
{
    // classes for initializing database tables
    //  not used for anything else!!

    // Student - corresponds to Students table records

    public class Student
    {
        public int StudentId { get; set; }
        public string StudentLastName { get; set; }
        public string StudentFirstName { get; set; }
        public string StudentMajor { get; set; }
    }

    // Department - corresponds to Departments table records

    public class Department
    {
        public string DepartmentId { get; set; }
        public string DepartmentName { get; set; }

    }

    // Course - corresponds to Courses table records

    public class Course
    {
        public int CourseId { get; set; } 
        public string CourseDepartmentId { get; set; }
        public string CourseName { get; set; }
    }

    // Registration - different from the Registration table, in that 
    //    there is a RegisteredCourse object that contains the CourseID.

    public class Registration
    {
        public int StudentId { get; set; }
        public Course RegisteredCourse { get; set; }
    }
}
