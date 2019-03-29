using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab06StudentRegistration
{
    /// <summary>
    /// You do NOT need to touch this file, as everything is complete.
    /// You will need to complete the methods in the RegistrationDataAccess class
    /// to complete the lab
    /// </summary>
    class Lab06StudentRegistrationProgram
    {
        static void Main(string[] args)
        {
            // data for the Students table in the database

            Student[] students = new Student[]
           {
                new Student() {FirstName = "Svetlana", LastName = "Rostov", Major = 1},
                new Student() {FirstName = "Claire", LastName = "Bloome",  Major = 2},
                new Student() {FirstName = "Sven", LastName = "Baertschi", Major = 3},
                new Student() {FirstName = "Cesar", LastName = "Chavez", Major = 4},
                new Student() {FirstName = "Debra", LastName = "Pecora",  Major = 1},
                new Student() {FirstName = "Fadi", LastName = "Hadari", Major = 2},
                new Student() {FirstName = "Hanying", LastName = "Fen",  Major = 3},
                new Student() {FirstName = "Hugo", LastName = "Victor", Major = 1},
                new Student() {FirstName = "Lance", LastName = "Armstrong", Major = 3},
                new Student() {FirstName = "Terry", LastName = "Matthews", Major = 1},
                new Student() {FirstName = "Eugene", LastName = "Fei", Major = 4 },
                new Student() {FirstName = "Mark", LastName = "Zuckerberg", Major = 1 },
                new Student() {FirstName = "Simon", LastName = "Li", Major = 1 },
           };

            // departments data

            Department[] departments = new Department[]
            {
                new Department() { Name = "Computing Studies", Code = "CSIS", Id = 1 },
                new Department() { Name = "Accounting", Code = "ACCT", Id = 2 },
                new Department() { Name = "Marketing", Code = "MKTG", Id = 3 },
                new Department() { Name = "Finance", Code = "FINC", Id = 4 },
            };

            // You will use each array to populate the database
            // but you will need to query the database for each table
            // and return a list

            List<Student> studentList;
            List<Department> departmentList;

            // Create a new RegistrationDataAccess object
            // and then open the connection to the database

            RegistrationDataAccess registrationDB = new RegistrationDataAccess();
            registrationDB.OpenConnection();

            // make sure all of the tables are empty

            // registrationDB.TruncateData("Courses");
            registrationDB.TruncateData("Students");
            registrationDB.TruncateData("Departments");

            // Insert each student into the database

            foreach (Student s in students)
            {
                registrationDB.InsertStudent(s);
            }

            // Insert each department into the database

            foreach (Department d in departments)
            {
                registrationDB.InsertDepartment(d);
            }

            // now get the tables from the DB, and store the records in a List

            studentList = registrationDB.GetStudents();
            departmentList = registrationDB.GetDepartments();

            if(studentList == null || departmentList == null)
            {
                Console.WriteLine("No data for students or departments returned from DB");
                Console.ReadLine();
                return;
            }

            // output the student list

            Console.WriteLine("Students table data");

            foreach (Student s in studentList)
                Console.WriteLine(s);

            // output the department list, but make sure number of students registered
            //  is stored.

            foreach (Department d in departmentList)
            {
                registrationDB.GetNumberOfStudentsInMajor(d);
            }

            // EXTRA CREDIT: instead of the above iteration in C#, use a single SQL statement to count 
            // number of students
            // hint: use a join and group by
            //
            // EXTRA CREDIT: In ADDIITION to the above C#, use LINQ instead

            //departmentList = registrationDB.GetNumberOfStudentsInMajor();

            Console.WriteLine("\n---------------");
            Console.WriteLine("Departments table data");

            foreach (Department d in departmentList)
                Console.WriteLine(d);
            
            Console.ReadLine();

            registrationDB.CloseConnection();

        }
    }
    /// <summary>
    /// Holds student data, including major. Note
    ///     that major is the Department Id.
    /// </summary>
    public class Student
    {
        /// <summary>
        /// Student Id
        /// </summary>
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        /// <summary>
        /// Corresponds to Department Id
        /// </summary>
        public int Major { get; set; }

        public Student() { }

        /// <summary>
        /// Outputs student record in a single string
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            return $"#{Id} {FirstName} {LastName} Major: {Major}";
        }
    }

    /// <summary>
    /// Department data. Id is related to Student Major
    /// </summary>

    public class Department
    {
        /// <summary>
        /// Department Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Full department name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Short 4 letter code for department
        /// </summary>
        public string Code { get; set; }
        public int NumberOfStudents { get; set; }

        public Department() { }

        /// <summary>
        /// output department record to a single string
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            return $"#{Id} {Name} {Code} #Students: {NumberOfStudents}";
        }

    }
}
