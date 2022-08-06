using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeightTracker.Controller;
using WeightTracker.Utilities;
using WeightTracker.Views;
using log4net;
using WeightTrackerLibrary.Models;

namespace WeightTracker
{
    public partial class PersonsViewForm : Form, IPersonsViewForm
    {
        private int newId { get; set; }
        private string name { get; set; }
        private string age { get; set; }
        private string height { get; set; }


        private IValidator<IPersonModel> _personValidator;
        private IAccessor _access;
        private IBMICalculatior _bmiCalculator;
        private IPersonMenuViewForm _personMenuViewForm;
        private static readonly ILog _log = LogManager.GetLogger(typeof(PersonsViewForm));

        private List<IPersonModel> PersonRecords = new List<IPersonModel>();

        public PersonsViewForm(IAccessor fileAccess, IValidator<IPersonModel> personValidator, IBMICalculatior bmiCalculator, IPersonMenuViewForm personMenuViewForm)
        {
            InitializeComponent();
            InitializeController(fileAccess, personValidator, bmiCalculator, personMenuViewForm);
            InitializeData();
            _log.Info("App starts");
        }
        private void InitializeController(IAccessor fileAccess, IValidator<IPersonModel> personValidator, IBMICalculatior bmiCalculator, IPersonMenuViewForm personMenuViewForm)
        {
            _access = fileAccess;
            _personValidator = personValidator;
            _bmiCalculator = bmiCalculator;
            _personMenuViewForm = personMenuViewForm;
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
            await SaveNewPersonAsync();
        }
        public async Task SaveNewPersonAsync()
        {
            try
            {
                ReadDataFromFields();
                ValidatePersonInputs();
                await Task.Run(() => AddNewPersonToListAndStorageAsync());
                WireUp();
                ClearInputs();
                _log.Info("New person was added to storage");
            }
            catch (Exception ex)
            {
                ErrorInputLabel.Text = ex.Message;
                _log.Error("Exception occurred", ex);
            }
        }
        private void ValidatePersonInputs()
        {
            if (!IsAValidDigit(age))
            {
                throw new Exception("Age is not a digit");
            }
            else if(!IsAValidDigit(height))
            {
                throw new Exception("Height is not a digit");
            }

            PersonModel person = new PersonModel();
            person.Name = name;
            person.Age = Int32.Parse(age);
            person.Height = Int32.Parse(height);
            person.Id = newId;

            var results = _personValidator.Validate(person);

            if (!results.IsValid)
            {
                foreach(var e in results.Errors)
                    throw new Exception(e.ErrorMessage);
            }
        }
        private bool IsAValidDigit(string number)
        {
            number = number.Replace(" ", "");
            return number.All(Char.IsDigit);
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
            var personMenuForm = _personMenuViewForm;
            var selectedPerson = (IPersonModel)PersonListBox.SelectedItem;
            _personMenuViewForm.SetUpMenuForm(selectedPerson, (Form)this);
            SwitchForms((Form)personMenuForm);
            _log.Info($"Person { selectedPerson.FullName } was selected");
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