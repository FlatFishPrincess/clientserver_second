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

            // Display all real estate transaction
            DisplayAllRealEsatateTransactions();
            ResetControlsToDefault();
            // Display selected Transaction
            DisplaySelectedTransactions();
            // TODO: get selected transcation using filter
            // TODO: text box validation or any error handling
            // TODO: reset filter button
            // I left reset button cuz it might be more complicating if I put some parts of code.
            buttonResetFilters.Click += ButtonResetFilters_Click;
        }

        private void ButtonResetFilters_Click(object sender, EventArgs e)
        {
            ResetControlsToDefault();
        }
        private void ListBoxCities_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
        private void ListBoxHouseTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void ListBoxBathrooms_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void ListBoxBedrooms_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        /// <summary>
        /// Reset Control to default
        /// </summary>
        private void ResetControlsToDefault()
        {
            
            // set true to all list boxes
            for (int i = 0; i < listBoxCities.Items.Count; i++)
            {
                listBoxCities.SetSelected(i, true);
            }
            for (int i = 0; i < listBoxBedrooms.Items.Count; i++)
            {
                listBoxBedrooms.SetSelected(i, true);
            }
            for (int i = 0; i < listBoxBathrooms.Items.Count; i++)
            {
                listBoxBathrooms.SetSelected(i, true);
            }
            for (int i = 0; i < listBoxHouseTypes.Items.Count; i++)
            {
                listBoxHouseTypes.SetSelected(i, true);
            }

            textBoxPriceMin.Clear();
            textBoxPriceMax.Clear();
            surfaceMinTxt.Clear();
            surfaceMaxTxt.Clear();

        }

        public void DisplaySelectedTransactions()
        {
            // list storing selected items
            List<string> selectedCity = new List<string>();
            List<string> selectedBedrooms = new List<string>();
            List<string> selectedBathrooms = new List<string>();
            List<string> selectedTypes = new List<string>();
            int x = 0;
            // store selected items from lists
            for (int i = 0; i < listBoxCities.SelectedItems.Count; i++)
            {
                selectedCity.Add(listBoxCities.SelectedItems[i].ToString());
            }
            for(int j = 0; j < listBoxBedrooms.SelectedItems.Count; j++)
            {
                selectedBedrooms.Add(listBoxBedrooms.SelectedItems[j].ToString());
            }
            for (int i = 0; i < listBoxBathrooms.SelectedItems.Count; i++)
            {
                selectedBathrooms.Add(listBoxBathrooms.SelectedItems[i].ToString());
            }
            for (int i = 0; i < listBoxHouseTypes.SelectedItems.Count; i++)
            {
                selectedTypes.Add(listBoxHouseTypes.SelectedItems[i].ToString());
            }

            // dataGridViewSelectedTransactions
            Console.WriteLine(selectedCity);
            Expression<Func<House, bool>> expression = p => selectedCity.Contains(p.City) &&
                                                          selectedBedrooms.Contains(p.Bedrooms.ToString()) &&
                                                          selectedBathrooms.Contains(p.Bathrooms.ToString()) &&
                                                          selectedTypes.Contains(p.HouseType); 

            var selectedHouses = houseList.Where(expression.Compile()).OrderBy(p => p.City).ThenBy(p => p.HouseType).ThenBy(p => p.Price);
            Console.WriteLine(selectedHouses);
            double totalSelectedPrice = 0;
            /*foreach(House house in selectedItems)
            {
                dataGridViewAllTransactions.Rows.Add(house.City, house.Address,
                                house.Bedrooms, house.Bathrooms, house.SurfaceArea, house.HouseType, house.Price);
                totalSelectedPrice += house.Price;
            }
            labelSelectedCountOutput.Text = selectedItems.Count().ToString();
            labelSelectedAveragePriceOutput.Text = totalSelectedPrice.ToString();*/

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
        /// initialsize listboxes(city, bedrooms, bathrooms and house type
        /// </summary>
        public void InitializeAllListControls()
        {
            listBoxCities.Items.Clear();
            listBoxBedrooms.Items.Clear();
            listBoxBathrooms.Items.Clear();
            listBoxHouseTypes.Items.Clear();

            listBoxCities.SelectedIndexChanged += ListBoxCities_SelectedIndexChanged;
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
            listBoxBedrooms.Items.AddRange(bedrooms);
            listBoxBathrooms.Items.AddRange(bathrooms);
            listBoxHouseTypes.Items.AddRange(houseType.Distinct().ToArray());
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
                new DataGridViewTextBoxColumn() { Name = "City" },
                new DataGridViewTextBoxColumn() { Name = "Address" },
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
