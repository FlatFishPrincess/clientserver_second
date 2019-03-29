using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleWindowsFormsDataBindingDeleteFilter
{
    public partial class SimpleWindowsFormsDataBindingDeleteFilterMainForm : Form
    {
        // A collection of Car objects.
        private List<Car> listCars = new List<Car>();
        private DataTable inventoryTable = new DataTable("Cars");

        public SimpleWindowsFormsDataBindingDeleteFilterMainForm()
        {
            InitializeComponent();

            // Fill the list with some cars.
            listCars = new List<Car>()
            {
                new Car { CarId = 1, Name = "Chucky", Make = "BMW", Color = "Green" },
                new Car { CarId = 2, Name = "Tiny", Make = "Yugo", Color = "White" },
                new Car { CarId = 3, Name = "Ami", Make = "Jeep", Color = "Tan" },
                new Car { CarId = 4, Name = "Pain Inducer", Make = "Caravan", Color = "Pink" },
                new Car { CarId = 5, Name = "Fred", Make = "BMW", Color = "Green" },
                new Car { CarId = 6, Name = "Sidd", Make = "BMW", Color = "Black" },
                new Car { CarId = 7, Name = "Mel", Make = "Firebird", Color = "Red" },
                new Car { CarId = 8, Name = "Sarah", Make = "Colt", Color = "Black" },
            };
            CreateDataTable();

            // fires after the row has been displayed, update the listbox

            dataGridViewInventory.RowPostPaint += DataGridViewInventory_RowPostPaint;
        }

        /// <summary>
        /// Update the listbox after row has been displayed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridViewInventory_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            listBoxCarId.DataSource = GetCarIds(inventoryTable);
        }


        void CreateDataTable()
        {
            // Create table schema.
            var carIDColumn = new DataColumn("CarId", typeof(int));
            var carMakeColumn = new DataColumn("Make", typeof(string));
            var carColorColumn = new DataColumn("Color", typeof(string));
            var carNameColumn = new DataColumn("Name", typeof(string))
            { Caption = "Car Name" };

            inventoryTable.Columns.AddRange(
                new[] { carIDColumn, carMakeColumn, carColorColumn, carNameColumn });

            // Iterate over the array list to make rows.
            foreach (var c in listCars)
            {
                var newRow = inventoryTable.NewRow();
                newRow["CarId"] = c.CarId;
                newRow["Make"] = c.Make;
                newRow["Color"] = c.Color;
                newRow["Name"] = c.Name;
                inventoryTable.Rows.Add(newRow);
                // listBoxCarId.Items.Add(c.Id.ToString()); // add Id to listBox while we are at it
            }

            // Bind the DataTable to the carInventoryGridView.
            dataGridViewInventory.DataSource = inventoryTable;

            // Bind the listbox to a list of CarIds from the inventory table
            //  Note that the datagridview control is now sync'd with the datatable, so
            //  all we need to do is to get the CarId's from the datatable

            listBoxCarId.DataSource = GetCarIds(inventoryTable);
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (listBoxCarId.Items.Count == 0)
                return;

            // Find the correct row to delete.
            DataRow[] rowToDelete = inventoryTable
                .Select($"CarId={listBoxCarId.SelectedItem.ToString()}");

            // Delete it!
            rowToDelete[0].Delete();
            inventoryTable.AcceptChanges();

            // update the listbox
            listBoxCarId.DataSource = GetCarIds(inventoryTable);

        }

        List<int> GetCarIds(DataTable dataTable)
        {
            return dataTable
                .AsEnumerable()
                .Select(x => x.Field<int>("CarId"))
                .OrderBy(x => x).ToList();
        }

        private void ButtonViewMakes_Click(object sender, EventArgs e)
        {
            // Build a filter based on user input.
            string makesFilter = $"Make='{textBoxInputMake.Text}'";

            // Find all rows matching the filter.
            DataRow[] makes = inventoryTable.Select(makesFilter, "Name DESC");

            // use of standard linq
            var query =
                from DataRow row in inventoryTable.AsEnumerable()
                where row.Field<string>("Make") == textBoxInputMake.Text
                orderby row["Name"] descending
                select row;

            MessageBox.Show($"LINQ result count {query.Count()}", "Query Result", MessageBoxButtons.OK);

            string makesOutput = "";
            string makesOutput2 = "";

            foreach (DataRow row in query)
            {
                makesOutput += "Name: " + row["Name"] + ", Color: " + row["Color"] + "\n";
            }

            foreach (DataRow row in makes)
            {
                makesOutput2 += "Name: " + row["Name"] + ", Color: " + row["Color"] + "\n";
            }

            System.Console.WriteLine(makesOutput , makesOutput2);
            MessageBox.Show(makesOutput, $"LINQ We have {query.Count()} {textBoxInputMake.Text}'s named:");

            // just for fun, change datasource

            //dataGridViewInventory.DataSource = query.CopyToDataTable();
            //dataGridViewInventory.Refresh();
        }
    }


    public class Car
    {
        public int CarId { get; set; }
        public string Name { get; set; }
        public string Make { get; set; }
        public string Color { get; set; }
    }
}
