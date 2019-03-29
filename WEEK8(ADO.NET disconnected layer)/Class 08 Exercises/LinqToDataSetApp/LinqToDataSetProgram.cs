using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// add reference to AutoLotDAL3 and then you get access to the Designer name space
using AutoLotDataDesigner.DataSets;
using AutoLotDataDesigner.DataSets.AutoLotDataSetTableAdapters;
using static System.Console;

namespace LinqToDataSet
{
	class LinqToDataSetProgram
	{
		static void Main(string[] args)
		{
			WriteLine("***** LINQ over DataSet *****\n");

			// Get a strongly typed DataTable containing the current Inventory
			// of the AutoLot database.
			AutoLotDataSet dal = new AutoLotDataSet();
			InventoryTableAdapter tableAdapter = new InventoryTableAdapter();
			AutoLotDataSet.InventoryDataTable data = tableAdapter.GetData();

			// Display all car ids.
			DisplayAllCarIDs(data);
			WriteLine();

			// Show all red cars.
			ShowRedCars(data);
			WriteLine();

			BuildDataTableFromQuery(data);
			WriteLine();

			ReadLine();

		}
		static void DisplayAllCarIDs(DataTable data)
		{
			// Get enumerable version of DataTable.
			EnumerableRowCollection enumData = data.AsEnumerable();

			// Print the car ID values.
			foreach (DataRow row in enumData)
			{
				WriteLine($"Car ID = {row["CarID"]} {row["Name"]} {row["Color"]}");
			}
		}
		static void ShowRedCars(DataTable data)
		{
            // Project a new result set containing
            // the ID/Make for rows where Color == Red.
            var cars = from car in data.AsEnumerable()
                       where
                         car.Field<string>("Color") == "Red"
                       select new
                       {
                           ID = car.Field<int>("CarID"),
                           Make = car.Field<string>("Make"),
                           Color = car.Field<string>("Color")
					   };


			WriteLine("Here are the red cars we have in stock:");
			foreach (var item in cars)
			{
				WriteLine($"-> CarId = {item.ID} is {item.Make}, {item.Color}");
			}
		}

		static void BuildDataTableFromQuery(DataTable data)
		{
            WriteLine("Showing CarId > 5");
            var cars2 = data.AsEnumerable().Where(x => x.Field<int>("CarID") > 5).CopyToDataTable();

			var cars = from car in data.AsEnumerable()
					   where car.Field<int>("CarID") > 5
					   select car;

			// Use this result set to build a new DataTable. Just a demonstration.

            DisplayAllCarIDs(cars.CopyToDataTable());
		}

	}
}
