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
    public partial class ChangePersonDataViewForm : Form
    {
        private IPersonModel _person;
        private IValidator _validator;
        private IAccessor _access;

        public ChangePersonDataViewForm(IValidator validator, IPersonModel person, IAccessor accessor)
        {
            InitializeComponent();
            InitializeController(validator, person, accessor);
            InitializeData();
        }
        private void InitializeController(IValidator validator, IPersonModel person, IAccessor accessor)
        {
            _validator = validator;
            _person = person;
            _access = accessor;
        }
        private void InitializeData()
        {
            PersonNameTextBox.Text = _person.Name;
            PersonAgeTextBox.Text = _person.Age.ToString();
            PersonHeightTextBox.Text = _person.Height.ToString();
            ErrorMessageLabel.Text = "";
        }

        private async void ChangeButton_Click(object sender, EventArgs e)
        {
            try
            {
                _validator.NewPersonValid(_person.Id, PersonNameTextBox.Text, PersonAgeTextBox.Text, PersonHeightTextBox.Text);
                _person.ChangeData(PersonNameTextBox.Text, Int32.Parse(PersonAgeTextBox.Text), Int32.Parse(PersonHeightTextBox.Text));
                await Task.Run(() => _access.ChangePersonData(_person));
                this.Close();
            }
            catch(Exception ex)
            {
                ErrorMessageLabel.Text = ex.Message;
            }
        }
    }
}
