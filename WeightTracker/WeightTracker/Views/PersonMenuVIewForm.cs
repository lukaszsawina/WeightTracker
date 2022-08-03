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
        private IBMICalculatior _bmiCalculatior;
        public PersonMenuViewForm(IPersonModel selectedPerson, IValidator validator, IAccessor accessor, IBMICalculatior bmiCalculatior, Form personViewForm)
        {
            InitializeController(selectedPerson, validator, accessor, bmiCalculatior, personViewForm);
            InitializeComponent();
            InitializeData();
            WireUp();
        }

        private void InitializeController(IPersonModel selectedPerson, IValidator validator, IAccessor accessor, IBMICalculatior bmiCalculatior, Form personViewForm)
        {
            _currentPerson = selectedPerson;
            _validator = validator;
            _access = accessor;
            _personViewForm = personViewForm;
            _bmiCalculatior = bmiCalculatior;
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
                BMIValueLabel.Text = _bmiCalculatior.CalculateBMI(LatestPersonWeight(), _currentPerson.Height).ToString();
                WhatMeansLabel.Text = _bmiCalculatior.MatchCategory();
            }
        }
        private float LatestPersonWeight()
        {
            return _currentPerson.WeightRecords.OrderByDescending(x => x.Id).Select(x => x.Weight).FirstOrDefault();
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
