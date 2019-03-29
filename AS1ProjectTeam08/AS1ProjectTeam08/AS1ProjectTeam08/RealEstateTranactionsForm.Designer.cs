namespace AS1ProjectTeam08
{
    partial class RealEstateTranactionsForm
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
            this.labelAllTransactions = new System.Windows.Forms.Label();
            this.dataGridViewAllTransactions = new System.Windows.Forms.DataGridView();
            this.labelCountText = new System.Windows.Forms.Label();
            this.labelAveragePriceText = new System.Windows.Forms.Label();
            this.labelCountOutput = new System.Windows.Forms.Label();
            this.labelAveragePriceOutput = new System.Windows.Forms.Label();
            this.labelFilerText = new System.Windows.Forms.Label();
            this.labelCitiesText = new System.Windows.Forms.Label();
            this.labelBedroomsText = new System.Windows.Forms.Label();
            this.labelBathroomText = new System.Windows.Forms.Label();
            this.labelHouseText = new System.Windows.Forms.Label();
            this.listBoxCities = new System.Windows.Forms.ListBox();
            this.listBoxBedrooms = new System.Windows.Forms.ListBox();
            this.listBoxBathrooms = new System.Windows.Forms.ListBox();
            this.listBoxHouseTypes = new System.Windows.Forms.ListBox();
            this.labelPriceText = new System.Windows.Forms.Label();
            this.labelMinPriceText = new System.Windows.Forms.Label();
            this.labelMaxPriceText = new System.Windows.Forms.Label();
            this.textBoxPriceMin = new System.Windows.Forms.TextBox();
            this.textBoxPriceMax = new System.Windows.Forms.TextBox();
            this.surfaceMaxTxt = new System.Windows.Forms.TextBox();
            this.surfaceMinTxt = new System.Windows.Forms.TextBox();
            this.labelSurfaceAreaMaxText = new System.Windows.Forms.Label();
            this.labelSurfaceAreaMinText = new System.Windows.Forms.Label();
            this.labelSurfaceAreaText = new System.Windows.Forms.Label();
            this.checkBoxSearchPrice = new System.Windows.Forms.CheckBox();
            this.checkBoxSeachSurfaceArea = new System.Windows.Forms.CheckBox();
            this.labelSelectedTransactionText = new System.Windows.Forms.Label();
            this.dataGridViewSelectedTransactions = new System.Windows.Forms.DataGridView();
            this.labelSelectedAveragePriceOutput = new System.Windows.Forms.Label();
            this.labelSelectedCountOutput = new System.Windows.Forms.Label();
            this.labelSelectedAveragePriceText = new System.Windows.Forms.Label();
            this.labelSelectedCountText = new System.Windows.Forms.Label();
            this.buttonResetFilters = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAllTransactions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSelectedTransactions)).BeginInit();
            this.SuspendLayout();
            // 
            // labelAllTransactions
            // 
            this.labelAllTransactions.AutoSize = true;
            this.labelAllTransactions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelAllTransactions.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAllTransactions.Location = new System.Drawing.Point(12, 9);
            this.labelAllTransactions.Name = "labelAllTransactions";
            this.labelAllTransactions.Size = new System.Drawing.Size(100, 15);
            this.labelAllTransactions.TabIndex = 0;
            this.labelAllTransactions.Text = "All Transactions";
            // 
            // dataGridViewAllTransactions
            // 
            this.dataGridViewAllTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAllTransactions.Location = new System.Drawing.Point(12, 27);
            this.dataGridViewAllTransactions.Name = "dataGridViewAllTransactions";
            this.dataGridViewAllTransactions.Size = new System.Drawing.Size(635, 224);
            this.dataGridViewAllTransactions.TabIndex = 1;
            // 
            // labelCountText
            // 
            this.labelCountText.AutoSize = true;
            this.labelCountText.Location = new System.Drawing.Point(77, 272);
            this.labelCountText.Name = "labelCountText";
            this.labelCountText.Size = new System.Drawing.Size(44, 13);
            this.labelCountText.TabIndex = 2;
            this.labelCountText.Text = "Count =";
            // 
            // labelAveragePriceText
            // 
            this.labelAveragePriceText.AutoSize = true;
            this.labelAveragePriceText.Location = new System.Drawing.Point(294, 272);
            this.labelAveragePriceText.Name = "labelAveragePriceText";
            this.labelAveragePriceText.Size = new System.Drawing.Size(83, 13);
            this.labelAveragePriceText.TabIndex = 3;
            this.labelAveragePriceText.Text = "Average Price =";
            // 
            // labelCountOutput
            // 
            this.labelCountOutput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelCountOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCountOutput.Location = new System.Drawing.Point(127, 272);
            this.labelCountOutput.Name = "labelCountOutput";
            this.labelCountOutput.Size = new System.Drawing.Size(44, 13);
            this.labelCountOutput.TabIndex = 4;
            // 
            // labelAveragePriceOutput
            // 
            this.labelAveragePriceOutput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelAveragePriceOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAveragePriceOutput.Location = new System.Drawing.Point(385, 272);
            this.labelAveragePriceOutput.Name = "labelAveragePriceOutput";
            this.labelAveragePriceOutput.Size = new System.Drawing.Size(131, 13);
            this.labelAveragePriceOutput.TabIndex = 5;
            // 
            // labelFilerText
            // 
            this.labelFilerText.AutoSize = true;
            this.labelFilerText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelFilerText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFilerText.Location = new System.Drawing.Point(12, 306);
            this.labelFilerText.Name = "labelFilerText";
            this.labelFilerText.Size = new System.Drawing.Size(43, 15);
            this.labelFilerText.TabIndex = 6;
            this.labelFilerText.Text = "Filters";
            // 
            // labelCitiesText
            // 
            this.labelCitiesText.AutoSize = true;
            this.labelCitiesText.Location = new System.Drawing.Point(12, 347);
            this.labelCitiesText.Name = "labelCitiesText";
            this.labelCitiesText.Size = new System.Drawing.Size(32, 13);
            this.labelCitiesText.TabIndex = 7;
            this.labelCitiesText.Text = "Cities";
            // 
            // labelBedroomsText
            // 
            this.labelBedroomsText.AutoSize = true;
            this.labelBedroomsText.Location = new System.Drawing.Point(168, 347);
            this.labelBedroomsText.Name = "labelBedroomsText";
            this.labelBedroomsText.Size = new System.Drawing.Size(54, 13);
            this.labelBedroomsText.TabIndex = 8;
            this.labelBedroomsText.Text = "Bedrooms";
            // 
            // labelBathroomText
            // 
            this.labelBathroomText.AutoSize = true;
            this.labelBathroomText.Location = new System.Drawing.Point(262, 347);
            this.labelBathroomText.Name = "labelBathroomText";
            this.labelBathroomText.Size = new System.Drawing.Size(57, 13);
            this.labelBathroomText.TabIndex = 9;
            this.labelBathroomText.Text = "Bathrooms";
            // 
            // labelHouseText
            // 
            this.labelHouseText.AutoSize = true;
            this.labelHouseText.Location = new System.Drawing.Point(382, 347);
            this.labelHouseText.Name = "labelHouseText";
            this.labelHouseText.Size = new System.Drawing.Size(70, 13);
            this.labelHouseText.TabIndex = 10;
            this.labelHouseText.Text = "House Types";
            // 
            // listBoxCities
            // 
            this.listBoxCities.FormattingEnabled = true;
            this.listBoxCities.Location = new System.Drawing.Point(15, 364);
            this.listBoxCities.Name = "listBoxCities";
            this.listBoxCities.Size = new System.Drawing.Size(118, 121);
            this.listBoxCities.TabIndex = 11;
            // 
            // listBoxBedrooms
            // 
            this.listBoxBedrooms.FormattingEnabled = true;
            this.listBoxBedrooms.Location = new System.Drawing.Point(171, 363);
            this.listBoxBedrooms.Name = "listBoxBedrooms";
            this.listBoxBedrooms.Size = new System.Drawing.Size(51, 121);
            this.listBoxBedrooms.TabIndex = 12;
            // 
            // listBoxBathrooms
            // 
            this.listBoxBathrooms.FormattingEnabled = true;
            this.listBoxBathrooms.Location = new System.Drawing.Point(268, 364);
            this.listBoxBathrooms.Name = "listBoxBathrooms";
            this.listBoxBathrooms.Size = new System.Drawing.Size(51, 121);
            this.listBoxBathrooms.TabIndex = 13;
            // 
            // listBoxHouseTypes
            // 
            this.listBoxHouseTypes.FormattingEnabled = true;
            this.listBoxHouseTypes.Location = new System.Drawing.Point(385, 364);
            this.listBoxHouseTypes.Name = "listBoxHouseTypes";
            this.listBoxHouseTypes.Size = new System.Drawing.Size(87, 121);
            this.listBoxHouseTypes.TabIndex = 14;
            // 
            // labelPriceText
            // 
            this.labelPriceText.AutoSize = true;
            this.labelPriceText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelPriceText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPriceText.Location = new System.Drawing.Point(15, 522);
            this.labelPriceText.Name = "labelPriceText";
            this.labelPriceText.Size = new System.Drawing.Size(33, 15);
            this.labelPriceText.TabIndex = 15;
            this.labelPriceText.Text = "Price";
            // 
            // labelMinPriceText
            // 
            this.labelMinPriceText.AutoSize = true;
            this.labelMinPriceText.Location = new System.Drawing.Point(64, 524);
            this.labelMinPriceText.Name = "labelMinPriceText";
            this.labelMinPriceText.Size = new System.Drawing.Size(24, 13);
            this.labelMinPriceText.TabIndex = 16;
            this.labelMinPriceText.Text = "Min";
            // 
            // labelMaxPriceText
            // 
            this.labelMaxPriceText.AutoSize = true;
            this.labelMaxPriceText.Location = new System.Drawing.Point(64, 564);
            this.labelMaxPriceText.Name = "labelMaxPriceText";
            this.labelMaxPriceText.Size = new System.Drawing.Size(27, 13);
            this.labelMaxPriceText.TabIndex = 17;
            this.labelMaxPriceText.Text = "Max";
            // 
            // textBoxPriceMin
            // 
            this.textBoxPriceMin.Location = new System.Drawing.Point(94, 522);
            this.textBoxPriceMin.Name = "textBoxPriceMin";
            this.textBoxPriceMin.Size = new System.Drawing.Size(100, 20);
            this.textBoxPriceMin.TabIndex = 18;
            // 
            // textBoxPriceMax
            // 
            this.textBoxPriceMax.Location = new System.Drawing.Point(94, 564);
            this.textBoxPriceMax.Name = "textBoxPriceMax";
            this.textBoxPriceMax.Size = new System.Drawing.Size(100, 20);
            this.textBoxPriceMax.TabIndex = 19;
            // 
            // surfaceMaxTxt
            // 
            this.surfaceMaxTxt.Location = new System.Drawing.Point(372, 563);
            this.surfaceMaxTxt.Name = "surfaceMaxTxt";
            this.surfaceMaxTxt.Size = new System.Drawing.Size(100, 20);
            this.surfaceMaxTxt.TabIndex = 24;
            // 
            // surfaceMinTxt
            // 
            this.surfaceMinTxt.Location = new System.Drawing.Point(372, 521);
            this.surfaceMinTxt.Name = "surfaceMinTxt";
            this.surfaceMinTxt.Size = new System.Drawing.Size(100, 20);
            this.surfaceMinTxt.TabIndex = 23;
            // 
            // labelSurfaceAreaMaxText
            // 
            this.labelSurfaceAreaMaxText.AutoSize = true;
            this.labelSurfaceAreaMaxText.Location = new System.Drawing.Point(342, 563);
            this.labelSurfaceAreaMaxText.Name = "labelSurfaceAreaMaxText";
            this.labelSurfaceAreaMaxText.Size = new System.Drawing.Size(27, 13);
            this.labelSurfaceAreaMaxText.TabIndex = 22;
            this.labelSurfaceAreaMaxText.Text = "Max";
            // 
            // labelSurfaceAreaMinText
            // 
            this.labelSurfaceAreaMinText.AutoSize = true;
            this.labelSurfaceAreaMinText.Location = new System.Drawing.Point(342, 523);
            this.labelSurfaceAreaMinText.Name = "labelSurfaceAreaMinText";
            this.labelSurfaceAreaMinText.Size = new System.Drawing.Size(24, 13);
            this.labelSurfaceAreaMinText.TabIndex = 21;
            this.labelSurfaceAreaMinText.Text = "Min";
            // 
            // labelSurfaceAreaText
            // 
            this.labelSurfaceAreaText.AutoSize = true;
            this.labelSurfaceAreaText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelSurfaceAreaText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSurfaceAreaText.Location = new System.Drawing.Point(265, 522);
            this.labelSurfaceAreaText.Name = "labelSurfaceAreaText";
            this.labelSurfaceAreaText.Size = new System.Drawing.Size(71, 15);
            this.labelSurfaceAreaText.TabIndex = 20;
            this.labelSurfaceAreaText.Text = "Surface Area";
            // 
            // checkBoxSearchPrice
            // 
            this.checkBoxSearchPrice.AutoSize = true;
            this.checkBoxSearchPrice.Location = new System.Drawing.Point(94, 590);
            this.checkBoxSearchPrice.Name = "checkBoxSearchPrice";
            this.checkBoxSearchPrice.Size = new System.Drawing.Size(102, 17);
            this.checkBoxSearchPrice.TabIndex = 25;
            this.checkBoxSearchPrice.Text = "Search on Price";
            this.checkBoxSearchPrice.UseVisualStyleBackColor = true;
            // 
            // checkBoxSeachSurfaceArea
            // 
            this.checkBoxSeachSurfaceArea.AutoSize = true;
            this.checkBoxSeachSurfaceArea.Location = new System.Drawing.Point(372, 590);
            this.checkBoxSeachSurfaceArea.Name = "checkBoxSeachSurfaceArea";
            this.checkBoxSeachSurfaceArea.Size = new System.Drawing.Size(140, 17);
            this.checkBoxSeachSurfaceArea.TabIndex = 26;
            this.checkBoxSeachSurfaceArea.Text = "Search on Surface Area";
            this.checkBoxSeachSurfaceArea.UseVisualStyleBackColor = true;
            // 
            // labelSelectedTransactionText
            // 
            this.labelSelectedTransactionText.AutoSize = true;
            this.labelSelectedTransactionText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelSelectedTransactionText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSelectedTransactionText.Location = new System.Drawing.Point(15, 632);
            this.labelSelectedTransactionText.Name = "labelSelectedTransactionText";
            this.labelSelectedTransactionText.Size = new System.Drawing.Size(136, 15);
            this.labelSelectedTransactionText.TabIndex = 27;
            this.labelSelectedTransactionText.Text = "Selected Transactions";
            // 
            // dataGridViewSelectedTransactions
            // 
            this.dataGridViewSelectedTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSelectedTransactions.Location = new System.Drawing.Point(12, 662);
            this.dataGridViewSelectedTransactions.Name = "dataGridViewSelectedTransactions";
            this.dataGridViewSelectedTransactions.Size = new System.Drawing.Size(635, 224);
            this.dataGridViewSelectedTransactions.TabIndex = 28;
            // 
            // labelSelectedAveragePriceOutput
            // 
            this.labelSelectedAveragePriceOutput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelSelectedAveragePriceOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSelectedAveragePriceOutput.Location = new System.Drawing.Point(365, 900);
            this.labelSelectedAveragePriceOutput.Name = "labelSelectedAveragePriceOutput";
            this.labelSelectedAveragePriceOutput.Size = new System.Drawing.Size(131, 13);
            this.labelSelectedAveragePriceOutput.TabIndex = 32;
            // 
            // labelSelectedCountOutput
            // 
            this.labelSelectedCountOutput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelSelectedCountOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSelectedCountOutput.Location = new System.Drawing.Point(107, 900);
            this.labelSelectedCountOutput.Name = "labelSelectedCountOutput";
            this.labelSelectedCountOutput.Size = new System.Drawing.Size(44, 13);
            this.labelSelectedCountOutput.TabIndex = 31;
            // 
            // labelSelectedAveragePriceText
            // 
            this.labelSelectedAveragePriceText.AutoSize = true;
            this.labelSelectedAveragePriceText.Location = new System.Drawing.Point(274, 900);
            this.labelSelectedAveragePriceText.Name = "labelSelectedAveragePriceText";
            this.labelSelectedAveragePriceText.Size = new System.Drawing.Size(83, 13);
            this.labelSelectedAveragePriceText.TabIndex = 30;
            this.labelSelectedAveragePriceText.Text = "Average Price =";
            // 
            // labelSelectedCountText
            // 
            this.labelSelectedCountText.AutoSize = true;
            this.labelSelectedCountText.Location = new System.Drawing.Point(57, 900);
            this.labelSelectedCountText.Name = "labelSelectedCountText";
            this.labelSelectedCountText.Size = new System.Drawing.Size(44, 13);
            this.labelSelectedCountText.TabIndex = 29;
            this.labelSelectedCountText.Text = "Count =";
            // 
            // buttonResetFilters
            // 
            this.buttonResetFilters.Location = new System.Drawing.Point(171, 306);
            this.buttonResetFilters.Name = "buttonResetFilters";
            this.buttonResetFilters.Size = new System.Drawing.Size(75, 23);
            this.buttonResetFilters.TabIndex = 33;
            this.buttonResetFilters.Text = "Reset Filters";
            this.buttonResetFilters.UseVisualStyleBackColor = true;
            // 
            // RealEstateTranactionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 933);
            this.Controls.Add(this.buttonResetFilters);
            this.Controls.Add(this.labelSelectedAveragePriceOutput);
            this.Controls.Add(this.labelSelectedCountOutput);
            this.Controls.Add(this.labelSelectedAveragePriceText);
            this.Controls.Add(this.labelSelectedCountText);
            this.Controls.Add(this.dataGridViewSelectedTransactions);
            this.Controls.Add(this.labelSelectedTransactionText);
            this.Controls.Add(this.checkBoxSeachSurfaceArea);
            this.Controls.Add(this.checkBoxSearchPrice);
            this.Controls.Add(this.surfaceMaxTxt);
            this.Controls.Add(this.surfaceMinTxt);
            this.Controls.Add(this.labelSurfaceAreaMaxText);
            this.Controls.Add(this.labelSurfaceAreaMinText);
            this.Controls.Add(this.labelSurfaceAreaText);
            this.Controls.Add(this.textBoxPriceMax);
            this.Controls.Add(this.textBoxPriceMin);
            this.Controls.Add(this.labelMaxPriceText);
            this.Controls.Add(this.labelMinPriceText);
            this.Controls.Add(this.labelPriceText);
            this.Controls.Add(this.listBoxHouseTypes);
            this.Controls.Add(this.listBoxBathrooms);
            this.Controls.Add(this.listBoxBedrooms);
            this.Controls.Add(this.listBoxCities);
            this.Controls.Add(this.labelHouseText);
            this.Controls.Add(this.labelBathroomText);
            this.Controls.Add(this.labelBedroomsText);
            this.Controls.Add(this.labelCitiesText);
            this.Controls.Add(this.labelFilerText);
            this.Controls.Add(this.labelAveragePriceOutput);
            this.Controls.Add(this.labelCountOutput);
            this.Controls.Add(this.labelAveragePriceText);
            this.Controls.Add(this.labelCountText);
            this.Controls.Add(this.dataGridViewAllTransactions);
            this.Controls.Add(this.labelAllTransactions);
            this.Name = "RealEstateTranactionsForm";
            this.Text = " Assignment 1 Real Estate Transactions  ";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAllTransactions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSelectedTransactions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelAllTransactions;
        private System.Windows.Forms.DataGridView dataGridViewAllTransactions;
        private System.Windows.Forms.Label labelCountText;
        private System.Windows.Forms.Label labelAveragePriceText;
        private System.Windows.Forms.Label labelCountOutput;
        private System.Windows.Forms.Label labelAveragePriceOutput;
        private System.Windows.Forms.Label labelFilerText;
        private System.Windows.Forms.Label labelCitiesText;
        private System.Windows.Forms.Label labelBedroomsText;
        private System.Windows.Forms.Label labelBathroomText;
        private System.Windows.Forms.Label labelHouseText;
        private System.Windows.Forms.ListBox listBoxCities;
        private System.Windows.Forms.ListBox listBoxBedrooms;
        private System.Windows.Forms.ListBox listBoxBathrooms;
        private System.Windows.Forms.ListBox listBoxHouseTypes;
        private System.Windows.Forms.Label labelPriceText;
        private System.Windows.Forms.Label labelMinPriceText;
        private System.Windows.Forms.Label labelMaxPriceText;
        private System.Windows.Forms.TextBox textBoxPriceMin;
        private System.Windows.Forms.TextBox textBoxPriceMax;
        private System.Windows.Forms.TextBox surfaceMaxTxt;
        private System.Windows.Forms.TextBox surfaceMinTxt;
        private System.Windows.Forms.Label labelSurfaceAreaMaxText;
        private System.Windows.Forms.Label labelSurfaceAreaMinText;
        private System.Windows.Forms.Label labelSurfaceAreaText;
        private System.Windows.Forms.CheckBox checkBoxSearchPrice;
        private System.Windows.Forms.CheckBox checkBoxSeachSurfaceArea;
        private System.Windows.Forms.Label labelSelectedTransactionText;
        private System.Windows.Forms.DataGridView dataGridViewSelectedTransactions;
        private System.Windows.Forms.Label labelSelectedAveragePriceOutput;
        private System.Windows.Forms.Label labelSelectedCountOutput;
        private System.Windows.Forms.Label labelSelectedAveragePriceText;
        private System.Windows.Forms.Label labelSelectedCountText;
        private System.Windows.Forms.Button buttonResetFilters;
    }
}

