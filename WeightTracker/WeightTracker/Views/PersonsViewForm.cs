using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeightTracker.Controller;
using WeightTracker.Utilities;
using WeightTracker.Views;
using WeightTrackerLibrary.Models;

namespace WeightTracker
{
    public partial class PersonsViewForm : Form
    {
        private int newId { get; set; }
        private string name { get; set; }
        private string age { get; set; }
        private string height { get; set; }


        private IValidator _validator;
        private IAccessor _access;
        private List<IPersonModel> PersonRecords = new List<IPersonModel>();

        public PersonsViewForm(IAccessor fileAccess, IValidator validator)
        {
            InitializeComponent();
            InitializeController(fileAccess, validator);
            InitializeData();
        }
        private void InitializeController(IAccessor fileAccess, IValidator validator)
        {
            _access = fileAccess;
            _validator = validator;
        }
        public async void InitializeData()
        {
            int progresValue = 0;
            var progress = new Progress<int>(percent =>
            {
                LoadDataProgressBar.Value = percent;
                progresValue = percent;
            });

            await Task.Run(() => _access.LoadPersonAsync(PersonRecords, progress));

            if (progresValue == 100)
                LoadDataProgressBar.Visible = false;

            WireUp();
        }
        private void WireUp()
        {
            PersonListBox.DataSource = null;
            PersonListBox.DataSource = PersonRecords;
            PersonListBox.DisplayMember = "FullName";
        }
        private async void NewPersonAddButton_Click(object sender, EventArgs e)
        {
            try
            {
                ReadDataFromFields();
                _validator.NewPersonValid(newId, name, age, height);
                await Task.Run(() => AddNewPersonToListAndStorageAsync());
                WireUp();
                ClearInputs();
            }
            catch (Exception ex)
            {
                ErrorInputLabel.Text = ex.Message;
            }
        }
        private void ReadDataFromFields()
        {
            newId = PersonRecords.Count + 1;
            name = NameTextBox.Text;
            age = AgeTextBox.Text;
            height = HeightTextBox.Text;
        }
        private async Task AddNewPersonToListAndStorageAsync()
        {
            IPersonModel newPerson = new PersonModel(newId, name, Int32.Parse(age), Int32.Parse(height));
            PersonRecords.Add(newPerson);
            await Task.Run(() => _access.SaveNewPersonAsync(newPerson));
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
        private void SelectPersonButton_Click(object sender, EventArgs e)
        {
            var personMenuForm = new PersonMenuViewForm((PersonModel)PersonListBox.SelectedItem, _validator, _access, this);
            SwitchForms(personMenuForm);
        }
        private void SwitchForms(Form formToShow)
        {
            this.Hide();
            formToShow.Show();
        }
        private void PersonListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectPersonButton.Enabled = PersonListBox.SelectedItems.Count == 0 ? false : true;
        }

        private void PersonsViewForm_Activated(object sender, EventArgs e)
        {
            WireUp();
        }
    }
}