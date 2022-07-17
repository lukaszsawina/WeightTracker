using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WeightTracker.Utilities;
using WeightTrackerLibrary.Models;

namespace WeightTracker
{
    public partial class PersonsViewForm : Form
    {
        private IValidator _validator;
        private List<IPersonModel> PersonRecords = new List<IPersonModel>();

        public void InitializeDemoData()
        {
            PersonRecords.Add(new PersonModel(1, "Adam", 19, 183));
            PersonRecords.Add(new PersonModel(2, "Jan", 30, 179));
        }
        public PersonsViewForm(IValidator validator)
        {
            _validator = validator;

            InitializeComponent();
            InitializeDemoData();
            WireUp();
        } 
        private void WireUp()
        {
            PersonListBox.DataSource = null;
            PersonListBox.DataSource = PersonRecords;
            PersonListBox.DisplayMember = "FullName";
        }
        private void ClearNewPersonFormButton_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }
        private void ClearInputs()
        {
            NameTextBox.Text = "";
            AgeTextBox.Text = "";
            HeightTextBox.Text = "";
            ErrorInputLabel.Text = "";
        }
        private void NewPersonAddButton_Click(object sender, EventArgs e)
        {
            try
            {
                int newId = PersonRecords.Count + 1;
                string name = NameTextBox.Text;
                string age = AgeTextBox.Text;
                string height = HeightTextBox.Text;

                _validator.NewPersonValid(newId, name, age, height);
                IPersonModel newPerson = new PersonModel(newId, name, Int32.Parse(age), Int32.Parse(height));
                PersonRecords.Add(newPerson);

                WireUp();
                ClearInputs();
            }
            catch(Exception ex)
            {
                ErrorInputLabel.Text = ex.Message;
            }
        }        
    }
}
