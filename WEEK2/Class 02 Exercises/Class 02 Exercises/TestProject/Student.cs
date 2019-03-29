using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    class Student
    {
        private string studentName;
        private int age;
        static int count = 0;
        static string school = "my school";

        // prop then double tab 
        public int MyAge { get; set; } = 30; 

        // Constructor, initialize variables 
        // new keyword make an object, not constructor 

        public Student(string studentName = "", int age = 21)
        {
            this.studentName = studentName;
            this.age = age;
            count++;
        }

        public string getStudentName()
        {
            return studentName; 
        }

        public int getCount()
        {
            return count;
        }

        // Utility method using static 
        public static string GetName(Student student)
        {
            return student.getStudentName();
        }
    }
}
