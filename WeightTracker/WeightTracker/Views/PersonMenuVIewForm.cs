using System;
using System.Windows.Forms;
using WeightTracker.Utilities;
using WeightTrackerLibrary.Models;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeightTracker.Controller;

namespace WeightTracker.Views
{
    public partial class PersonMenuViewForm : Form
    {
        private IPersonModel _currentPerson;
        private Form _personViewForm;
        private IValidator _validator;
        private IAccessor _access;

        public PersonMenuViewForm(IPersonModel selectedPerson, IValidator validator, IAccessor accessor, Form personViewForm)
        {
            InitializeController(selectedPerson, validator, accessor, personViewForm);
            InitializeComponent();
            InitializeData();
            WireUp();
        }

        private void InitializeController(IPersonModel selectedPerson, IValidator validator, IAccessor accessor, Form personViewForm)
        {
            _currentPerson = selectedPerson;
            _validator = validator;
            _access = accessor;
            _personViewForm = personViewForm;
        }
        private void InitializeData()
        {
            PersonNameLabel.Text = _currentPerson.Name;
            AgeLabel.Text = _currentPerson.Age.ToString();
            HeightLabel.Text = _currentPerson.Height.ToString();
            ErrorLabelsReset();
        }

        private void WireUp()
        {
            WeightsListBox.DataSource = null;
            WeightsListBox.DataSource = _currentPerson.WeightRecords;
            WeightsListBox.DisplayMember = "WeightData";
            BMIWireUp();
        }

        private void BMIWireUp()
        {
            if (_currentPerson.WeightRecords.Count == 0)
            {
                BMIValueLabel.Text = "No data";
                WhatMeansLabel.Text = "No data";
            }
            else
            {
                SetCategory();
                BMIValueLabel.Text = Math.Round((double)BMICalculation(), 2).ToString();
            }
        }
        private float BMICalculation()
        {
            float output = _currentPerson.WeightRecords.OrderByDescending(t => t.DateWhenAdd).Select(x => x.Weight).FirstOrDefault() / (_currentPerson.Height * _currentPerson.Height / 10000);
            return output;
        }
        private void SetCategory()
        {
            IDictionary<float, string> Category = CreateDictionary();
            float BMI = BMICalculation();
            WhatMeansLabel.Text = BMI < 40.0f ? Category.Where(x => BMI <= x.Key).Select(x => x.Value).FirstOrDefault() : WhatMeansLabel.Text = "Obese (Class III)";
        }
        private IDictionary<float, string> CreateDictionary()
        {
            IDictionary<float, string> output = new Dictionary<float, string>();

            output.Add(16.0f, "Underweight (Severe thinness)");
            output.Add(16.99f, "Underweight (Moderate thinness)");
            output.Add(18.49f, "Underweight (Mild thinness)");
            output.Add(24.99f, "Normal range");
            output.Add(29.99f, "Overweight (Pre-obese)");
            output.Add(34.99f, "Obese (Class I)");
            output.Add(39.99f, "Obese (Class II)");

            return output;
        }
        private async void AddButton_Click(object sender, EventArgs e)
        {
            if (NewWeightTextBox.Text.Length == 0)
                return;

            try
            {
                _validator.NewWeightValid(_currentPerson.WeightRecords.Count + 1, NewWeightTextBox.Text);
                await Task.Run(() => AddNewWeightToListAndStorageAsync());
                WireUp();
                ErrorLabelsReset();
            }
            catch (Exception ex)
            {
                ErrorInputLabel.Text = ex.Message;
            }
        }
        private async Task AddNewWeightToListAndStorageAsync()
        {
            var newWeight = new WeightModel(_currentPerson.WeightRecords.Count + 1, float.Parse(NewWeightTextBox.Text));
            _currentPerson.WeightRecords.Add(newWeight);
            await Task.Run(() => _access.SaveNewWeightAsync(_currentPerson.Id, newWeight));
        }
        private void ErrorLabelsReset()
        {
            ErrorInputLabel.Text = "";
            NewWeightTextBox.Text = "";
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            IWeightModel weightToDelete = (WeightModel)WeightsListBox.SelectedItem;
            await Task.Run(() => _access.DeleteWeightAsync(weightToDelete.Id));
            _currentPerson.WeightRecords.Remove(weightToDelete);
            WireUp();
        }

        private void PersonMenuViewForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _personViewForm.Close();
        }        
        private void WeightsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            RemoveButton.Enabled = WeightsListBox.SelectedItems.Count == 0 ? false : true;
        }
        private void ChangeButton_Click(object sender, EventArgs e)
        {
            var changeForm = new ChangePersonDataViewForm(_validator, _currentPerson, _access);
            changeForm.Show();
        }
        private void PersonMenuViewForm_Activated(object sender, EventArgs e)
        {
            WireUp();
        }
        private void ReturnButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            _personViewForm.Show();
        }
    }
}
