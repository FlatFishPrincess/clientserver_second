using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace MultitabledDataSet
{
    public partial class MultitabledDataSetForm : Form
    {
        // Form wide DataSet.
        private DataSet autoLotDataSet = new DataSet("AutoLot");

        // Make use of command builders to simplify data adapter configuration.
        private SqlCommandBuilder inventorySqlCommandBuilder;
        private SqlCommandBuilder customersSqlCommandBuilder;
        private SqlCommandBuilder ordersSqlCommandBuilder;

        // Our data adapters (for each table).
        private SqlDataAdapter inventoryTableAdapter;
        private SqlDataAdapter customersTableAdapter;
        private SqlDataAdapter ordersTableAdapter;

        // Form wide connection string.
        private string connectionString;

        public MultitabledDataSetForm()
        {
            InitializeComponent();

            this.Text = "AutoLot Customer Lookup";

            // Get connection string.
            connectionString =
                ConfigurationManager.ConnectionStrings["AutoLotSqlProvider"].ConnectionString;

            // Create adapters.
            inventoryTableAdapter = new SqlDataAdapter("Select * from Inventory", connectionString);
            customersTableAdapter = new SqlDataAdapter("Select * from Customers", connectionString);
            ordersTableAdapter = new SqlDataAdapter("Select * from Orders", connectionString);

            // Autogenerate commands, required for insert, update, etc.
            inventorySqlCommandBuilder = new SqlCommandBuilder(inventoryTableAdapter);
            ordersSqlCommandBuilder = new SqlCommandBuilder(ordersTableAdapter);
            customersSqlCommandBuilder = new SqlCommandBuilder(customersTableAdapter);

            MessageBox.Show("Insert command for Inventory\n" 
                + inventorySqlCommandBuilder.GetInsertCommand().CommandText);
            MessageBox.Show("Update command for Inventory\n" 
                + inventorySqlCommandBuilder.GetUpdateCommand().CommandText);

            MessageBox.Show("Insert command for Orders\n"
                + ordersSqlCommandBuilder.GetInsertCommand().CommandText);


            // Fill tables in DataSet.
            inventoryTableAdapter.Fill(autoLotDataSet, "Inventory");
            customersTableAdapter.Fill(autoLotDataSet, "Customers");
            ordersTableAdapter.Fill(autoLotDataSet, "Orders");

            MessageBox.Show("Select command for Inventory\n" 
                + inventoryTableAdapter.SelectCommand.CommandText);

            // Build relations between tables.
            BuildTableRelationship();

            // Bind to grids
            dataGridViewInventory.DataSource = autoLotDataSet.Tables["Inventory"];
            dataGridViewCustomers.DataSource = autoLotDataSet.Tables["Customers"];
            dataGridViewOrders.DataSource = autoLotDataSet.Tables["Orders"];
        }
        private void BuildTableRelationship()
        {
            // Create CustomerOrder data relation object.
            DataRelation customerOrderRelation = new DataRelation("CustomerOrder",
                    autoLotDataSet.Tables["Customers"].Columns["CustID"],
                    autoLotDataSet.Tables["Orders"].Columns["CustID"]);
            autoLotDataSet.Relations.Add(customerOrderRelation);

            // Create InventoryOrder data relation object.
            customerOrderRelation = new DataRelation("InventoryOrder",
                    autoLotDataSet.Tables["Inventory"].Columns["CarID"],
                    autoLotDataSet.Tables["Orders"].Columns["CarID"]);
            autoLotDataSet.Relations.Add(customerOrderRelation);
        }

        private void ButtonUpdateDatabase_Click(object sender, System.EventArgs e)
        {
 
            try
            {
                inventoryTableAdapter.Update(autoLotDataSet, "Inventory");
                customersTableAdapter.Update(autoLotDataSet, "Customers");
                ordersTableAdapter.Update(autoLotDataSet, "Orders");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
  
        }

        private void ButtonGetOrderInfo_Click(object sender, EventArgs e)
        {
            string orderInfo = "";

            // Get the customer ID in the text box.
            int custID = int.Parse(textBoxCustomerID.Text);

            // Now based on custID, get the correct row in Customers table.
            var customerRows = autoLotDataSet.Tables["Customers"].Select($"CustID = {custID}");
            orderInfo +=
                $"Customer {customerRows[0]["CustID"]}: {customerRows[0]["FirstName"].ToString().Trim()} {customerRows[0]["LastName"].ToString().Trim()}\n";

            // Navigate from customer table to order table.
            var orderRows = customerRows[0].GetChildRows(autoLotDataSet.Relations["CustomerOrder"]);

            // Loop through all orders for this customer.
            foreach (DataRow order in orderRows)
            {
                orderInfo += $"----\nOrder Number: {order["OrderID"]}\n";

                // Get the car referenced by this order.
                DataRow[] inventoryRows = order.GetParentRows(autoLotDataSet.Relations["InventoryOrder"]);

                // Get info for (SINGLE) car info for this order.
                DataRow car = inventoryRows[0];
                orderInfo += $"Make: {car["Make"]}\n";
                orderInfo += $"Color: {car["Color"]}\n";
                orderInfo += $"Name: {car["Name"]}\n";
            }
            MessageBox.Show(orderInfo, "Order Details");

            // Example using LINQ instead

            var allOrders =
                from customer in autoLotDataSet.Tables["Customers"].AsEnumerable()
                join order in autoLotDataSet.Tables["Orders"].AsEnumerable()
                    on customer.Field<int>("CustID") equals order.Field<int>("CustID")
                select new
                {
                    CustID = customer.Field<int>("CustID"),
                    FirstName = customer.Field<string>("FirstName"),
                    LastName = customer.Field<string>("LastName"),
                    CarID = order.Field<int>("CarID")
                };

            //foreach (var o in allOrders)
            //{
            //    string info = $"{o.CustID} {o.FirstName} {o.LastName} {o.CarID}";
            //    MessageBox.Show(info, "Join on customers, orders");
            //}

            textBoxAllOrders.Lines = allOrders.Select(
                order => $"Customer ID {order.CustID.ToString()} {order.FirstName} {order.LastName}, CarID {order.CarID}"
                )
                .ToArray();

            var carOrders =
                from car in autoLotDataSet.Tables["Inventory"].AsEnumerable()
                join customer in allOrders
                    on car.Field<int>("CarID") equals customer.CarID
                where customer.CustID == custID
                select new
                {
                    customer.CustID,
                    customer.FirstName,
                    customer.LastName,
                    CarMake = car.Field<string>("Make"),
                    CarColor = car.Field<string>("Color"),
                    CarName = car.Field<string>("Name")
                };

            textBoxSelectedOrders.Lines = carOrders.Select(
                order => $"Customer ID {order.CustID.ToString()} {order.FirstName} {order.LastName}, Car {order.CarMake} {order.CarColor} {order.CarName}"
                )
                .ToArray();

            //foreach (var order in carOrders)
            //{
            //    string info = $"Customer: {order.CustID} {order.FirstName} {order.LastName} Car: {order.CarMake} {order.CarColor} {order.CarPetName}";
            //    MessageBox.Show(info, "Order");
            //}



        }
    }
}
