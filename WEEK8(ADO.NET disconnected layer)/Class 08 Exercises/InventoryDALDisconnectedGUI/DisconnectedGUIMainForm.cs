using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoLotDAL2.DisconnectedLayer; // this is just the revised DAL from Class 06 exercises

namespace InventoryDALDisconnectedGUI
{
	public partial class DisconnectedGUIMainForm : Form
	{
		private InventoryDALDC inventoryDAL = null;
        DataTable inventoryTable = null;


        public DisconnectedGUIMainForm()
		{
			InitializeComponent();

            // register button event handler
            buttonUpdateInventory.Click += ButtonUpdateInventory_Click;

            // this is just for fun ...
            // buttonUpdateInventory.MouseHover += ButtonMouseOver;

			string connectionString = 
				@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AutoLot;" +
				"Integrated Security=True;Pooling=False";

			// Create our data access object.
			inventoryDAL = new InventoryDALDC(connectionString);

            // Fill up our grid!
            inventoryTable = inventoryDAL.GetAllInventory();
            inventoryGrid.DataSource = inventoryTable;
		}

        /// <summary>
        /// Update the database with the in memory datatable, then fill back from the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void ButtonUpdateInventory_Click(object sender, EventArgs e)
		{
            inventoryDAL.UpdateInventory(inventoryTable);
            inventoryTable = inventoryDAL.GetAllInventory();
        }
        private void ButtonMouseOver(object sender, EventArgs e)
        {
            MessageBox.Show("over button");
        }
    }
}
