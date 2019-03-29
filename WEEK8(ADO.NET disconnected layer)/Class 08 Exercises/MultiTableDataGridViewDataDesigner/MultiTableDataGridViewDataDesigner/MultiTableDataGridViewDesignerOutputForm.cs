using MultiTableDataGridViewDesigner;
using MultiTableDataGridViewDesigner.AutoLotDataSetTableAdapters;
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
    /// <summary>
    /// Display various AutoLot reports in a single text box
    /// </summary>
    /// 
    public partial class MultiTableDataGridViewDesignerOutputForm : Form
    {
        public MultiTableDataGridViewDesignerOutputForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Display inventory, customers, and orders report.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OutputForm_Load(object sender, EventArgs e)
        {

            // Create new strongly typed datatables, and associated table adapters.

            var inventoryTable = new AutoLotDataSet.InventoryDataTable();
            var ordersTable = new AutoLotDataSet.OrdersDataTable();
            var customersTable = new AutoLotDataSet.CustomersDataTable();

            InventoryTableAdapter inventoryAdapter = new InventoryTableAdapter();
            CustomersTableAdapter customersAdapter = new CustomersTableAdapter();
            OrdersTableAdapter ordersAdapter = new OrdersTableAdapter();

            // now fill the tables with data

            inventoryAdapter.Fill(inventoryTable);
            customersAdapter.Fill(customersTable);
            ordersAdapter.Fill(ordersTable);

            // display all of the cars from inventory

            textBoxOutput.AppendText($"Inventory Count = {inventoryTable.Count()}{Environment.NewLine}");

            foreach (var car in inventoryTable)
                textBoxOutput.AppendText($"{car.CarId} {car.Make} {car.Color} {car.Name}{Environment.NewLine}");


            // display  only cars with Id < 5

            var carsQuery =
                from car in inventoryTable
                where car.CarId < 5
                select car;

            textBoxOutput.AppendText($"{Environment.NewLine}LINQ result CarId < 5{Environment.NewLine}");

            foreach (var car in carsQuery)
                textBoxOutput.AppendText($"{car.CarId} {car.Make} {car.Color} {car.Name}{Environment.NewLine}");

            // display all orders, and show customer first and last name

            var ordersQuery =
                from order in ordersTable
                from car in inventoryTable
                from customer in customersTable
                where order.CustId == customer.CustId
                where order.CarId == car.CarId
                select new
                {
                    order.OrderId,
                    car.CarId,  // note use of implicit names for new anon object
                    car.Name,
                    car.Make,
                    CustomerId = customer.CustId,
                    CustomerName = customer.FirstName + " " + customer.LastName,
                };

            textBoxOutput.AppendText($"{Environment.NewLine}Orders Count = {ordersQuery.Count()}{Environment.NewLine}");
            foreach (var order in ordersQuery)
                textBoxOutput.AppendText($"#{order.OrderId} {order.CarId} {order.Make} {order.Name} by {order.CustomerId} {order.CustomerName}{Environment.NewLine}");


        }
    }
}
