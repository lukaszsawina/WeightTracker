using System;
using System.Windows.Forms;
using WeightTracker.Utilities;
using WeightTrackerLibrary.Models;
using System.Linq;
using System.Collections.Generic;

namespace WeightTracker.Views
{
    public partial class PersonMenuViewForm : Form
    {
        private IPersonModel _currentPerson;
        private Form _personViewForm;
        private IValidator _validator;

        public PersonMenuViewForm(IPersonModel selectedPerson, IValidator validator, Form personViewForm)
        {
            _currentPerson = selectedPerson;
            _validator = validator;
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

            SetCategory();
            BMIValueLabel.Text = BMICalculation().ToString();
        }

        private void ReturnButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            _personViewForm.Show();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (NewWeightTextBox.Text.Length == 0)
                return;

            try
            {
                _validator.NewWeightValid(_currentPerson.WeightRecords.Count + 1, NewWeightTextBox.Text);
                var newWeight = new WeightModel(_currentPerson.WeightRecords.Count + 1, float.Parse(NewWeightTextBox.Text));
                _currentPerson.WeightRecords.Add(newWeight);
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

            Category.Add(16.0f, "Wygłodzenie");
            Category.Add(16.99f, "Wychudzenie");
            Category.Add(18.49f, "Niedowaga");
            Category.Add(24.99f, "Dobra masa ciała");
            Category.Add(29.99f, "Nadwaga");
            Category.Add(34.99f, "Otyłość I stopnia");
            Category.Add(39.99f, "Otyłość II stopnia");

            float BMI = BMICalculation();

            if (BMI < 40.0f)
                WhatMeansLabel.Text = Category.Where(x => BMI <= x.Key).Select(x => x.Value).FirstOrDefault();
            else
                WhatMeansLabel.Text = "Otyłość III stopnia";
        }

    }
}
