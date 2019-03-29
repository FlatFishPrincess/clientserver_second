using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoLotDataDesigner
{
    public partial class AutoLotMainForm : Form
    {
        /// <summary>
        /// Display Autolot tables
        /// </summary>
        AutoLotOutputForm outputForm;

        public AutoLotMainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Load all of the data from the db for each table. Automatically updates datagridview controls
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AutoLotMainForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'autoLotDataSet.Orders' table. You can move, or remove it, as needed.
            this.ordersTableAdapter.Fill(this.autoLotDataSet.Orders);
            // TODO: This line of code loads data into the 'autoLotDataSet.CustomerOrders' table. You can move, or remove it, as needed.
            this.customerOrdersTableAdapter.Fill(this.autoLotDataSet.CustomerOrders);
            // TODO: This line of code loads data into the 'autoLotDataSet.Customers' table. You can move, or remove it, as needed.
            this.customersTableAdapter.Fill(this.autoLotDataSet.Customers);
            // TODO: This line of code loads data into the 'autoLotDataSet.Inventory' table. You can move, or remove it, as needed.
            this.inventoryTableAdapter.Fill(this.autoLotDataSet.Inventory);

            // display various summary reports

            DisplayReports();

        }

        /// <summary>
        /// Update all of the tables in the db and reload, then show reports in the output form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonUpdate_Click(object sender, EventArgs e)
        {
            ordersTableAdapter.Update(autoLotDataSet.Orders);
            customersTableAdapter.Update(autoLotDataSet.Customers);
            inventoryTableAdapter.Update(autoLotDataSet.Inventory);

            ordersTableAdapter.Fill(this.autoLotDataSet.Orders);
            customersTableAdapter.Fill(this.autoLotDataSet.Customers);
            inventoryTableAdapter.Fill(autoLotDataSet.Inventory);
            customerOrdersTableAdapter.Fill(this.autoLotDataSet.CustomerOrders);

            // display various summary reports
            DisplayReports();

        }

        /// <summary>
        /// Display various summary reports in a new form
        /// </summary>
        private void DisplayReports()
        {
            if (outputForm != null)
                outputForm.Close();

            outputForm = new AutoLotOutputForm()
            {
                StartPosition = FormStartPosition.CenterParent
            };

            outputForm.Show();
            outputForm.UpdateOutput();

        }

    }
}
