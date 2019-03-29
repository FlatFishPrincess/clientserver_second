using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using AutoLotDataDesigner.Models;

namespace AutoLotDataDesigner.ConnectedLayer
{
	public class InventoryDAL
	{
		// This member will be used by all methods.
		private SqlConnection sqlConnection = null;
		public void OpenConnection(string connectionString)
		{
			sqlConnection = new SqlConnection { ConnectionString = connectionString };
			sqlConnection.Open();
		}

		public void CloseConnection()
		{
			sqlConnection.Close();
		}
		//public void InsertAuto(string color, string make, string petName)
		//{
		//	// Format and execute SQL statement.
		//	string sql = "Insert Into Inventory" +
		//	  $"(Make, Color, PetName) Values ('{make}', '{color}', '{petName}')";

		//	// Execute using our connection.
		//	using (SqlCommand command = new SqlCommand(sql, _sqlConnection))
		//	{
		//		command.ExecuteNonQuery();
		//	}
		//}
		public void InsertAuto(Car car)
		{
			// Format and execute SQL statement.
			string sqlCommand = "Insert Into Inventory (Make, Color, Name) Values" +
				$"('{car.Make}', '{car.Color}', '{car.Name}')";

			// Execute using our connection.
			using (SqlCommand command = new SqlCommand(sqlCommand, sqlConnection))
			{
				command.ExecuteNonQuery();
			}
		}
		public void InsertAuto(string color, string make, string petName)
		{
			// Note the "placeholders" in the SQL query.
			string sql = "Insert Into Inventory" +
							"(Make, Color, Name) Values" +
							"(@Make, @Color, @Name)";

			// This command will have internal parameters.
			using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
			{
				// Fill params collection.

                sqlCommand.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@Make",
                    Value = make,
                    SqlDbType = SqlDbType.Char,
                    Size = 10
                });

                sqlCommand.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@Color",
					Value = color,
					SqlDbType = SqlDbType.Char,
					Size = 10
				});

                sqlCommand.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@Name",
					Value = petName,
					SqlDbType = SqlDbType.Char,
					Size = 10
				});

				sqlCommand.ExecuteNonQuery();
			}
		}

		public void DeleteCar(int id)
		{
			// Get ID of car to delete, then do so.
			string sql = $"Delete from Inventory where CarID = '{id}'";
			using (SqlCommand cmd = new SqlCommand(sql, sqlConnection))
			{
				try
				{
					cmd.ExecuteNonQuery();
				}
				catch (SqlException ex)
				{
					Exception error = new Exception("Sorry! That car is on order!", ex);
					throw error;
				}
			}
		}
		public void UpdateCarPetName(int id, string newName)
		{
			// Get ID of car to modify and new pet name.
			string sql = $"Update Inventory Set PetName = '{newName}' Where CarID = '{id}'";
			using (SqlCommand command = new SqlCommand(sql, sqlConnection))
			{
				command.ExecuteNonQuery();
			}
		}
		public List<Car> GetAllInventoryAsList()
		{
			// This will hold the records.
			List<Car> inv = new List<Car>();

			// Prep command object.
			string sql = "Select * From Inventory";
			using (SqlCommand command = new SqlCommand(sql, sqlConnection))
			{
				SqlDataReader dataReader = command.ExecuteReader();
				while (dataReader.Read())
				{
					inv.Add(new Car
					{
						CarID = (int)dataReader["CarID"],
						Color = (string)dataReader["Color"],
						Make = (string)dataReader["Make"],
						Name = (string)dataReader["Name"]
					});
				}
				dataReader.Close();
			}
			return inv;
		}
		public DataTable GetAllInventoryAsDataTable()
		{
			// This will hold the records.
			DataTable dataTable = new DataTable();

			// Prep command object.
			string sql = "Select * From Inventory";
			using (SqlCommand cmd = new SqlCommand(sql, sqlConnection))
			{
				SqlDataReader dataReader = cmd.ExecuteReader();
				// Fill the DataTable with data from the reader and clean up.
				dataTable.Load(dataReader);
				dataReader.Close();
			}
			return dataTable;
		}
		public string LookUpPetName(int carID)
		{
			string carPetName;

			// Establish name of stored proc.
			using (SqlCommand command = new SqlCommand("GetName", sqlConnection))
			{
				command.CommandType = CommandType.StoredProcedure;

				// Input param.
				SqlParameter param = new SqlParameter
				{
					ParameterName = "@carID",
					SqlDbType = SqlDbType.Int,
					Value = carID,
					Direction = ParameterDirection.Input
				};
				command.Parameters.Add(param);

				// Output param.
				param = new SqlParameter
				{
					ParameterName = "@Name",
					SqlDbType = SqlDbType.Char,
					Size = 10,
					Direction = ParameterDirection.Output
				};
				command.Parameters.Add(param);

				// Execute the stored proc.
				command.ExecuteNonQuery();

				// Return output param.
				carPetName = (string)command.Parameters["@petName"].Value;
			}
			return carPetName;
		}
		public void ProcessCreditRisk(bool throwEx, int custID)
		{
			// First, look up current name based on customer ID.
			string fName;
			string lName;
			var cmdSelect =
				new SqlCommand($"Select * from Customers where CustID = {custID}",
				sqlConnection);
			using (var dataReader = cmdSelect.ExecuteReader())
			{
				if (dataReader.HasRows)
				{
					dataReader.Read();
					fName = (string)dataReader["FirstName"];
					lName = (string)dataReader["LastName"];
				}
				else
				{
					return;
				}
			}

			// Create command objects that represent each step of the operation.
			var cmdRemove =
				new SqlCommand($"Delete from Customers where CustID = {custID}",
				sqlConnection);

			var cmdInsert =
				new SqlCommand("Insert Into CreditRisks" +
				$"(FirstName, LastName) Values('{fName}', '{lName}')",
				sqlConnection);

			// We will get this from the connection object.
			SqlTransaction tx = null;
			try
			{
				tx = sqlConnection.BeginTransaction();

				// Enlist the commands into this transaction.
				cmdInsert.Transaction = tx;
				cmdRemove.Transaction = tx;

				// Execute the commands.
				cmdInsert.ExecuteNonQuery();
				cmdRemove.ExecuteNonQuery();

				// Simulate error.
				if (throwEx)
				{
					throw new Exception("Sorry!  Database error! Tx failed...");
				}

				// Commit it!
				tx.Commit();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				// Any error will roll back transaction.
				tx?.Rollback();
			}
		}
	}
}
