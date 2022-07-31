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
        private IValidator _validator;
        private IAccessor _access;
        private List<IPersonModel> PersonRecords = new List<IPersonModel>();

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
        public PersonsViewForm(IAccessor fileAccess, IValidator validator)
        {
            _access = fileAccess;
            _validator = validator;

            InitializeComponent();
            InitializeData();
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
        private async void NewPersonAddButton_Click(object sender, EventArgs e)
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

                await Task.Run(() => _access.SaveNewPersonAsync(newPerson));

                WireUp();
                ClearInputs();
            }
            catch (Exception ex)
            {
                ErrorInputLabel.Text = ex.Message;
            }
        }
        private void PersonsViewForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (e.CloseReason == CloseReason.UserClosing)
            //    SaveOnClose();

            //if (e.CloseReason == CloseReason.WindowsShutDown)
            //    SaveOnClose();
        }

        public async void SaveOnClose()
        {
            //await Task.Run(() => _access.S(PersonRecords));
        }

        private void SelectPersonButton_Click(object sender, EventArgs e)
        {
            var personMenuForm = new PersonMenuViewForm((PersonModel)PersonListBox.SelectedItem, _validator, _access, this);
            this.Hide();
            personMenuForm.Show();
        }

        private void PersonListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PersonListBox.SelectedItems.Count == 0)
                SelectPersonButton.Enabled = false;
            else
                SelectPersonButton.Enabled = true;

        }
    }
}