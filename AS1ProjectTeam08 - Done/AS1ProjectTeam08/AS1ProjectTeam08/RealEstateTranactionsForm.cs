using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace AS1ProjectTeam08
{
    public partial class RealEstateTranactionsForm : Form
    {
        // the list of house, xml data will be stored here
        List<House> houseList;
        public RealEstateTranactionsForm()
        {

            // prompt the user for a file, then read the xml file
            GetRealEstateTransactionFromXML();
            InitializeComponent();
            
            // Initialsize grid view and listboxes
            InitializeDataGridViewRentalHousing();
            InitializeAllListControls();
            checkBoxSeachSurfaceArea.Click += CheckBoxSeachSurfaceArea_Click;
            checkBoxSearchPrice.Click += CheckBoxSearchPrice_Click;
            textBoxPriceMin.TextChanged += TextBoxPriceMin_TextChanged;
            textBoxPriceMax.TextChanged += TextBoxPriceMax_TextChanged;
            textBoxSurfaceMin.TextChanged += TextBoxSurfaceMin_TextChanged;
            textBoxSurfaceMax.TextChanged += TextBoxSurfaceMax_TextChanged;

            // Display all real estate transaction
            DisplayAllRealEsatateTransactions();

            // Display selected Transaction
            DisplaySelectedTransactions();
            // TODO: text box validation or any error handling
            // TODO: reset filter button
            // I left reset button cuz it might be more complicating if I put some parts of code.
            buttonResetFilters.Click += ButtonResetFilters_Click;
        }

        private void TextBoxSurfaceMax_TextChanged(object sender, EventArgs e)
        {
            int maxSurface;
            if (int.TryParse(textBoxSurfaceMax.Text, out maxSurface))
                DisplaySelectedTransactions();
            else
            {
                MessageBox.Show(this, "Surface area is missing or is not an integer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                checkBoxSeachSurfaceArea.Checked = false;
                textBoxSurfaceMax.Focus();
                DisplaySelectedTransactions();
            }
        }

        private void TextBoxSurfaceMin_TextChanged(object sender, EventArgs e)
        {
            int minSurface;
            if (int.TryParse(textBoxSurfaceMin.Text, out minSurface))
                DisplaySelectedTransactions();
            else
            {
                MessageBox.Show(this, "Surface area is missing or is not an integer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                checkBoxSeachSurfaceArea.Checked = false;
                textBoxSurfaceMin.Focus();
                DisplaySelectedTransactions();
            }
        }

        private void TextBoxPriceMax_TextChanged(object sender, EventArgs e)
        {
            int maxPrice;
            if (int.TryParse(textBoxPriceMax.Text, out maxPrice))
                DisplaySelectedTransactions();
            else
            {
                MessageBox.Show(this, "Price is missing or is not an integer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                checkBoxSearchPrice.Checked = false;
                textBoxPriceMax.Focus();
                DisplaySelectedTransactions();
            }
        }

        private void TextBoxPriceMin_TextChanged(object sender, EventArgs e)
        {
            int minPrice;
            if(int.TryParse(textBoxPriceMin.Text,out minPrice))
                DisplaySelectedTransactions();
            else
            {
                MessageBox.Show(this, "Price is missing or is not an integer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                checkBoxSearchPrice.Checked = false;
                textBoxPriceMin.Focus();
                DisplaySelectedTransactions();
            }
        }

        /// <summary>
        /// Validate the text boxes for min and max price, if everything is ok call the method to display the selected transactions
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckBoxSearchPrice_Click(object sender, EventArgs e)
        {
            try
            {
                var minValue = int.Parse(textBoxPriceMin.Text);
                var maxValue = int.Parse(textBoxPriceMax.Text);
                DisplaySelectedTransactions();

            }
            catch (Exception)
            {
                MessageBox.Show(this, "Price is missing or is not an integer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                checkBoxSearchPrice.Checked = false;
                textBoxPriceMin.Focus();           
            }

        }

        /// <summary>
        /// Validate the text boxes for min and max surface area, if everything is ok call the method to display the selected transactions
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckBoxSeachSurfaceArea_Click(object sender, EventArgs e)
        {
            try
            {
                var minValue = int.Parse(textBoxSurfaceMin.Text);
                var maxValue = int.Parse(textBoxSurfaceMax.Text);
                DisplaySelectedTransactions();

            }
            catch (Exception)
            {
                MessageBox.Show(this, "Surface area is missing or is not an integer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                checkBoxSeachSurfaceArea.Checked = false;
                textBoxSurfaceMin.Focus();
                DisplaySelectedTransactions();
            }
           
        }

        private void ButtonResetFilters_Click(object sender, EventArgs e)
        {
            ResetControlsToDefault();
        }
        private void ListBoxCities_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplaySelectedTransactions();
        }
        private void ListBoxHouseTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplaySelectedTransactions();
        }

        private void ListBoxBathrooms_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplaySelectedTransactions();
        }

        private void ListBoxBedrooms_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplaySelectedTransactions();
        }

        /// <summary>
        /// Reset Control to default
        /// </summary>
        private void ResetControlsToDefault()
        {
            //Unsubscribe events
            // TODO: reset all controls
            InitializeDataGridViewRentalHousing();
            InitializeAllListControls();
            checkBoxSeachSurfaceArea.Checked = false;
            checkBoxSearchPrice.Checked = false;
            textBoxPriceMax.Text = "";
            textBoxPriceMin.Text = "";
            textBoxSurfaceMax.Text = "";
            textBoxSurfaceMin.Text = "";
            DisplaySelectedTransactions();

        }
        
        /// <summary>
        /// Display all rental housing according to 
        /// </summary>
        public void DisplayAllRealEsatateTransactions()
        {
            dataGridViewAllTransactions.Rows.Clear(); // clear old data first

            int numberOfTransaction = 0; // the transaction count
            double totalPrice = 0;
            double averagePrice = 0; // average price 

            var allHouses = from house in houseList
                                orderby house.City, house.HouseType, house.Price
                                select house;

            foreach (House house in allHouses)
            {
                dataGridViewAllTransactions.Rows.Add(house.City, house.Address,
                                house.Bedrooms, house.Bathrooms, house.SurfaceArea, house.HouseType, house.Price);
                totalPrice += house.Price;
            }
            
            // show number of apartments and total residences
            numberOfTransaction = allHouses.Count();
            averagePrice = totalPrice / numberOfTransaction;
            labelCountOutput.Text = numberOfTransaction.ToString();
            labelAveragePriceOutput.Text = averagePrice.ToString("C2");                       
    
        }

        /// <summary>
        /// This method display all the transactions according to the filter selected
        /// </summary>
        public void DisplaySelectedTransactions()
        {
            dataGridViewSelectedTransactions.Rows.Clear(); //Clear old data first
            int numberOfTransaction = 0; // the transaction count
            double totalPrice = 0;
            double averagePrice = 0; // average price 
            int minPrice, maxPrice, minSurface, maxSurface;
            int.TryParse(textBoxPriceMin.Text, out minPrice);
            int.TryParse(textBoxPriceMax.Text, out maxPrice);
            int.TryParse(textBoxSurfaceMin.Text, out minSurface);
            int.TryParse(textBoxSurfaceMax.Text, out maxSurface);

            List<String> chosenCities = new List<String>();
            // create a list of chosen cities 
            foreach (var selected in listBoxCities.SelectedItems)
            {
                chosenCities.Add(selected.ToString());
            }

            List<String> chosenBedrooms = new List<String>();
            // create a list of chosen cities 
            foreach (var selected in listBoxBedrooms.SelectedItems)
            {
                chosenBedrooms.Add(selected.ToString());
            }

            List<String> chosenBathrooms = new List<String>();
            // create a list of chosen cities 
            foreach (var selected in listBoxBathrooms.SelectedItems)
            {
                chosenBathrooms.Add(selected.ToString());
            }

            List<String> chosenHouseTypes = new List<String>();
            // create a list of chosen cities 
            foreach (var selected in listBoxHouseTypes.SelectedItems)
            {
                chosenHouseTypes.Add(selected.ToString());
            }

            Expression<Func<House, bool>> expression = p => chosenCities.Contains(p.City) &&
                                                            chosenBedrooms.Contains(p.Bedrooms.ToString()) &&
                                                            chosenBathrooms.Contains(p.Bathrooms.ToString()) &&
                                                            chosenHouseTypes.Contains(p.HouseType) &&
                                                            ((p.Price <= maxPrice && p.Price >= minPrice) || !checkBoxSearchPrice.Checked) &&
                                                            ((p.SurfaceArea <= maxSurface && p.SurfaceArea >= minSurface) || !checkBoxSeachSurfaceArea.Checked);

            var selectedHouses = houseList.Where(expression.Compile()).OrderBy(p => p.City).ThenBy(p => p.HouseType).ThenBy(p => p.Price);
            
            foreach (House house in selectedHouses)
            {
                dataGridViewSelectedTransactions.Rows.Add(house.City, house.Address,
                                house.Bedrooms, house.Bathrooms, house.SurfaceArea, house.HouseType, house.Price);
                totalPrice += house.Price;
            }

            // show average price and total houses selected
            numberOfTransaction = selectedHouses.Count();
            if (numberOfTransaction > 0)
                averagePrice = selectedHouses.Average(p => p.Price);
            else
                averagePrice = 0;

            labelSelectedCountOutput.Text = numberOfTransaction.ToString();
            labelSelectedAveragePriceOutput.Text = averagePrice.ToString("C2");

        }

        /// <summary>
        /// initialsize listboxes(city, bedrooms, bathrooms and house type
        /// </summary>
        public void InitializeAllListControls()
        {
            listBoxCities.Items.Clear();
            listBoxBedrooms.Items.Clear();
            listBoxBathrooms.Items.Clear();
            listBoxHouseTypes.Items.Clear();

            
            listBoxCities.SelectionMode = SelectionMode.MultiExtended;
            listBoxBedrooms.SelectionMode = SelectionMode.MultiExtended;
            listBoxBathrooms.SelectionMode = SelectionMode.MultiExtended;
            listBoxHouseTypes.SelectionMode = SelectionMode.MultiExtended;

            // Linq to get list for each list boxes
            var cities = from house in houseList
                         orderby house.City
                         select house.City;
            
            var houseType = from house in houseList
                         orderby house.HouseType
                         select house.HouseType;
            
            Object[] bedrooms = new Object[9];
            Object[] bathrooms = new Object[6];
            for (int i = 0; i < 9; i++)
                bedrooms[i] =  i;
            for (int i = 0; i <6; i++)
                bathrooms[i] = i;
            
            // Add items to list boxes
            listBoxCities.Items.AddRange(cities.Distinct().ToArray());
            //Select All items
            for (int i = 0; i < listBoxCities.Items.Count; i++)
            {
                listBoxCities.SetSelected(i, true);
            }          
            //Subscribe the event handler
            listBoxCities.SelectedIndexChanged += ListBoxCities_SelectedIndexChanged;

            listBoxBedrooms.Items.AddRange(bedrooms);
            //Select All items
            for (int i = 0; i < listBoxBedrooms.Items.Count; i++)
            {
                listBoxBedrooms.SetSelected(i, true);
            }
            //Subscribe the event handler
            listBoxBedrooms.SelectedIndexChanged += ListBoxBedrooms_SelectedIndexChanged;

            listBoxBathrooms.Items.AddRange(bathrooms);

            //Select All items
            for (int i = 0; i < listBoxBathrooms.Items.Count; i++)
            {
                listBoxBathrooms.SetSelected(i, true);
            }
            //Subscribe the event handler
            listBoxBathrooms.SelectedIndexChanged += ListBoxBathrooms_SelectedIndexChanged;

            listBoxHouseTypes.Items.AddRange(houseType.Distinct().ToArray());
            //Select All items
            for (int i = 0; i < listBoxHouseTypes.Items.Count; i++)
            {
                listBoxHouseTypes.SetSelected(i, true);
            }
            //Subscribe the event handler
            listBoxHouseTypes.SelectedIndexChanged += ListBoxHouseTypes_SelectedIndexChanged;
        } // Done
        
        /// <summary>
        /// Initialize the datagridview controls.
        /// </summary>
        public void InitializeDataGridViewRentalHousing()
        {
            // setting up graidView controls

            // all transaction grid view. 
            dataGridViewAllTransactions.ReadOnly = true;
            dataGridViewAllTransactions.AllowUserToAddRows = false;
            dataGridViewAllTransactions.AllowUserToDeleteRows = false;
            dataGridViewAllTransactions.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            //dataGridViewAllTransactions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewAllTransactions.RowHeadersWidth = 30;
            dataGridViewAllTransactions.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewAllTransactions.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
           

            // selected transaction grid view. 
            dataGridViewSelectedTransactions.ReadOnly = true;
            dataGridViewSelectedTransactions.AllowUserToAddRows = false;
            dataGridViewSelectedTransactions.AllowUserToDeleteRows = false;
            dataGridViewSelectedTransactions.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridViewSelectedTransactions.RowHeadersWidth = 30;
            dataGridViewSelectedTransactions.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewSelectedTransactions.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            
            // clear columns 
            dataGridViewAllTransactions.Columns.Clear();
            dataGridViewSelectedTransactions.Columns.Clear();

            // Set GrideView column header using house class property 
            DataGridViewTextBoxColumn[] columns1 = new DataGridViewTextBoxColumn[] {
                new DataGridViewTextBoxColumn() { Name = "City"},
                new DataGridViewTextBoxColumn() { Name = "Address"},
                new DataGridViewTextBoxColumn() { Name = "Bedrooms" },
                new DataGridViewTextBoxColumn() { Name = "Bathrooms" },
                new DataGridViewTextBoxColumn() { Name = "Surface Area" },
                new DataGridViewTextBoxColumn() { Name = "House Type" },
                new DataGridViewTextBoxColumn() { Name = "Price" },
                };

            DataGridViewTextBoxColumn[] columns2 = new DataGridViewTextBoxColumn[] {
                new DataGridViewTextBoxColumn() { Name = "City" },
                new DataGridViewTextBoxColumn() { Name = "Address" },
                new DataGridViewTextBoxColumn() { Name = "Bedrooms" },
                new DataGridViewTextBoxColumn() { Name = "Bathrooms" },
                new DataGridViewTextBoxColumn() { Name = "Surface Area" },
                new DataGridViewTextBoxColumn() { Name = "House Type" },
                new DataGridViewTextBoxColumn() { Name = "Price" },
                };


            dataGridViewAllTransactions.Columns.AddRange(columns1);
            dataGridViewSelectedTransactions.Columns.AddRange(columns2);
        } 

        /// <summary>
        /// prompt the user for a file, then read the xml file to get all RealEstateTransactions 
        /// </summary>
        private void GetRealEstateTransactionFromXML()
        {
            // Displays an OpenFileDialog so the user can select a XML file  
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "XML Files (*.xml)|*.xml";
            openFileDialog.Title = "Select a XML File";

            // if user click OK button, read the xml file
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // read xml file 
                try
                {
                    // openFileDialog.FileName is the file user selected
                    StreamReader transactionFile = new StreamReader(openFileDialog.FileName);
                    // create the serializer
                    XmlSerializer realEsatateTransactionSerializer = new XmlSerializer(typeof(List<House>));

                    // deserialize to the list
                    houseList = realEsatateTransactionSerializer.Deserialize(transactionFile) as List<House>;
                    // close the file
                    transactionFile.Close();
                }
                catch (Exception e)
                {
                    // If cannot read file, catch the exception
                    Console.WriteLine("Cannot read the xml file, error message: " + e);
                }
            }
            
        }
        
    }

    /// <summary>
    /// Class for House
    /// </summary>
    /// 
    [Serializable]
    public class House
    {
        public string Address { get; set; }
        public string City { get; set; }
        public string HouseType { get; set; }
        public int SurfaceArea { get; set; }
        public double Price { get; set; }
        public int Bedrooms { get; set; }
        public int Bathrooms { get; set; }

        // just put toString method for testing
        public override string ToString()
        {
            return $"{Address},{City},{HouseType},{SurfaceArea},{Price},{Bedrooms},{Bathrooms}";
        }
    }

}
