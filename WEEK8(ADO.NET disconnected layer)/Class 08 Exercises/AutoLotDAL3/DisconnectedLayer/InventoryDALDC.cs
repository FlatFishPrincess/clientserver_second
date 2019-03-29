using System.Data;
using System.Data.SqlClient;

namespace AutoLotDataDesigner.DisconnectedLayer
{
	public class InventoryDALDC
	{
		// Field data.
		private string connectionString;
		private SqlDataAdapter adapter = null;

		public InventoryDALDC(string connectionString)
		{
            this.connectionString = connectionString;

            // Configure the SqlDataAdapter.
            ConfigureAdapter(out adapter);
		}
		private void ConfigureAdapter(out SqlDataAdapter adapter)
		{
			// Create the adapter and set up the SelectCommand.
			adapter = new SqlDataAdapter("Select * From Inventory", connectionString);

			// Obtain the remaining command objects dynamically at runtime
			// using the SqlCommandBuilder.
			var builder = new SqlCommandBuilder(adapter);
		}
		public DataTable GetAllInventory()
		{
			DataTable inv = new DataTable("Inventory");
			adapter.Fill(inv);
			return inv;
		}

		public void UpdateInventory(DataTable modifiedTable)
		{
			adapter.Update(modifiedTable);
		}
	}
}
