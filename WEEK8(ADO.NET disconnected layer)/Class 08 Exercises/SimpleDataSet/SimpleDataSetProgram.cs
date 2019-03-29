using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using static System.Console;

namespace SimpleDataSet
{
    /// <summary>
    /// Shows how to create and manipulate an in-memory dataset
    /// </summary>
	public class SimpleDataSetProgram
    {
        private static void Main(string[] args)
        {
            WriteLine("***** Fun with DataSets *****\n");

            // A set of Cars for our dataset

            List<Car> carList = new List<Car>()
            {
                new Car("BMW", "Red", "330i"),
                new Car("Honda", "Blue", "Accord"),
                new Car("Chevrolet", "White", "Malibu"),
                new Car("MacLaren", "Silver", "720s"),
                new Car("Porsche", "Gold", "Boxter"),
                new Car("Buick", "Teal", "Le Sabre"),
                new Car("Ford", "Gray", "Focus"),
                new Car("Toyota", "Green", "Corolla"),
                new Car("Tesla", "Orange", "Model S"),
            };

            // Create the DataSet object and add a few properties.
            // These are arbitrary key value pairs

            DataSet carsInventoryDataSet = new DataSet("CarsInventory");

            carsInventoryDataSet.ExtendedProperties["TimeStamp"] = DateTime.Now;
            carsInventoryDataSet.ExtendedProperties["DataSetID"] = Guid.NewGuid(); // globally unique identifier
            carsInventoryDataSet.ExtendedProperties["Company"] = "Mikko's Car Lot";

            // Create another DataSet object for our XML saved data

            DataSet xmlCarsInventoryDataSet = new DataSet("XMLCarsInventory");

            // Fill the DataSet with our list of cars

            FillDataSet(carsInventoryDataSet, carList);

            // Display any name and extended properties. 
            DisplayExtendedProperties(carsInventoryDataSet);

            // Display the data using DataReader, then use row/column

            DisplayDataSetUsingDataReader(carsInventoryDataSet);
            DisplayDataSetUsingRowsAndColumns(carsInventoryDataSet);

            // Add and change a few records

            EditInventoryTable(carsInventoryDataSet);
            DisplayDataSetUsingDataReader(carsInventoryDataSet);

            // save to xml, then reload from xml to a new data set

            SaveAndLoadAsXml(carsInventoryDataSet, xmlCarsInventoryDataSet);
            WriteLine("After reload from XML");

            // show the properties and data for the DataSet loaded from XML
            // note properties are the same as the original

            DisplayExtendedProperties(xmlCarsInventoryDataSet);
            DisplayDataSetUsingDataReader(xmlCarsInventoryDataSet);

            SaveAndLoadAsBinary(carsInventoryDataSet);

            ManipulateDataRowState();

            ReadLine();

        }
        /// <summary>
        /// Load our DataSet with a list of Cars
        ///     Create the Columns
        ///     Create the Table
        ///     Then add to DataSet
        /// </summary>
        /// <param name="ds">DataSet to be filled</param>
        /// <param name="carList">List of Cars</param>
		private static void FillDataSet(DataSet ds, List<Car> carList)
        {
            // Create data columns that map to the 
            // 'real' columns in the Inventory table 
            // of the AutoLot database.

            // there is no database, this is just to show how it can be done in memory

            var carIDColumn = new DataColumn("CarID", typeof(int))
            {
                Caption = "Car ID",
                ReadOnly = true,
                AllowDBNull = false,
                Unique = true,
                AutoIncrement = true,
                AutoIncrementSeed = 1,
                AutoIncrementStep = 1
            };

            var carMakeColumn = new DataColumn("Make", typeof(string));
            var carColorColumn = new DataColumn("Color", typeof(string));

            // this shows how to use the Caption property for a column

            var carNameColumn = new DataColumn("Name", typeof(string))
            {
                Caption = "Car Name"
            };

            // Now add DataColumns to a DataTable.
            var inventoryTable = new DataTable("Inventory");
            inventoryTable.Columns.AddRange(new[]
            {
                carIDColumn, carMakeColumn, carColorColumn, carNameColumn
            });

            // add the data to the table

            foreach (Car c in carList)
                c.FillTableRow(inventoryTable);

            // Now add a few more rows to the Inventory Table.
            DataRow carRow = inventoryTable.NewRow();
            carRow["Make"] = "BMW";
            carRow["Color"] = "Black";
            carRow["Name"] = "X3";
            inventoryTable.Rows.Add(carRow);

            carRow = inventoryTable.NewRow();
            // Column 0 is the autoincremented ID field, 
            // so start at 1.
            carRow[1] = "Saab";
            carRow[2] = "Red";
            carRow[3] = "9000";
            inventoryTable.Rows.Add(carRow);

            // Mark the primary key of this table.
            inventoryTable.PrimaryKey = new[] { inventoryTable.Columns[0] };
            inventoryTable.AcceptChanges();

            // Finally, add our table to the DataSet.
            ds.Tables.Add(inventoryTable);
            ds.AcceptChanges();
        }

        /// <summary>
        /// Example code to change a field in a DataSet Table row
        /// </summary>
        /// <param name="ds">DataSet containing Car data</param>
        private static void EditInventoryTable(DataSet ds)
        {
            DataRow carRow = ds.Tables["Inventory"].Rows[1];
            carRow.BeginEdit();
            WriteLine($"Inventory Table BeginEdit row, state: {carRow.RowState}");

            carRow["Make"] = "Lincoln";
            WriteLine($"Changed value of Make to {carRow["Make"]}, state: {carRow.RowState}");
            carRow.EndEdit();
            WriteLine($"EndEdit row, state: {carRow.RowState}");
            carRow.AcceptChanges();
            WriteLine($"AcceptChanges row, state: {carRow.RowState}");
        }

        /// <summary>
        /// Example code to show change in RowState when adding or editing data
        /// </summary>
		private static void ManipulateDataRowState()
        {
            // Create a temp DataTable for testing.
            var temp = new DataTable("Temp");
            temp.Columns.Add(new DataColumn("TempColumn", typeof(int)));

            WriteLine("Create new table Temp and added TempColumn");

            // RowState = Detached. 
            var row = temp.NewRow();
            WriteLine($"After calling NewRow(): {row.RowState}");

            // RowState = Added.
            temp.Rows.Add(row);
            WriteLine($"After calling Rows.Add(): {row.RowState}");

            // RowState = Added.
            row["TempColumn"] = 10;
            WriteLine($"After first assignment: {row.RowState}");

            // RowState = Unchanged.
            temp.AcceptChanges();
            WriteLine($"After calling AcceptChanges: {row.RowState}");

            // RowState = Modified.
            row["TempColumn"] = 11;
            WriteLine($"After first assignment: {row.RowState}");
            temp.AcceptChanges();
            DisplayTableUsingDataReader(temp);

            // RowState = Deleted.
            temp.Rows[0].Delete();
            WriteLine($"After calling Delete: {row.RowState}");

            temp.Dispose();
        }
        /// <summary>
        /// Display all tables in a dataset using DataReader
        ///     which is the the connected layer.
        /// </summary>
        /// <param name="dataSet">DataSet</param>
		static void DisplayDataSetUsingDataReader(DataSet dataSet)
        {
            //Display each table using data reader

            foreach (DataTable dataTable in dataSet.Tables)
            {
                // Call our new helper method.
                DisplayTableUsingDataReader(dataTable);
            }
        }

        /// <summary>
        /// Display all tables in a DataSet using disconnected layer
        ///     Rows and Columns directly
        /// </summary>
        /// <param name="dataSet">DataSet</param>
        static void DisplayDataSetUsingRowsAndColumns(DataSet dataSet)
        {
            const int columnWidth = 10;

            // Print out each table using rows and columns
            foreach (DataTable dataTable in dataSet.Tables)
            {
                WriteLine($"Rows and Columns => {dataTable.TableName} Table:");

                // Print out the column names.
                foreach (DataColumn column in dataTable.Columns)
                    Write($"{column.ColumnName,columnWidth}");
                WriteLine("\n----------------------------------");

                // Print the DataTable.

                foreach (DataRow row in dataTable.Rows)
                {
                    for (int i = 0; i < row.ItemArray.Length; i++)
                    {
                        Write($"{row.ItemArray[i].ToString(),columnWidth}");
                    }

                    WriteLine();
                }
            }
        }

        /// <summary>
        /// Display an individual table using DataReader
        /// </summary>
        /// <param name="dataTable">DataTable</param>
        static void DisplayTableUsingDataReader(DataTable dataTable)
        {
            const int columnWidth = 10;

            WriteLine($"Data Reader => {dataTable.TableName} Table:");

            // Display the column names.
            for (int column = 0; column < dataTable.Columns.Count; column++)
            {
                Write($"{dataTable.Columns[column].ColumnName.Trim(),columnWidth}");
            }
            WriteLine("\n----------------------------------");

            // Get the DataTableReader type.
            DataTableReader dataTableReader = dataTable.CreateDataReader();

            // The DataTableReader works just like the DataReader.
            while (dataTableReader.Read())
            {
                for (var i = 0; i < dataTableReader.FieldCount; i++)
                {
                    Write($"{dataTableReader.GetValue(i).ToString().Trim(),columnWidth}");
                }
                WriteLine();
            }
            dataTableReader.Close();
        }

        static void DisplayExtendedProperties(DataSet ds)
        {
            // Print out any name and extended properties. 
            WriteLine($"Extended Properties for DataSet named: {ds.DataSetName}");
            foreach (DictionaryEntry de in ds.ExtendedProperties)
            {
                WriteLine($"   Key = {de.Key}, Value = {de.Value}");
            }
            WriteLine();
        }

        /// <summary>
        /// Save a DataSet as an XML file and reload into a new DataSet
        /// </summary>
        /// <param name="sourceDataSet">Source DataSet</param>
        /// <param name="newDataSet">Output DataSet, read in from XML file</param>
		static void SaveAndLoadAsXml(DataSet sourceDataSet, DataSet newDataSet)
        {
            // Save this DataSet as XML.

            sourceDataSet.WriteXml(sourceDataSet.DataSetName + ".xml");
            sourceDataSet.WriteXmlSchema(sourceDataSet.DataSetName + ".xsd");

            LoadAsXML(newDataSet);
        }

        /// <summary>
        /// Load data from XML files into DataSet
        /// </summary>
        /// <param name="dataSet"></param>
        static void LoadAsXML(DataSet dataSet)
        {
            dataSet.Clear();
            dataSet.ReadXmlSchema(dataSet.DataSetName + ".xsd");
            dataSet.ReadXml(dataSet.DataSetName + ".xml");
        }

        /// <summary>
        /// Save as a binary file, need to serialize. Then reload it.
        /// </summary>
        /// <param name="carsInventoryDS"></param>
		static void SaveAndLoadAsBinary(DataSet carsInventoryDS)
        {
            // Set binary serialization flag.
            carsInventoryDS.RemotingFormat = SerializationFormat.Binary;

            // Save this DataSet as binary.
            var binaryFile = new FileStream("BinaryCars.bin", FileMode.Create);
            var binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(binaryFile, carsInventoryDS);
            binaryFile.Close();

            // Clear out DataSet.
            carsInventoryDS.Clear();

            // Load DataSet from binary file.
            binaryFile = new FileStream("BinaryCars.bin", FileMode.Open);
            var data = (DataSet)binaryFormatter.Deserialize(binaryFile);
        }
    }

    public class Car
    {
        public string Make { get; set; }
        public string Color { get; set; }
        public string Name { get; set; }

        public Car(string make, string model, string name)
        {
            Make = make;
            Color = model;
            Name = name;
        }

        public void FillTableRow(DataTable dt)
        {
            DataRow row = dt.NewRow();

            row["Make"] = Make;
            row["Color"] = Color;
            row["Name"] = Name;

            dt.Rows.Add(row);
        }

    }
}
