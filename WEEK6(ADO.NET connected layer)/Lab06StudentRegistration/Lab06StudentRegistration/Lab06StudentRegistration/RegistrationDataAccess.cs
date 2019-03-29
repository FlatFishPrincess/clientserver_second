using System.Collections.Generic;
using System.Data.SqlClient;

namespace Lab06StudentRegistration
{
    public class RegistrationDataAccess
    {
        private SqlConnection registrationDBConnection = null;

        /// <summary>
        /// Open a connection to the student registration database.
        /// Uses a private SqlConnection object.
        /// </summary>
        public void OpenConnection()
        {
            registrationDBConnection = new SqlConnection()
            {
                ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Integrated Security=SSPI;" +
                "Initial Catalog=StudentRegistration"
            };
            registrationDBConnection.Open();
        }

        /// <summary>
        /// Close the SqlConnection
        /// </summary>
        public void CloseConnection()
        {
            registrationDBConnection.Close();
        }

        /// <summary>
        /// Given a Student object, insert it into the database using SQL command
        /// </summary>
        /// <param name="s">Student object</param>
        public void InsertStudent(Student s)
        {

        }


        /// <summary>
        /// Using SQL Select, return a List of all students in the database
        /// </summary>
        /// <returns>List of Student objects</returns>
        public List<Student> GetStudents()
        {

            return null; // CHANGE THIS
        }

        /// <summary>
        ///  Given a Department object, insert it into the database using SQL command
        /// </summary>
        /// <param name="d">Department object</param>
        public void InsertDepartment(Department d)
        {

        }

        /// <summary>
        /// Using SQL Select, return a List of all departments in the database
        /// </summary>
        /// <returns>List of departments</returns>
        public List<Department> GetDepartments()
        {

            return null; // CHANGE THIS!!
        }

        /// <summary>
        /// Truncate a table, but this does not reseed ident
        /// SQL Statement
        ///     TRUNCATE TABLE tablename
        /// </summary>
        /// <param name="table"></param>

        public void TruncateData(string table)
        {

        }

        /// <summary>
        /// For a department, get the number of students in that department.
        /// MUST use SQL Count
        /// </summary>
        /// <param name="d">Department object</param>
        public void GetNumberOfStudentsInMajor(Department d)
        {

        }

        /// <summary>
        /// EXTRA CREDIT: Create a join to generate a set of departments with 
        ///     registration counts. Use GROUP BY as well.
        /// </summary>
        /// <returns>List of Department objects with NumberOfStudents set for each</returns>
        public List<Department> GetNumberOfStudentsInMajor()
        { 
            return null; // CHANGE THIS!!
        }
    }
}