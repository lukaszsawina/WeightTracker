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
            _currentPerson = selectedPerson;
            _validator = validator;
            _access = accessor;
            _personViewForm = personViewForm;

            InitializeComponent();
            InitializeData();
            WireUp();
        }
        
        private void InitializeData()
        {
            PersonNameLabel.Text = _currentPerson.Name;
            AgeLabel.Text = _currentPerson.Age.ToString();
            HeightLabel.Text = _currentPerson.Height.ToString();

            ErrorInputLabel.Text = "";
        }

        private void WireUp()
        {
            WeightsListBox.DataSource = null;
            WeightsListBox.DataSource = _currentPerson.WeightRecords;
            WeightsListBox.DisplayMember = "WeightData";
           

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

        private void ReturnButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            _personViewForm.Show();
        }

        private async void AddButton_Click(object sender, EventArgs e)
        {
            if (NewWeightTextBox.Text.Length == 0)
                return;

            try
            {
                _validator.NewWeightValid(_currentPerson.WeightRecords.Count + 1, NewWeightTextBox.Text);
                var newWeight = new WeightModel(_currentPerson.WeightRecords.Count + 1, float.Parse(NewWeightTextBox.Text));
                _currentPerson.WeightRecords.Add(newWeight);
                await Task.Run(() => _access.SaveNewWeightAsync(_currentPerson.Id, newWeight));
                WireUp();
                ErrorInputLabel.Text = "";
                NewWeightTextBox.Text = "";
            }
            catch (Exception ex)
            {
                ErrorInputLabel.Text = ex.Message;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _currentPerson.WeightRecords.Remove((WeightModel)WeightsListBox.SelectedItem);
            WireUp();
        }

        private void PersonMenuViewForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _personViewForm.Close();
        }

        private float BMICalculation()
        {
            float output = _currentPerson.WeightRecords.OrderByDescending(t => t.DateWhenAdd).Select(x => x.Weight).FirstOrDefault()/(_currentPerson.Height*_currentPerson.Height/10000);
            return output;
        }

        private void SetCategory()
        {
            IDictionary<float, string> Category = new Dictionary<float, string>();

            Category.Add(16.0f, "Underweight (Severe thinness)");
            Category.Add(16.99f, "Underweight (Moderate thinness)");
            Category.Add(18.49f, "Underweight (Mild thinness)");
            Category.Add(24.99f, "Normal range");
            Category.Add(29.99f, "Overweight (Pre-obese)");
            Category.Add(34.99f, "Obese (Class I)");
            Category.Add(39.99f, "Obese (Class II)");

            float BMI = BMICalculation();

            if (BMI < 40.0f)
                WhatMeansLabel.Text = Category.Where(x => BMI <= x.Key).Select(x => x.Value).FirstOrDefault();
            else
                WhatMeansLabel.Text = "Obese (Class III)";
        }

        private void WeightsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (WeightsListBox.SelectedItems.Count == 0)
                RemoveButton.Enabled = false;
            else
                RemoveButton.Enabled = true;
        }

        private void ChangeButton_Click(object sender, EventArgs e)
        {
            var changeForm = new ChangePersonDataViewForm(_validator, _currentPerson);
            changeForm.Show();
        }

        private void PersonMenuViewForm_Activated(object sender, EventArgs e)
        {
            WireUp();
        }
    }
}
