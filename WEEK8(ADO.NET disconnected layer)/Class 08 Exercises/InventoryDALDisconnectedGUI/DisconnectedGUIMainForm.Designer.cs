﻿namespace InventoryDALDisconnectedGUI
{
	partial class DisconnectedGUIMainForm
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
            this.lblInstructions = new System.Windows.Forms.Label();
            this.inventoryGrid = new System.Windows.Forms.DataGridView();
            this.buttonUpdateInventory = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // lblInstructions
            // 
            this.lblInstructions.AutoSize = true;
            this.lblInstructions.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstructions.Location = new System.Drawing.Point(10, 7);
            this.lblInstructions.Name = "lblInstructions";
            this.lblInstructions.Size = new System.Drawing.Size(215, 24);
            this.lblInstructions.TabIndex = 3;
            this.lblInstructions.Text = "Please Edit the Data...";
            // 
            // inventoryGrid
            // 
            this.inventoryGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.inventoryGrid.Location = new System.Drawing.Point(10, 36);
            this.inventoryGrid.Name = "inventoryGrid";
            this.inventoryGrid.Size = new System.Drawing.Size(555, 177);
            this.inventoryGrid.TabIndex = 2;
            // 
            // buttonUpdateInventory
            // 
            this.buttonUpdateInventory.Location = new System.Drawing.Point(490, 219);
            this.buttonUpdateInventory.Name = "buttonUpdateInventory";
            this.buttonUpdateInventory.Size = new System.Drawing.Size(75, 23);
            this.buttonUpdateInventory.TabIndex = 4;
            this.buttonUpdateInventory.Text = "Update!";
            this.buttonUpdateInventory.UseVisualStyleBackColor = true;
            // 
            // DisconnectedGUIMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 248);
            this.Controls.Add(this.buttonUpdateInventory);
            this.Controls.Add(this.lblInstructions);
            this.Controls.Add(this.inventoryGrid);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "DisconnectedGUIMainForm";
            this.Text = "Simple GUI Front End to the Inventory Table";
            ((System.ComponentModel.ISupportInitialize)(this.inventoryGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblInstructions;
		private System.Windows.Forms.DataGridView inventoryGrid;
		private System.Windows.Forms.Button buttonUpdateInventory;
	}
}

