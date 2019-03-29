namespace WindowsFormsDataBinding
{
	partial class MoreWindowsFormsDataBindingMainForm
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
            this.dataGridViewInventory = new System.Windows.Forms.DataGridView();
            this.labelGridInfoMessage = new System.Windows.Forms.Label();
            this.groupBoxDeleteRow = new System.Windows.Forms.GroupBox();
            this.btnRemoveCar = new System.Windows.Forms.Button();
            this.textBoxCarToRemove = new System.Windows.Forms.TextBox();
            this.groupBoxViewMakes = new System.Windows.Forms.GroupBox();
            this.btnDisplayMakes = new System.Windows.Forms.Button();
            this.textBoxMakeToView = new System.Windows.Forms.TextBox();
            this.buttonChangeMakes = new System.Windows.Forms.Button();
            this.dataGridViewYugos = new System.Windows.Forms.DataGridView();
            this.labelOnlyYugos = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInventory)).BeginInit();
            this.groupBoxDeleteRow.SuspendLayout();
            this.groupBoxViewMakes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewYugos)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewInventory
            // 
            this.dataGridViewInventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewInventory.Location = new System.Drawing.Point(12, 55);
            this.dataGridViewInventory.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridViewInventory.Name = "dataGridViewInventory";
            this.dataGridViewInventory.RowTemplate.Height = 24;
            this.dataGridViewInventory.Size = new System.Drawing.Size(537, 191);
            this.dataGridViewInventory.TabIndex = 0;
            // 
            // labelGridInfoMessage
            // 
            this.labelGridInfoMessage.AutoSize = true;
            this.labelGridInfoMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGridInfoMessage.Location = new System.Drawing.Point(12, 13);
            this.labelGridInfoMessage.Name = "labelGridInfoMessage";
            this.labelGridInfoMessage.Size = new System.Drawing.Size(287, 24);
            this.labelGridInfoMessage.TabIndex = 2;
            this.labelGridInfoMessage.Text = "Here is what we have in stock";
            // 
            // groupBoxDeleteRow
            // 
            this.groupBoxDeleteRow.Controls.Add(this.btnRemoveCar);
            this.groupBoxDeleteRow.Controls.Add(this.textBoxCarToRemove);
            this.groupBoxDeleteRow.Location = new System.Drawing.Point(16, 261);
            this.groupBoxDeleteRow.Name = "groupBoxDeleteRow";
            this.groupBoxDeleteRow.Size = new System.Drawing.Size(264, 79);
            this.groupBoxDeleteRow.TabIndex = 3;
            this.groupBoxDeleteRow.TabStop = false;
            this.groupBoxDeleteRow.Text = "Enter ID of Car to Delete";
            // 
            // btnRemoveCar
            // 
            this.btnRemoveCar.Location = new System.Drawing.Point(160, 36);
            this.btnRemoveCar.Name = "btnRemoveCar";
            this.btnRemoveCar.Size = new System.Drawing.Size(99, 23);
            this.btnRemoveCar.TabIndex = 1;
            this.btnRemoveCar.Text = "Delete!";
            this.btnRemoveCar.UseVisualStyleBackColor = true;
            this.btnRemoveCar.Click += new System.EventHandler(this.ButtonRemoveCar_Click);
            // 
            // textBoxCarToRemove
            // 
            this.textBoxCarToRemove.Location = new System.Drawing.Point(17, 36);
            this.textBoxCarToRemove.Name = "textBoxCarToRemove";
            this.textBoxCarToRemove.Size = new System.Drawing.Size(137, 20);
            this.textBoxCarToRemove.TabIndex = 0;
            // 
            // groupBoxViewMakes
            // 
            this.groupBoxViewMakes.Controls.Add(this.btnDisplayMakes);
            this.groupBoxViewMakes.Controls.Add(this.textBoxMakeToView);
            this.groupBoxViewMakes.Location = new System.Drawing.Point(286, 261);
            this.groupBoxViewMakes.Name = "groupBoxViewMakes";
            this.groupBoxViewMakes.Size = new System.Drawing.Size(260, 79);
            this.groupBoxViewMakes.TabIndex = 4;
            this.groupBoxViewMakes.TabStop = false;
            this.groupBoxViewMakes.Text = "Enter Make to View";
            // 
            // btnDisplayMakes
            // 
            this.btnDisplayMakes.Location = new System.Drawing.Point(155, 36);
            this.btnDisplayMakes.Name = "btnDisplayMakes";
            this.btnDisplayMakes.Size = new System.Drawing.Size(99, 23);
            this.btnDisplayMakes.TabIndex = 3;
            this.btnDisplayMakes.Text = "View!";
            this.btnDisplayMakes.UseVisualStyleBackColor = true;
            this.btnDisplayMakes.Click += new System.EventHandler(this.ButtonDisplayMakes_Click);
            // 
            // textBoxMakeToView
            // 
            this.textBoxMakeToView.Location = new System.Drawing.Point(12, 36);
            this.textBoxMakeToView.Name = "textBoxMakeToView";
            this.textBoxMakeToView.Size = new System.Drawing.Size(137, 20);
            this.textBoxMakeToView.TabIndex = 2;
            // 
            // buttonChangeMakes
            // 
            this.buttonChangeMakes.Location = new System.Drawing.Point(326, 16);
            this.buttonChangeMakes.Name = "buttonChangeMakes";
            this.buttonChangeMakes.Size = new System.Drawing.Size(223, 23);
            this.buttonChangeMakes.TabIndex = 5;
            this.buttonChangeMakes.Text = "Change All BMWs to Yugos";
            this.buttonChangeMakes.UseVisualStyleBackColor = true;
            this.buttonChangeMakes.Click += new System.EventHandler(this.ButtonChangeMakes_Click);
            // 
            // dataGridViewYugos
            // 
            this.dataGridViewYugos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewYugos.Location = new System.Drawing.Point(6, 379);
            this.dataGridViewYugos.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridViewYugos.Name = "dataGridViewYugos";
            this.dataGridViewYugos.RowTemplate.Height = 24;
            this.dataGridViewYugos.Size = new System.Drawing.Size(537, 191);
            this.dataGridViewYugos.TabIndex = 6;
            // 
            // labelOnlyYugos
            // 
            this.labelOnlyYugos.AutoSize = true;
            this.labelOnlyYugos.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOnlyYugos.Location = new System.Drawing.Point(12, 349);
            this.labelOnlyYugos.Name = "labelOnlyYugos";
            this.labelOnlyYugos.Size = new System.Drawing.Size(118, 24);
            this.labelOnlyYugos.TabIndex = 7;
            this.labelOnlyYugos.Text = "Only Yugos";
            // 
            // MoreWindowsFormsDataBindingMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 577);
            this.Controls.Add(this.labelOnlyYugos);
            this.Controls.Add(this.dataGridViewYugos);
            this.Controls.Add(this.buttonChangeMakes);
            this.Controls.Add(this.groupBoxViewMakes);
            this.Controls.Add(this.groupBoxDeleteRow);
            this.Controls.Add(this.labelGridInfoMessage);
            this.Controls.Add(this.dataGridViewInventory);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "MoreWindowsFormsDataBindingMainForm";
            this.Text = "Windows Forms Data Binding";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInventory)).EndInit();
            this.groupBoxDeleteRow.ResumeLayout(false);
            this.groupBoxDeleteRow.PerformLayout();
            this.groupBoxViewMakes.ResumeLayout(false);
            this.groupBoxViewMakes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewYugos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView dataGridViewInventory;
		private System.Windows.Forms.Label labelGridInfoMessage;
		private System.Windows.Forms.GroupBox groupBoxDeleteRow;
		private System.Windows.Forms.Button btnRemoveCar;
		private System.Windows.Forms.TextBox textBoxCarToRemove;
		private System.Windows.Forms.GroupBox groupBoxViewMakes;
		private System.Windows.Forms.Button btnDisplayMakes;
		private System.Windows.Forms.TextBox textBoxMakeToView;
		private System.Windows.Forms.Button buttonChangeMakes;
		private System.Windows.Forms.DataGridView dataGridViewYugos;
		private System.Windows.Forms.Label labelOnlyYugos;
	}
}

