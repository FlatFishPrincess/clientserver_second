namespace MultitabledDataSet
{
	partial class MultitabledDataSetForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.buttonUpdateDatabase = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridViewOrders = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridViewCustomers = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewInventory = new System.Windows.Forms.DataGridView();
            this.groupBoxCustomerOrder = new System.Windows.Forms.GroupBox();
            this.buttonGetOrderInfo = new System.Windows.Forms.Button();
            this.labelCustomerID = new System.Windows.Forms.Label();
            this.textBoxCustomerID = new System.Windows.Forms.TextBox();
            this.textBoxAllOrders = new System.Windows.Forms.TextBox();
            this.textBoxSelectedOrders = new System.Windows.Forms.TextBox();
            this.labelAllOrders = new System.Windows.Forms.Label();
            this.labelSelectedOrders = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCustomers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInventory)).BeginInit();
            this.groupBoxCustomerOrder.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonUpdateDatabase
            // 
            this.buttonUpdateDatabase.Location = new System.Drawing.Point(405, 353);
            this.buttonUpdateDatabase.Name = "buttonUpdateDatabase";
            this.buttonUpdateDatabase.Size = new System.Drawing.Size(114, 23);
            this.buttonUpdateDatabase.TabIndex = 13;
            this.buttonUpdateDatabase.Text = "Update Database";
            this.buttonUpdateDatabase.Click += new System.EventHandler(this.ButtonUpdateDatabase_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 232);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Current Orders";
            // 
            // dataGridViewOrders
            // 
            this.dataGridViewOrders.Location = new System.Drawing.Point(10, 252);
            this.dataGridViewOrders.Name = "dataGridViewOrders";
            this.dataGridViewOrders.Size = new System.Drawing.Size(509, 90);
            this.dataGridViewOrders.TabIndex = 11;
            this.dataGridViewOrders.Text = "dataGridView3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Current Customers";
            // 
            // dataGridViewCustomers
            // 
            this.dataGridViewCustomers.Location = new System.Drawing.Point(10, 134);
            this.dataGridViewCustomers.Name = "dataGridViewCustomers";
            this.dataGridViewCustomers.Size = new System.Drawing.Size(509, 90);
            this.dataGridViewCustomers.TabIndex = 9;
            this.dataGridViewCustomers.Text = "dataGridView2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Current Inventory";
            // 
            // dataGridViewInventory
            // 
            this.dataGridViewInventory.Location = new System.Drawing.Point(10, 26);
            this.dataGridViewInventory.Name = "dataGridViewInventory";
            this.dataGridViewInventory.Size = new System.Drawing.Size(509, 82);
            this.dataGridViewInventory.TabIndex = 7;
            this.dataGridViewInventory.Text = "dataGridView1";
            // 
            // groupBoxCustomerOrder
            // 
            this.groupBoxCustomerOrder.Controls.Add(this.buttonGetOrderInfo);
            this.groupBoxCustomerOrder.Controls.Add(this.labelCustomerID);
            this.groupBoxCustomerOrder.Controls.Add(this.textBoxCustomerID);
            this.groupBoxCustomerOrder.Location = new System.Drawing.Point(10, 349);
            this.groupBoxCustomerOrder.Name = "groupBoxCustomerOrder";
            this.groupBoxCustomerOrder.Size = new System.Drawing.Size(200, 100);
            this.groupBoxCustomerOrder.TabIndex = 14;
            this.groupBoxCustomerOrder.TabStop = false;
            this.groupBoxCustomerOrder.Text = "Lookup Customer Order";
            // 
            // buttonGetOrderInfo
            // 
            this.buttonGetOrderInfo.Location = new System.Drawing.Point(84, 71);
            this.buttonGetOrderInfo.Name = "buttonGetOrderInfo";
            this.buttonGetOrderInfo.Size = new System.Drawing.Size(110, 23);
            this.buttonGetOrderInfo.TabIndex = 7;
            this.buttonGetOrderInfo.Text = "Get Order Details";
            this.buttonGetOrderInfo.Click += new System.EventHandler(this.ButtonGetOrderInfo_Click);
            // 
            // labelCustomerID
            // 
            this.labelCustomerID.AutoSize = true;
            this.labelCustomerID.Location = new System.Drawing.Point(10, 29);
            this.labelCustomerID.Name = "labelCustomerID";
            this.labelCustomerID.Size = new System.Drawing.Size(68, 13);
            this.labelCustomerID.TabIndex = 9;
            this.labelCustomerID.Text = "Customer ID:";
            // 
            // textBoxCustomerID
            // 
            this.textBoxCustomerID.Location = new System.Drawing.Point(84, 29);
            this.textBoxCustomerID.Name = "textBoxCustomerID";
            this.textBoxCustomerID.Size = new System.Drawing.Size(110, 20);
            this.textBoxCustomerID.TabIndex = 8;
            // 
            // textBoxAllOrders
            // 
            this.textBoxAllOrders.Location = new System.Drawing.Point(597, 26);
            this.textBoxAllOrders.Multiline = true;
            this.textBoxAllOrders.Name = "textBoxAllOrders";
            this.textBoxAllOrders.Size = new System.Drawing.Size(318, 137);
            this.textBoxAllOrders.TabIndex = 15;
            // 
            // textBoxSelectedOrders
            // 
            this.textBoxSelectedOrders.Location = new System.Drawing.Point(597, 229);
            this.textBoxSelectedOrders.Multiline = true;
            this.textBoxSelectedOrders.Name = "textBoxSelectedOrders";
            this.textBoxSelectedOrders.Size = new System.Drawing.Size(318, 137);
            this.textBoxSelectedOrders.TabIndex = 16;
            // 
            // labelAllOrders
            // 
            this.labelAllOrders.AutoSize = true;
            this.labelAllOrders.Location = new System.Drawing.Point(594, 6);
            this.labelAllOrders.Name = "labelAllOrders";
            this.labelAllOrders.Size = new System.Drawing.Size(52, 13);
            this.labelAllOrders.TabIndex = 17;
            this.labelAllOrders.Text = "All Orders";
            // 
            // labelSelectedOrders
            // 
            this.labelSelectedOrders.AutoSize = true;
            this.labelSelectedOrders.Location = new System.Drawing.Point(594, 211);
            this.labelSelectedOrders.Name = "labelSelectedOrders";
            this.labelSelectedOrders.Size = new System.Drawing.Size(83, 13);
            this.labelSelectedOrders.TabIndex = 18;
            this.labelSelectedOrders.Text = "Selected Orders";
            // 
            // MultitabledDataSetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 454);
            this.Controls.Add(this.labelSelectedOrders);
            this.Controls.Add(this.labelAllOrders);
            this.Controls.Add(this.textBoxSelectedOrders);
            this.Controls.Add(this.textBoxAllOrders);
            this.Controls.Add(this.groupBoxCustomerOrder);
            this.Controls.Add(this.buttonUpdateDatabase);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridViewOrders);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridViewCustomers);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridViewInventory);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MultitabledDataSetForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCustomers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInventory)).EndInit();
            this.groupBoxCustomerOrder.ResumeLayout(false);
            this.groupBoxCustomerOrder.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button buttonUpdateDatabase;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.DataGridView dataGridViewOrders;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DataGridView dataGridViewCustomers;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DataGridView dataGridViewInventory;
		private System.Windows.Forms.GroupBox groupBoxCustomerOrder;
		private System.Windows.Forms.Button buttonGetOrderInfo;
		private System.Windows.Forms.Label labelCustomerID;
		private System.Windows.Forms.TextBox textBoxCustomerID;
        private System.Windows.Forms.TextBox textBoxAllOrders;
        private System.Windows.Forms.TextBox textBoxSelectedOrders;
        private System.Windows.Forms.Label labelAllOrders;
        private System.Windows.Forms.Label labelSelectedOrders;
    }
}

