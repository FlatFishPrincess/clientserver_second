using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiTableDataGridViewDataDesigner
{

    public partial class MultiTableDataGridViewDataDesignerMainForm : Form
    {

        MultiTableDataGridViewDesignerOutputForm outputForm;

        public MultiTableDataGridViewDataDesignerMainForm()
        {
            InitializeComponent();

            buttonUpdate.Click += ButtonUpdate_Click;
        }

        private void DataGridViewDataDesignerMainForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'autoLotDataSet.Orders' table. You can move, or remove it, as needed.
            this.ordersTableAdapter.Fill(this.autoLotDataSet.Orders);
            // TODO: This line of code loads data into the 'autoLotDataSet.Customers' table. You can move, or remove it, as needed.
            this.customersTableAdapter.Fill(this.autoLotDataSet.Customers);
            // TODO: This line of code loads data into the 'autoLotDataSet.Inventory' table. You can move, or remove it, as needed.
            this.inventoryTableAdapter.Fill(this.autoLotDataSet.Inventory);

            // show the output report

            outputForm = new MultiTableDataGridViewDesignerOutputForm
            {
                StartPosition = FormStartPosition.CenterParent
            };

            outputForm.Show();
        }

        /// <summary>
        /// Update the database with user input from datagridview controls, then
        /// redisplay the reports in the output form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonUpdate_Click(object sender, EventArgs e)
        {
            ordersTableAdapter.Update(autoLotDataSet.Orders);
            customersTableAdapter.Update(autoLotDataSet.Customers);
            inventoryTableAdapter.Update(autoLotDataSet.Inventory);

            ordersTableAdapter.Fill(autoLotDataSet.Orders);
            customersTableAdapter.Fill(autoLotDataSet.Customers);
            inventoryTableAdapter.Fill(autoLotDataSet.Inventory);

            outputForm.Close();
            outputForm = new MultiTableDataGridViewDesignerOutputForm();
            outputForm.Show();

        }
    }
}
