using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    class Program
    {
        static void Main(string[] args)
        {
            // if Student is from MyStudent namespace, 
            // MyStudent.Student or using MyStudent then create an object 

            Student student1 = new Student("Jiweon", 23);
            Student student2 = new Student();

            student1.MyAge = 22; 

            Console.WriteLine(Student.GetName(student1));
            Console.WriteLine(Student.GetName(student2));

            Console.WriteLine(student1.getStudentName() + " " + student1.getCount());
            Console.ReadLine();
        }
    }
    
}
