using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleStoreFormsApp.EF_Classes;
using System.Data.Entity;
using System.Diagnostics;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleStoreFormsApp
{
    public partial class SimpleStoreFormsAppMainForm : System.Windows.Forms.Form
    {
        private SimpleStoreEntities context;

        public SimpleStoreFormsAppMainForm()
        {
            InitializeComponent();
            
            // don't forget to include a using statement

            context = new SimpleStoreEntities();

            // register the event handlers

            this.Load += SimpleStoreMainForm_Load;
            buttonUpdate.Click += ButtonUpdate_Click;
            // when form closed, close database too
            this.FormClosed += SimpleStoreFormsAppMainForm_FormClosed;

        }

        private void SimpleStoreFormsAppMainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            context.Database.Connection.Close();
            context.Dispose();
        }
        
        private void SimpleStoreMainForm_Load(object sender, EventArgs e)
        {
            // initialize Product, Orders datagridview controls here

            // set debug after you have created EF classes
             context.Database.Log = (s => Debug.Write(s));

            // recreate the db, erasing all data in the tables
             context.Database.Delete();
             context.Database.Create();
             context.SaveChanges();

            context.Products.Load();


            // seed product data

            List<Product> products = new List<Product>()  {
                new Product { ProductId = 1, ProductName = "Cheese" },
                new Product { ProductId = 2, ProductName = "Milk" },
                new Product { ProductId = 3, ProductName = "Chicken" },
                new Product { ProductId = 4, ProductName = "Juice" },
            };

            context.Products.AddRange(products);
            // seed customer order data

            List<Order> orders = new List<Order>()  {
                new Order { OrderId = 1, CustomerName = "Micheal", ProductId = 1},
                new Order { OrderId = 2, CustomerName = "Zihi", ProductId = 2},
                new Order { OrderId = 3, CustomerName = "Micheal", ProductId = 2},
                new Order { OrderId = 4, CustomerName = "Zihi", ProductId = 1},
                new Order { OrderId = 5, CustomerName = "Micheal", ProductId = 4},
            };

            context.Orders.AddRange(orders);

            // set datasource after you have created EF classes

            dataGridViewProducts.DataSource = context.Products.Local.ToBindingList();
            dataGridViewProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewProducts.Columns["ProductId"].ReadOnly = true;
            dataGridViewProducts.Columns["ProductId"].DefaultCellStyle.BackColor = Color.LightGray;
            dataGridViewProducts.Columns["Orders"].Visible = false; // to hide the Orders collection


            dataGridViewOrders.DataSource = context.Orders.Local.ToBindingList();
            dataGridViewOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewOrders.Columns["Product"].Visible = false; // to hide the Products collection
            dataGridViewOrders.Columns["OrderId"].DefaultCellStyle.BackColor = Color.LightGray;
            dataGridViewOrders.Columns["OrderId"].ReadOnly = true;

            dataGridViewReport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void ButtonUpdate_Click(object sender, EventArgs e)
        {
            // update Product, Orders controls and database here
            context.SaveChanges();
            dataGridViewProducts.Refresh();
            dataGridViewOrders.Refresh();
            // after dataset is updated, show report

            UpdateReport();

            context.SaveChanges();
            // need to update registration as well

            context.SaveChanges();

        }

        private void UpdateReport()
        {
            // linq query that produces number of orders per product

            // first, combine the two tables, 
            // then group by product id and product name to get count 
           
            var product_order =
                 (from product in context.Products
                  from order in product.Orders
                  group product by new
                  {
                      product.ProductId,
                      product.ProductName
                  } into product_grouped
                  select new Report
                  {
                      ProductId = product_grouped.Key.ProductId,
                      ProductName = product_grouped.Key.ProductName,
                      OrderCount = product_grouped.Count()
                  }).ToList();

            // same query 
            var query5 = context.Products.Select(p => new Report()
            {
                ProductId = p.ProductId,
                ProductName = p.ProductName,
                OrderCount = p.Orders.Count
            });
            
            var query6 = from product in context.Products
                         select new Report()
                         {
                             ProductId = product.ProductId,
                             ProductName = product.ProductName,
                             OrderCount = product.Orders.Count()
                         };

            // update dataGridViewReport control
            dataGridViewReport.DataSource = product_order.ToList();
          
        }

        // private class for report grid view
        private class Report
        {
            [DisplayName("ProductID")]
            public int ProductId { get; set; }
            [DisplayName("Product Name")]
            public string ProductName { get; set; }
            [DisplayName("Order Count")]
            public int OrderCount { get; set; }
        }
    }
}
