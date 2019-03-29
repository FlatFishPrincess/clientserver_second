using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace FillDataSetUsingSqlDataAdapter
{
	class FillDataSetUsingSqlDataAdapterProgram
	{
		static void Main(string[] args)
		{
			WriteLine("***** Fun with Data Adapters *****\n");

			// Hard-coded connection string.
			string connectionString = "Integrated Security = SSPI;Initial Catalog=AutoLot;" +
				@"Data Source=(localdb)\MSSQLLocalDB";

			// Caller creates the DataSet object.
			DataSet autoLotDataSet = new DataSet("AutoLot");

            autoLotDataSet.ExtendedProperties.Add("GUID", Guid.NewGuid());
            autoLotDataSet.ExtendedProperties.Add("CreationDate", DateTime.Now);


            // Inform adapter of the Select command text and connection.

            SqlDataAdapter inventoryAdapter =
               new SqlDataAdapter("Select * From Inventory", connectionString);

            // commented out below is the longer form

            //SqlDataAdapter inventoryAdapter = new SqlDataAdapter();
            //inventoryAdapter.SelectCommand = new SqlCommand("Select * From Inventory");
            //inventoryAdapter.SelectCommand.Connection = new SqlConnection(connectionString);

            // Now map DB column names to user - friendly names.

            DataTableMapping inventoryColumnMappings = new DataTableMapping("Inventory", "Current Inventory");
            inventoryColumnMappings.ColumnMappings.Add("CarId", "Car Id");
            inventoryColumnMappings.ColumnMappings.Add("Name", "Car Name");

            inventoryAdapter.TableMappings.Add(inventoryColumnMappings);
            //DataTableMapping tableMapping =
            //     inventoryAdapter.TableMappings.Add("Inventory", "Current Inventory");
            //tableMapping.ColumnMappings.Add("CarId", "Car Id");
            //tableMapping.ColumnMappings.Add("Name", "Car Name");

            new SqlCommandBuilder(inventoryAdapter);  // needed to set up all SQL commands in adapter

            inventoryAdapter.Fill(autoLotDataSet, "Inventory"); // note use of Fill
            DisplayDataSet(autoLotDataSet);

            // change command to only select id and name
            // This will create a new table in the dataset

            inventoryAdapter.SelectCommand.CommandText = "Select CarId,Name from Inventory";

            // create new column mappings using friendly names

            DataTableMapping namesColumnMappings = new DataTableMapping("Names", "Only Car Names");
            namesColumnMappings.ColumnMappings.Add("CarId", "Car Id");
            namesColumnMappings.ColumnMappings.Add("Name", "Car Name");
            inventoryAdapter.TableMappings.Add(namesColumnMappings);

            inventoryAdapter.Fill(autoLotDataSet, "Names"); // this actually creates a new table in memory, but not in DB

            DisplayDataSet(autoLotDataSet);
			ReadLine();
		}
		static void DisplayDataSet(DataSet dataSet)
		{
            const int columnWidth = 10;

			// Print out any name and extended properties. 
			WriteLine($"DataSet is named: {dataSet.DataSetName}");
			foreach (DictionaryEntry dataSetProperty in dataSet.ExtendedProperties)
			{
				WriteLine($"Key = {dataSetProperty.Key}, Value = {dataSetProperty.Value}");
			}

			WriteLine($"Table count {dataSet.Tables.Count}");

            // iterate through tables in the dataset,
            // for each table
            //  display column headers
            //  then for each row, display column

            foreach (DataTable dataTable in dataSet.Tables)
			{
				WriteLine($"=> {dataTable.TableName} Table:");

				// Display the column names.

                foreach(DataColumn column in dataTable.Columns)
                    Write($"{column.ColumnName,columnWidth}");

                WriteLine("\n----------------------------------");

				// Display the DataTable.
				foreach(DataRow row in dataTable.Rows)
				{
					for (int column = 0; column < dataTable.Columns.Count; column++)
					{
						Write($"{row[column].ToString().Trim(), columnWidth}");
					}
                    WriteLine();
                }
            }
		}

	}
}
