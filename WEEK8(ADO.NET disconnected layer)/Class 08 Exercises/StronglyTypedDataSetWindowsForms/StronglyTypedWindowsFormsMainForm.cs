using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// A reference needs to be added for AutoLotDAL3 for the following to work
using AutoLotDAL3;
using static AutoLotDAL3.DataSets.AutoLotDataSet;
using AutoLotDAL3.DataSets.AutoLotDataSetTableAdapters;

namespace StronglyTypedDataSetWindowsForms
{
    // very simple program to display the inventory table without using forms designer
    // except for main form creation and setup

    public partial class StronglyTypedWindowsFormsMainForm : Form
    {
        // create DataTable and Adapter

        InventoryDataTable inventoryTable = new InventoryDataTable();
        InventoryTableAdapter inventoryAdapter = new InventoryTableAdapter();

        // create the controls

        DataGridView inventoryDataGridView = new DataGridView();

        Button updateButton = new Button();

        /// <summary>
        /// Set up the main form
        /// </summary>
        public StronglyTypedWindowsFormsMainForm()
        {
            InitializeComponent(); // main form setup from designer

            // set the form title

            this.Text = "StronglyTyped Dataset Demo";

            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowOnly;

            // event handler for main form 

            this.Load += StronglyTypedWindowsFormsMainForm_Load;
        }

        /// <summary>
        /// Generally update the database with any changes and refresh the entire control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateButton_Click(object sender, EventArgs e)
        {
            inventoryAdapter.Update(inventoryTable);
            inventoryAdapter.Fill(inventoryTable);

        }

        /// <summary>
        /// Set the datasource to the inventory table, and fill the table from the database
        /// Then set up the datagridview and button controls, sized and positioned to fit the data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StronglyTypedWindowsFormsMainForm_Load(object sender, EventArgs e)
        {

            // autosize the columns to fill the datagridview control

            inventoryDataGridView.AutoGenerateColumns = true;
            inventoryDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // fill the inventory table with data from the database

            inventoryAdapter.Fill(inventoryTable);

            // associate inventory data table with datagridview

            inventoryDataGridView.DataSource = inventoryTable;

            // get all of the column widths, then set the form width to accommodate
            // note that we only want the columns with data, the add in the row header width

            this.Width = inventoryDataGridView.Columns
                .OfType<DataGridViewColumn>()
                .Select(x => x.Width)
                .Sum() + inventoryDataGridView.RowHeadersWidth + 250;

            // label and position the button, then resize the form to include the button

            updateButton.Text = "Update";
            updateButton.Location = new Point(this.Width/2, inventoryDataGridView.Size.Height + 40);

            this.Height = updateButton.Height + 250; // add a little space between the button and the form lower bound

            // finally add the controls to the form

            this.Controls.Add(inventoryDataGridView);
            this.Controls.Add(updateButton);

            // event handlers for controls

            inventoryDataGridView.CellValueChanged += InventoryDataGridviewCellChanged;
            updateButton.Click += UpdateButton_Click;

        }

        /// <summary>
        /// If any cell in datagridview changed, update the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InventoryDataGridviewCellChanged(object sender, EventArgs e)
        {
            inventoryAdapter.Update(inventoryTable);
        }
    }
}
