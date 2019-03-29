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
using System.Data.Entity; // need this for ToBindingList() and Load()


namespace StudentRegistrationFormsApp
{
    // form to collect student information
    //  info is saved in the student field, which is read by the parent

    public partial class AddStudentForm : Form
    {
        private Student student;

        // we need our own copy of the dbcontext to get the department ids

        private StudentRegistrationEntities context = new StudentRegistrationEntities();

        public AddStudentForm()
        {
            InitializeComponent();

            // load the department ids in the listbox

            context.Departments.Load();
            listBoxDepartmentId.DataSource = context.Departments.Select(x => x.DepartmentId).ToList();

            buttonAdd.Click += ButtonAdd_Click; // register the event handler
        }

        // add button is clicked
        //   if any of the textboxes are empty or dept id not selected, give an error message
        //   otherwise store the data in the object, signal OK and close

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            if (textBoxFirstName.Text.Trim().Length == 0 ||
                textBoxLastName.Text.Trim().Length == 0 ||
                listBoxDepartmentId.SelectedItems.Count == 0 )
            {
                MessageBox.Show("Student information is missing.");
            }
            else
            {
                student = new Student
                {
                    StudentFirstName = textBoxFirstName.Text,
                    StudentLastName = textBoxLastName.Text,
                    StudentMajor = listBoxDepartmentId.SelectedItem.ToString()
                };
                this.DialogResult = DialogResult.OK;
                Close();
            }
        }

        public Student GetStudent()
        {
            return student;
        }
    }
}
