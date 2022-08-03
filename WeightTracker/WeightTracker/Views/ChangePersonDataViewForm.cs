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
        private IValidator _validator;
        private IAccessor _access;

        public ChangePersonDataViewForm(IValidator validator, IAccessor accessor)
        {
            InitializeComponent();
            InitializeController(validator, accessor);
        }
        private void InitializeController(IValidator validator, IAccessor accessor)
        {
            _validator = validator;
            _access = accessor;
        }
        private void InitializeData()
        {
            PersonNameTextBox.Text = _person.Name;
            PersonAgeTextBox.Text = _person.Age.ToString();
            PersonHeightTextBox.Text = _person.Height.ToString();
            ErrorMessageLabel.Text = "";
        }
        public void SetUpChangeForm(IPersonModel person)
        {
            _person = person;
            InitializeData();

        }
        private async void ChangeButton_Click(object sender, EventArgs e)
        {
            try
            {
                _validator.NewPersonValid(_person.Id, PersonNameTextBox.Text, PersonAgeTextBox.Text, PersonHeightTextBox.Text);
                _person.ChangeData(PersonNameTextBox.Text, Int32.Parse(PersonAgeTextBox.Text), Int32.Parse(PersonHeightTextBox.Text));
                await Task.Run(() => _access.ChangePersonDataAsync(_person));
                this.Close();
            }
            catch(Exception ex)
            {
                ErrorMessageLabel.Text = ex.Message;
            }
        }
    }
}
