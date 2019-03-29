using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleWindowsFormsDataBinding
{
    public partial class SimpleWindowsFormsDataBindingMainForm : Form
    {
        // A collection of Car objects.
        private List<Car> listCars = new List<Car>();
        private DataTable inventoryTable = new DataTable("Cars");

        public SimpleWindowsFormsDataBindingMainForm()
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
        }
        void CreateDataTable()
        {
            // Create table schema.
            var carIDColumn = new DataColumn("CarId", typeof(int))
                { Caption = "Car ID" };
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
            }
            // Bind the DataTable to the carInventoryGridView.
            dataGridViewInventory.DataSource = inventoryTable;
            dataGridViewInventory.AllowUserToAddRows = false;
            dataGridViewInventory.AllowUserToDeleteRows = false;
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
