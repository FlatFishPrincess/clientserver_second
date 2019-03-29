using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using AutoLotDAL2.Models;

namespace AutoLotDAL2.ConnectedLayer
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
		public void InsertCar(Car car)
		{
			// Format and execute SQL statement.
			string sql = "Insert Into Inventory (Make, Color, PetName) Values" +
				$"('{car.Make}', '{car.Color}', '{car.Name}')";

			// Execute using our connection.
			using (SqlCommand command = new SqlCommand(sql, sqlConnection))
			{
				command.ExecuteNonQuery();
			}
		}
		public void InsertCar(string color, string make, string name)
		{
			// Note the "placeholders" in the SQL query.
			string sql = "Insert Into Inventory" +
							"(Make, Color, PetName) Values" +
							"(@Make, @Color, @PetName)";

			// This command will have internal parameters.
			using (SqlCommand command = new SqlCommand(sql, sqlConnection))
			{
				// Fill params collection.
				SqlParameter parameter = new SqlParameter
				{
					ParameterName = "@Make",
					Value = make,
					SqlDbType = SqlDbType.Char,
					Size = 10
				};
				command.Parameters.Add(parameter);

				parameter = new SqlParameter
				{
					ParameterName = "@Color",
					Value = color,
					SqlDbType = SqlDbType.Char,
					Size = 10
				};
				command.Parameters.Add(parameter);

				parameter = new SqlParameter
				{
					ParameterName = "@PetName",
					Value = name,
					SqlDbType = SqlDbType.Char,
					Size = 10
				};
				command.Parameters.Add(parameter);

				command.ExecuteNonQuery();
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
		public void UpdateCarPetName(int id, string newPetName)
		{
			// Get ID of car to modify and new pet name.
			string sql = $"Update Inventory Set PetName = '{newPetName}' Where CarID = '{id}'";
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
						Name = (string)dataReader["PetName"]
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
			using (SqlCommand command = new SqlCommand("GetPetName", sqlConnection))
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
					ParameterName = "@petName",
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
			string firstName;
			string lastName;
			var cmdSelect =
				new SqlCommand($"Select * from Customers where CustID = {custID}",
				sqlConnection);
			using (var dataReader = cmdSelect.ExecuteReader())
			{
				if (dataReader.HasRows)
				{
					dataReader.Read();
					firstName = (string)dataReader["FirstName"];
					lastName = (string)dataReader["LastName"];
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
				$"(FirstName, LastName) Values('{firstName}', '{lastName}')",
				sqlConnection);

			// We will get this from the connection object.
			SqlTransaction transaction = null;
			try
			{
				transaction = sqlConnection.BeginTransaction();

				// Enlist the commands into this transaction.
				cmdInsert.Transaction = transaction;
				cmdRemove.Transaction = transaction;

				// Execute the commands.
				cmdInsert.ExecuteNonQuery();
				cmdRemove.ExecuteNonQuery();

				// Simulate error.
				if (throwEx)
				{
					throw new Exception("Sorry!  Database error! Tx failed...");
				}

				// Commit it!
				transaction.Commit();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				// Any error will roll back transaction.
				transaction?.Rollback();
			}
		}
	}
}
