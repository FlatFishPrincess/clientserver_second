using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Need to add reference to AutoLotDALTest
//using AutoLotDALTest;
//using AutoLotDALTest.AutoLotDataSetTableAdapters;
using AutoLotDataDesigner;
using AutoLotDataDesigner.AutoLotDataSetTableAdapters;
using static System.Console;

namespace StronglyTypedDataSetConsoleClient
{
	class StronglyTypedDataSetConsoleClientProgram
	{
		static void Main(string[] args)
		{
			WriteLine("***** Fun with Strongly Typed DataSets *****\n");

			// Caller creates the DataSet object.
			var table = new AutoLotDataSet.InventoryDataTable();

			// Inform adapter of the Select command text and connection.
			var adapter = new InventoryTableAdapter();

			// Fill our DataSet with a new table, named Inventory.
			adapter.Fill(table);
			DisplayInventory(table);
			WriteLine();
            ReadLine();

            // Add rows, update and reprint. 
            WriteLine("Add a few new records");
			AddRecords(table, adapter);
			table.Clear();
			adapter.Fill(table);
			DisplayInventory(table);
			WriteLine();
            ReadLine();

            // Remove rows we just made and reprint.
            WriteLine("Remove the records we just added");
			RemoveRecords(table, adapter);
			table.Clear();
			adapter.Fill(table);
			DisplayInventory(table);
			WriteLine();

			CallStoredProcedure();
			ReadLine();

		}
		static void DisplayInventory(AutoLotDataSet.InventoryDataTable dt)
		{
            // Display the column names

            foreach (DataColumn column in dt.Columns)
                Write($"{column.ColumnName}\t");
            WriteLine("\n----------------------------------");

            // Display each row - note use of strongly typed fields

            foreach (AutoLotDataSet.InventoryRow row in dt)
            {
                WriteLine($"{row.CarId}\t{row.Make}\t{row.Name}\t{row.Color}");
            }
		}
		public static void AddRecords(
			AutoLotDataSet.InventoryDataTable table,
			InventoryTableAdapter adapter)
		{
			try
			{
				// Get a new strongly typed row from the table.
				AutoLotDataSet.InventoryRow newRow = table.NewInventoryRow();

				// Fill row with some sample data.
				newRow.Color = "Purple";
				newRow.Make = "BMW";
				newRow.Name = "Saku";

				// Insert the new row.
				table.AddInventoryRow(newRow);

				// Add one more row, using overloaded Add method.
				table.AddInventoryRow("Yugo", "Green", "Zippy");

				// Update database.
				adapter.Update(table);
			}
			catch (Exception ex)
			{
				WriteLine(ex.Message);
			}
		}
		private static void RemoveRecords(AutoLotDataSet.InventoryDataTable table, InventoryTableAdapter adapter)
		{
			try
			{
				AutoLotDataSet.InventoryRow rowToDelete = table.FindByCarId(table.Last().CarId);
            
				adapter.Delete(rowToDelete.CarId, rowToDelete.Make, rowToDelete.Color, rowToDelete.Name);
				rowToDelete = table.FindByCarId(table.Last().CarId - 1);
				adapter.Delete(rowToDelete.CarId, rowToDelete.Make, rowToDelete.Color, rowToDelete.Name);
                adapter.Update(table);
			}
			catch (Exception ex)
			{
				WriteLine(ex.Message);
			}
		}
		public static void CallStoredProcedure()
		{
			try
			{
				var queriesTableAdapter = new QueriesTableAdapter();
				Write("Enter ID of car to look up: ");
				string carID = ReadLine() ?? "0";
				string carName = "";
				queriesTableAdapter.GetName(int.Parse(carID), ref carName);
				WriteLine($"Using GetName: CarID {carID} has the name of {carName}");
			}
			catch (Exception ex)
			{
				WriteLine(ex.Message);
			}
		}


	}
}
