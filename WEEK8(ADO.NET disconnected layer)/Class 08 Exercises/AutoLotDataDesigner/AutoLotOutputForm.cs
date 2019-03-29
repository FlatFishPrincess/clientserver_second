using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoLotDataDesigner.AutoLotDataSetTableAdapters;

// can also use the following, but add a reference to AutoLotDAL3 first
// using AutoLotDataDesigner.DataSets.AutoLotDataSetTableAdapters;

namespace AutoLotDataDesigner
{
    /// <summary>
    /// Form opened after user hits update button
    /// </summary>
    public partial class AutoLotOutputForm : Form
    {
        public AutoLotOutputForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Update the textbox contain information about all cars in inventory
        /// </summary>

        public void UpdateOutput()
        {
            // load and fill the inventory table

            var inventoryTable = new AutoLotDataSet.InventoryDataTable();
            InventoryTableAdapter adapter = new InventoryTableAdapter();

            adapter.Fill(inventoryTable);

            // for each record, show the car information
            // note use of Environment.NewLine as AppendText() needs more than \n

            textBoxOutput.AppendText($"Inventory{Environment.NewLine}");

            foreach (var row in inventoryTable)
                textBoxOutput.AppendText($"{row.CarId} {row.Make} {row.Color} {row.Name}{Environment.NewLine}");

            textBoxOutput.AppendText($"Count = {inventoryTable.Count}{Environment.NewLine}");

            // now show a linq query where CarId < 5

            var query =
                from row in inventoryTable.AsEnumerable()
                where row.CarId < 5
                select row;

            // just another version using linq methods and lambda

            var query2 = inventoryTable.AsEnumerable().Where(row => row.CarId < 5);

            textBoxOutput.AppendText($"{Environment.NewLine}LINQ result CarId < 5{Environment.NewLine}");

            foreach (var row in query)
                textBoxOutput.AppendText($"{row.CarId} {row.Make} {row.Color} {row.Name}{Environment.NewLine}");
        }
    }
}
