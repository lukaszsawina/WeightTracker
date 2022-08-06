using FluentValidation;
using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeightTracker.Controller;
using WeightTracker.Utilities;
using WeightTrackerLibrary.Models;

namespace WeightTracker.Views
{
    public partial class ChangePersonDataViewForm : Form, IChangePersonDataViewForm
    {
        private IPersonModel _person;
        private PersonMenuViewForm _personMenuViewForm;
        private IValidator<IPersonModel> _personValidator;
        private IAccessor _access;
        private readonly ILog _log = LogManager.GetLogger(typeof(ChangePersonDataViewForm));

        public ChangePersonDataViewForm(IValidator<IPersonModel> personValidator, IAccessor accessor)
        {
            InitializeComponent();
            InitializeController(personValidator, accessor);
        }
        private void InitializeController(IValidator<IPersonModel> personValidator, IAccessor accessor)
        {
            _personValidator = personValidator;
            _access = accessor;
        }
        private void InitializeData()
        {
            PersonNameTextBox.Text = _person.Name;
            PersonAgeTextBox.Text = _person.Age.ToString();
            PersonHeightTextBox.Text = _person.Height.ToString();
            ErrorMessageLabel.Text = "";
        }
        public void SetUpChangeForm(IPersonModel person, PersonMenuViewForm personMenuView)
        {
            _personMenuViewForm = personMenuView;
            _person = person;

            InitializeData();
        }
        private async void ChangeButton_Click(object sender, EventArgs e)
        {
            await SaveChangesAsync();
        }
        public async Task SaveChangesAsync()
        {
            try
            {
                ValidatePersonInputs();
                _person.ChangeData(PersonNameTextBox.Text, Int32.Parse(PersonAgeTextBox.Text), Int32.Parse(PersonHeightTextBox.Text));
                await Task.Run(() => _access.ChangePersonDataAsync(_person));
                HideForm();
                _log.Info("Person data was changed");
            }
            catch (Exception ex)
            {
                ErrorMessageLabel.Text = ex.Message;
                _log.Error("Exception occurred", ex);
            }
        }
        private void ValidatePersonInputs()
        {
            if (!IsAValidDigit(PersonAgeTextBox.Text))
            {
                throw new Exception("Age is not a digit");
            }
            else if (!IsAValidDigit(PersonHeightTextBox.Text))
            {
                throw new Exception("Height is not a digit");
            }

            PersonModel person = new PersonModel();
            person.Name = PersonNameTextBox.Text;
            person.Age = Int32.Parse(PersonAgeTextBox.Text);
            person.Height = Int32.Parse(PersonHeightTextBox.Text);
            person.Id = _person.Id;

            var results = _personValidator.Validate(person);

            if (!results.IsValid)
            {
                foreach (var e in results.Errors)
                    throw new Exception(e.ErrorMessage);
            }
        }
        private bool IsAValidDigit(string number)
        {
            number = number.Replace(" ", "");
            return number.All(Char.IsDigit);
        }

        private void ReturnButton_Click(object sender, EventArgs e)
        {
            HideForm();
        }
        private void HideForm()
        {
            this.Hide();
            _personMenuViewForm.Show();
            _personMenuViewForm.InitializeData();
        }
    }
}
