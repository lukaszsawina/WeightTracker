using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeightTracker.Controller;
using WeightTracker.Utilities;
using WeightTrackerLibrary.Models;

namespace WeightTracker
{
    public partial class PersonsViewForm : Form
    {
        private IValidator _validator;
        private IFileAccessor _fileAccess;
        private List<IPersonModel> PersonRecords = new List<IPersonModel>();

        public async void InitializeData()
        {
            int progresValue = 0;
            var progress = new Progress<int>(percent =>
            {
                LoadDataProgressBar.Value = percent;
                progresValue = percent;
            });

            await Task.Run(() => _fileAccess.LoadPersonFromFileAsync(PersonRecords, progress));
            if (progresValue == 100)
                LoadDataProgressBar.Visible = false;
            WireUp();
        }
        public PersonsViewForm(IFileAccessor fileAccess, IValidator validator)
        {
            _fileAccess = fileAccess;
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
        private async void PersonsViewForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
                await _fileAccess.SavePersonToFileAsync(PersonRecords);


            if (e.CloseReason == CloseReason.WindowsShutDown)
                await _fileAccess.SavePersonToFileAsync(PersonRecords);


        }
    }
}