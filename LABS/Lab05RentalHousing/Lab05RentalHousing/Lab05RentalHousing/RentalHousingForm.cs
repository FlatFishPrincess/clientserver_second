using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Lab05RentalHousing
{
    public partial class RentalHousingForm : Form
    {
        // We keep the list of rental housing here

        List<NewWestminsterRentalHousing> rentalHousingList;
        Boolean isSearchClicked = false;
        public RentalHousingForm()
        {
            InitializeComponent();

            // 

            // load the rentalHousingList from the .xml file
            GetRentalHousingFromXML();

            // initialize the form's controls to default settings

            InitializeDataGridViewRentalHousing();

            InitializeAllOtherFormControls();

            // reset the listbox so neighborhoods are selected,
            // and the textbox is cleared
            ResetControlsToDefault();

            // register event handlers for search button and reset button
            //   use += tab and everything will be set up
            buttonBuildingNameSearch.Click += ButtonBuildingNameSearch_Click;
            buttonReset.Click += ButtonReset_Click;
        }

        // reset button clicked
        private void ButtonReset_Click(object sender, EventArgs e)
        {
            ResetControlsToDefault();
        }

        // search button clicked
        private void ButtonBuildingNameSearch_Click(object sender, EventArgs e)
        {
            isSearchClicked = true;
            DisplayRentalHousing();
        }

        // list selection is changed
        private void ListBoxNeighborhoods_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayRentalHousing();
        }


        /// <summary>
        /// Set all relevant controls to their defaults.
        /// The listbox should have all items selected, and the textbox should be cleared.
        /// 
        /// Note we need to turn off SelectedIndexChanged before we select each listbox entry
        /// or it will trigger the event for EACH selection. A performance hit.
        /// </summary>
        private void ResetControlsToDefault()
        {
            // TASK: unregister the listbox SelectedIndexChanged event
            listBoxNeighborhoods.SelectedIndexChanged -= ListBoxNeighborhoods_SelectedIndexChanged;

            // TASK: add the code to clear the textbox and select all neighborhoods in the listbox
            for (int i = 0; i < listBoxNeighborhoods.Items.Count; i++) // select all neighborhoods
                listBoxNeighborhoods.SetSelected(i, true);

            textBoxBuildingNameSearch.Clear(); // clear text botx

            // now show all of the selected neighborhoods in the datagridview control
            DisplayRentalHousing();

            // TASK: turn on the event handler for the listbox now that we have selected all
            listBoxNeighborhoods.SelectedIndexChanged += ListBoxNeighborhoods_SelectedIndexChanged;

        }
        

        /// <summary>
        /// Initialize settings for the listbox and textbox.
        /// 
        /// Generate a unique list of neighborhoods and add them to the listbox
        /// </summary>
        public void InitializeAllOtherFormControls()
        {
            listBoxNeighborhoods.Items.Clear();
            listBoxNeighborhoods.Width = 200;
            listBoxNeighborhoods.SelectionMode = SelectionMode.MultiExtended;

            // TASK: create LINQ query or methods/lambdas to generate
            // a unique list of neighborhoods from the rentalHousingList
            var houses = from house in rentalHousingList
                        orderby house.Neighborhood, house.BuildingName
                        select house.Neighborhood;

            // then add this list of neighborhoods to the listbox
            listBoxNeighborhoods.Items.AddRange(houses.Distinct().ToArray());
        } // Done

        /// <summary>
        /// Display rental housing according to 
        /// </summary>
        public void DisplayRentalHousing()
        {
            dataGridViewRentalHousing.Rows.Clear(); // clear old data first

            int numberOfApartment;
            int totalNumberOfResidences = 0; // will accumulated for total residences
            string serachInput; // text input for searching building

            // list for storing selected neighborhoods in listbox
            List<string> selectedNeighnorhoods = new List<string>(); 

            //  store selected data
            for (int i = 0; i < listBoxNeighborhoods.SelectedItems.Count; i++)
                selectedNeighnorhoods.Add(listBoxNeighborhoods.SelectedItems[i].ToString());

            // Q. Is there any way not to have if-else statement for checking button clicked or not?
            // check if search button is clicekd, then get houses correspoding building name with text input
            if (isSearchClicked)
            {
                serachInput = (textBoxBuildingNameSearch.Text).ToUpper();
                var searchHouses = from house in rentalHousingList
                                   from neighborhood in selectedNeighnorhoods
                                   where neighborhood == house.Neighborhood
                                     && house.BuildingName.Contains(serachInput)
                                   orderby house.Neighborhood, house.BuildingName
                                   select house;
                foreach (NewWestminsterRentalHousing house in searchHouses)
                {
                    dataGridViewRentalHousing.Rows.Add(house.BuildingId, house.Address,
                                    house.BuildingName, house.NumberOfResidences, house.Neighborhood);
                    totalNumberOfResidences += house.NumberOfResidences;
                }
                isSearchClicked = false;
                numberOfApartment = searchHouses.Count();
            }
            else
            {
                var selectedHouses = from house in rentalHousingList
                                     from neighborhood in selectedNeighnorhoods
                                     where neighborhood == house.Neighborhood
                                     orderby house.Neighborhood, house.BuildingName
                                     select house;

                foreach (NewWestminsterRentalHousing house in selectedHouses)
                {
                    dataGridViewRentalHousing.Rows.Add(house.BuildingId, house.Address,
                                    house.BuildingName, house.NumberOfResidences, house.Neighborhood);
                    totalNumberOfResidences += house.NumberOfResidences;
                }
                numberOfApartment = selectedHouses.Count();
            }

            // show number of apartments and total residences
            labelDisplayNumberOfApartments.Text = numberOfApartment.ToString();
            labelDisplayTotalResidences.Text = totalNumberOfResidences.ToString();

        } // Need to think another way to clean code

        /// <summary>
        /// Initialize the datagridview control.
        /// Set the width, and have the columns autofill.
        /// Set other properties as needed
        /// 
        /// </summary>
        public void InitializeDataGridViewRentalHousing()
        {

            dataGridViewRentalHousing.ReadOnly = true;
            dataGridViewRentalHousing.AllowUserToAddRows = false;
            dataGridViewRentalHousing.RowHeadersVisible = false;
            dataGridViewRentalHousing.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewRentalHousing.Width = 900;
            
            // clear columns first
            dataGridViewRentalHousing.Columns.Clear();

            // Set GrideView column header using housing property name
            foreach (PropertyInfo classProperty in (new NewWestminsterRentalHousing()).GetType().GetProperties())
            {
                DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn()
                {
                    Name = classProperty.Name,
                    ValueType = classProperty.GetType()
                };

                dataGridViewRentalHousing.Columns.Add(column);
            }
        } // Done

        /// <summary>
        /// Use Deserialize to get all RentalHousing from XML file
        /// </summary>
        private void GetRentalHousingFromXML()
        {
            // file source name
            const string FILE_NAME = "NewWestminsterRentalHousing.xml";

            // open the file for reading, if not, exception throws
            try
            {
                StreamReader rentalHouseFile = new StreamReader(FILE_NAME);
                // create the serializer
                XmlSerializer rentalHouserSerializer = new XmlSerializer(typeof(List<NewWestminsterRentalHousing>));

                // deserialize to the list of cars from file, note use of cast
                rentalHousingList = rentalHouserSerializer.Deserialize(rentalHouseFile) as List<NewWestminsterRentalHousing>;
                rentalHouseFile.Close();
            }
            catch (Exception e)
            {
                // If cannot read file, check the xml file property
                Console.WriteLine("Cannot read file, make sure Copy to Output Directory property should be Copy always in xml file");
            }
            Console.WriteLine(rentalHousingList);
        } // Done
        
    }

    /// <summary>
    /// Rental Housing class. Note that it MUST be named NewWestminsterRentalHousing,
    /// as the xml file root is ArrayOfNewWestMinsterRentalHousing, and each element is
    /// NewWestminsterRentalHousing.
    /// 
    /// Do not touch this or the xmlserializer will not work
    /// </summary>
    /// 

    [Serializable]
    public class NewWestminsterRentalHousing
    {
        public string BuildingId { get; set; }
        public string Address { get; set; }
        public string BuildingName { get; set; }
        public int NumberOfResidences { get; set; }
        public string Neighborhood { get; set; }

        public override string ToString()
        {
            return $"{BuildingId},{Address},{BuildingName},{NumberOfResidences},{Neighborhood}";
        }
    }

}
