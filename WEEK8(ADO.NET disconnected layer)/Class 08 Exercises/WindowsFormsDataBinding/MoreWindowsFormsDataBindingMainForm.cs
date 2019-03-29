using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsDataBinding
{
	public partial class MoreWindowsFormsDataBindingMainForm : Form
	{
		// A collection of Car objects.
		private List<Car> listCars = new List<Car>();

		// Inventory information
		private DataTable inventoryTable = new DataTable();

		//View of the DataTable
		private DataView yugosOnlyView;
		public MoreWindowsFormsDataBindingMainForm()
		{
			InitializeComponent();
			listCars = new List<Car>
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
			ShowCarsWithIdGreaterThanFive();
			CreateDataView();
		}

		void CreateDataTable()
		{
			// Create table schema.
			var carIDColumn = new DataColumn("CarId", typeof(int));
			var carMakeColumn = new DataColumn("Make", typeof(string));
			var carColorColumn = new DataColumn("Color", typeof(string));
			var carNameColumn = new DataColumn("Name", typeof(string))
			    { Caption = "Pet Name" };

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
		}
		private void CreateDataView()
		{
            // Set the table that is used to construct this view.
            yugosOnlyView = new DataView(inventoryTable)
            {
                // Now configure the views using a filter.
                RowFilter = "Make = 'Yugo'",              
            };

            // Bind to the new grid.
            dataGridViewYugos.DataSource = yugosOnlyView;
		}

		private void ButtonRemoveCar_Click(object sender, EventArgs e)
		{
			try
			{
				// Find the correct row to delete.
				DataRow[] rowToDelete = inventoryTable.Select($"CarId={int.Parse(textBoxCarToRemove.Text)}");

				// Delete it!
				rowToDelete[0].Delete();
				inventoryTable.AcceptChanges();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void ButtonDisplayMakes_Click(object sender, EventArgs e)
		{
			// Build a filter based on user input.
			string makeFilter = $"Make='{textBoxMakeToView.Text}'";

			// Find all rows matching the filter.
			DataRow[] makes = inventoryTable.Select(makeFilter, "Name DESC");

			// Show what we got!
			if (makes.Length == 0)
				MessageBox.Show("Sorry, no cars...", "Selection error!");
			else
			{
				string makesOutput = null;

                foreach(DataRow make in makes)
                    makesOutput += make["Name"] + "\n";

				// Now show all matches in a message box.
				MessageBox.Show(makesOutput, $"We have {textBoxMakeToView.Text}'s named:");
			}
		}
		private void ShowCarsWithIdGreaterThanFive()
		{
            // Now show names of all cars with ID greater than 5.

            string newFilterStr = "CarId > 5";

			string carsOutput = null;

            foreach (DataRow car in inventoryTable.Select(newFilterStr))
                carsOutput += $"{car["Name"]} is ID {car["CarId"]}\n";

            MessageBox.Show(carsOutput, $"Names of cars where {newFilterStr}", MessageBoxButtons.OK);
		}

		private void ButtonChangeMakes_Click(object sender, EventArgs e)
		{
            DialogResult reply = MessageBox.Show("Are you sure?? BMWs are much nicer than Yugos!",
                                                "Please Confirm!", 
                                                MessageBoxButtons.YesNo);

            // Make sure user has not lost his or her mind.
            if (reply != DialogResult.Yes)
				return;

			// From a filter, find all rows matching the filter.
            // Change all BMWs to Yugos!

            foreach (DataRow row in inventoryTable.Select("Make='BMW'"))
                row["Make"] = "Yugo";
    	}
	}
}
