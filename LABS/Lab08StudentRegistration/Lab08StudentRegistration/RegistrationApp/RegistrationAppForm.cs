using System;
using System.Configuration;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Sql;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

// allows us to use shorter table and adapter names
using static RegistrationApp.StudentRegistrationDataSet;
using RegistrationApp.StudentRegistrationDataSetTableAdapters;

namespace RegistrationApp
{
    public partial class RegistrationAppForm : Form
    {
        // use shorter table names available to all methods

        // variables to hold dataset, tables, and adapters for use in all methods

        StudentRegistrationDataSet studentRegistrationDataSet;

        StudentsDataTable studentsTable;
        RegistrationDataTable registrationTable;
        CoursesDataTable coursesTable;
        DepartmentsDataTable departmentsTable;

        StudentsTableAdapter studentsTableAdapter;
        RegistrationTableAdapter registrationTableAdapter;
        CoursesTableAdapter coursesTableAdapter;
        DepartmentsTableAdapter departmentsTableAdapter;

        public RegistrationAppForm()
        {
            InitializeComponent();

            // create the dataset and adapters

            studentRegistrationDataSet = new StudentRegistrationDataSet();

            studentsTableAdapter = new StudentsTableAdapter();
            registrationTableAdapter = new RegistrationTableAdapter();
            coursesTableAdapter = new CoursesTableAdapter();
            departmentsTableAdapter = new DepartmentsTableAdapter();


            // register event handlers

            buttonUpdate.Click += ButtonUpdate_Click;
            this.Load += RegistrationAppForm_Load;
        }

        /// <summary>
        /// When the form is loaded, create the data tables from initialization data
        /// then update student registration gridview control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RegistrationAppForm_Load(object sender, EventArgs e)
        {
            CreateRegistrationDataTables();
            UpdateStudentRegistration();
        }

        // create the data tables from lists set up with initial data
        // we won't use these lists or the classes after the data tables are created

        private void CreateRegistrationDataTables()
        {
            // set the shorter table names

            registrationTable = studentRegistrationDataSet.Registration;
            coursesTable = studentRegistrationDataSet.Courses;
            studentsTable = studentRegistrationDataSet.Students;
            departmentsTable = studentRegistrationDataSet.Departments;

            // seed all the table data

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

            // registration data - note consists of a registration object, and a student id.
            // if the students table is set up with a different autoincrement that starting at 1, this won't work

            List<Registration> registrations = new List<Registration>()
            {
                new Registration { RegisteredCourse = courses[0], StudentId = 1 },
                new Registration { RegisteredCourse = courses[0], StudentId = 2 },
                new Registration { RegisteredCourse = courses[1], StudentId = 1 },
                new Registration { RegisteredCourse = courses[4], StudentId = 1 },
            };


            // for each table, Fill the dataset table with data from the database (should be zero). 
            //     this also instantiates sql commands

            registrationTableAdapter.Fill(registrationTable);
            coursesTableAdapter.Fill(coursesTable);
            studentsTableAdapter.Fill(studentsTable);
            departmentsTableAdapter.Fill(departmentsTable);

            // make sure student id starts at 1
            ReseedTable(studentsTableAdapter.Connection, studentsTable.TableName, studentsTable.Count());

            // remove any data that is in the data tables. 
            // assumes that the tables have been set up properly using the sql project in this solution

            DeleteData(registrationTableAdapter.Adapter, registrationTable);
            DeleteData(coursesTableAdapter.Adapter, coursesTable);
            DeleteData(studentsTableAdapter.Adapter, studentsTable);
            DeleteData(departmentsTableAdapter.Adapter, departmentsTable);


            //    for each object in the lists above that corresponds to the data table, insert a record
            //    then Update, and re Fill the data table

            // add Students using adapter insert, then update and fill
            // then bind the datasource to the table
            // this is already done for you

            foreach (Student s in students)
            {
                // an alternative to using the Insert method

                //StudentRegistrationDataSet.StudentsRow row = studentRegistrationDataSet.Students.NewStudentsRow();
                //row.StudentFirstName = s.StudentFirstName;
                //row.StudentLastName = s.StudentLastName;
                //row.StudentMajor = s.StudentMajor;
                //studentRegistrationDataSet.Students.AddStudentsRow(row);

                studentsTableAdapter.Insert(s.StudentFirstName, s.StudentLastName, s.StudentMajor);
            }
            studentsTableAdapter.Update(studentsTable);
            studentsTableAdapter.Fill(studentsTable);

            dataGridViewStudents.DataSource = studentsTable;

            // add Departments, then update and fill, and bind datasource
            // your code here

            foreach(Department d in departments)
            {
                departmentsTableAdapter.Insert(d.DepartmentId, d.DepartmentName);
            }
            departmentsTableAdapter.Update(departmentsTable);
            departmentsTableAdapter.Fill(departmentsTable);

            dataGridViewDepartments.DataSource = departmentsTable;

            // add Courses, then update and fill, and bind datasource
            // your code here


            foreach (Course c in courses)
            {
                coursesTableAdapter.Insert(c.CourseId, c.CourseDepartmentId,c.CourseName);
            }
            coursesTableAdapter.Update(coursesTable);
            coursesTableAdapter.Fill(coursesTable);

            dataGridViewCourses.DataSource = coursesTable;

            // sort the courses in gridview
            // hint: use the Sort() method on column 0, ascending
            // your code here

            dataGridViewCourses.Sort(dataGridViewCourses.Columns[0], ListSortDirection.Ascending);


            // add Registration last. add the registrations then update and fill again
            // finally, set DataSource to the table

            foreach (Registration r in registrations)
            {
                registrationTableAdapter.Insert(r.StudentId, r.RegisteredCourse.CourseId, r.RegisteredCourse.CourseDepartmentId);
            }
            registrationTableAdapter.Update(registrationTable);
            registrationTableAdapter.Fill(registrationTable);

            dataGridViewRegistration.DataSource = registrationTable;
            //registrationTableAdapter.Fill(registrationTable); // instantiates sql commands

            // your code here


        }

        /// <summary>
        /// Update all of the tables then fill.
        /// This syncs the dataset with the database and the datagridview controls.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonUpdate_Click(object sender, EventArgs e)
        {
            // your code here 
            // TODO: all tables should be done
            // Adapter.update (table)
            // adpater.fill(table)

            // we now have the latest data so
            // list the courses and students registered requires multi join
            // so we have a separate gridview for this

            UpdateStudentRegistration();
        }

        /// <summary>
        /// Update the student registration datagridview
        /// </summary>
        private void UpdateStudentRegistration()
        {

            // using linq, join students, registration, and courses to get the courses students are registered for



            // your code here





            // don't forget to bind the query result to the control's DataSource
            // your code here
            // stduentRegistrearion is var, from where join student
           // dataGridViewRegistration.DataSource = studentRegisteration.ToList();
        }

        /// <summary>
        /// Delete all data in a table, and update using data adapter
        /// </summary>
        /// <param name="dataAdapter">Adapter to use</param>
        /// <param name="dataTable"></param>
        public void DeleteData(IDbDataAdapter dataAdapter, DataTable dataTable)
        {
            if (dataAdapter == null || dataTable == null || dataTable.DataSet == null)
                return;

            // call the Fill method on the dataset, which loads the select statement
            // as a command

            dataAdapter.Fill(dataTable.DataSet);

            // now delete each row in the datatable (in memory)

            foreach (DataRow d in dataTable.Rows)
                d.Delete();

            // now call Update() which will sync the database with the now cleared table

            dataAdapter.Update(dataTable.DataSet);
        }

        /// <summary>
        /// Using CHECKIDENT, reseed a data table to start id with 1
        /// </summary>
        /// <param name="sqlConnection">Connection object</param>
        /// <param name="tableName">Table to reseed</param>
        /// <param name="reseed">Reseed value</param>
        public void ReseedTable(SqlConnection sqlConnection, string tableName, int numberOfTableRows, int reseed = 0)
        {
            // make sure the arguments are non null

            if (sqlConnection == null || tableName == null)
                return;

            // weird effect of reseed - if there are no rows, and reseed is zero, then it starts with zero.
            // if there were already rows, then it uses the *next* value, so use reseed as zero

            if (reseed == 0 && numberOfTableRows == 0)
                reseed = 1;

            // open the connection, execute the reseed command, and close
            // any errors, show a message and exit the method

            try
            {
                sqlConnection.Open();
                SqlCommand reseedCommand = sqlConnection.CreateCommand();
                reseedCommand.CommandText = $" DBCC CHECKIDENT ('{tableName}', RESEED, {reseed})";
                reseedCommand.ExecuteNonQuery();
                sqlConnection.Close();

            }
            catch
            {
                MessageBox.Show($"Problem with reseed of {tableName} to {reseed}");
                return;
            }
        }
    }
}
