namespace SimpleWindowsFormsDataBindingDeleteFilter
{
    partial class SimpleWindowsFormsDataBindingDeleteMainForm
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
            this.components = new System.ComponentModel.Container();
            this.dataGridViewInventory = new System.Windows.Forms.DataGridView();
            this.labelInStock = new System.Windows.Forms.Label();
            this.listBoxCarId = new System.Windows.Forms.ListBox();
            this.carBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.buttonDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInventory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.carBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewInventory
            // 
            this.dataGridViewInventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewInventory.Location = new System.Drawing.Point(56, 75);
            this.dataGridViewInventory.Name = "dataGridViewInventory";
            this.dataGridViewInventory.Size = new System.Drawing.Size(471, 181);
            this.dataGridViewInventory.TabIndex = 0;
            // 
            // labelInStock
            // 
            this.labelInStock.AutoSize = true;
            this.labelInStock.Location = new System.Drawing.Point(53, 24);
            this.labelInStock.Name = "labelInStock";
            this.labelInStock.Size = new System.Drawing.Size(47, 13);
            this.labelInStock.TabIndex = 1;
            this.labelInStock.Text = "In Stock";
            // 
            // listBoxCarId
            // 
            this.listBoxCarId.FormattingEnabled = true;
            this.listBoxCarId.Location = new System.Drawing.Point(56, 281);
            this.listBoxCarId.Name = "listBoxCarId";
            this.listBoxCarId.Size = new System.Drawing.Size(36, 56);
            this.listBoxCarId.TabIndex = 2;
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(107, 297);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonDelete.TabIndex = 3;
            this.buttonDelete.Text = "Delete CarId";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.ButtonDelete_Click);
            // 
            // SimpleWindowsFormsDataBindingDeleteMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 349);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.listBoxCarId);
            this.Controls.Add(this.labelInStock);
            this.Controls.Add(this.dataGridViewInventory);
            this.Name = "SimpleWindowsFormsDataBindingDeleteMainForm";
            this.Text = "Simple Windows Forms Data Binding Filter Delete";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInventory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.carBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewInventory;
        private System.Windows.Forms.Label labelInStock;
        private System.Windows.Forms.ListBox listBoxCarId;
        private System.Windows.Forms.BindingSource carBindingSource;
        private System.Windows.Forms.Button buttonDelete;
    }
}

