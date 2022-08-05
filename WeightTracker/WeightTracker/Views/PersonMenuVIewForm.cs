using System;
using System.Windows.Forms;
using WeightTracker.Utilities;
using WeightTrackerLibrary.Models;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeightTracker.Controller;
using FluentValidation;

namespace WeightTracker.Views
{
    public partial class PersonMenuViewForm : Form, IPersonMenuViewForm
    {
        private IPersonModel _currentPerson;
        private Form _personViewForm;
        private IValidator<IWeightModel> _weightValidator;
        private IAccessor _access;
        private IBMICalculatior _bmiCalculatior;
        private IChangePersonDataViewForm _changePersonDataViewForm;

        public PersonMenuViewForm(IValidator<IWeightModel> weightValidator, IAccessor accessor, IBMICalculatior bmiCalculatior, IChangePersonDataViewForm changePersonDataView)
        {
            InitializeController(weightValidator, accessor, bmiCalculatior, changePersonDataView);
            InitializeComponent();
        }
        private void InitializeController(IValidator<IWeightModel> weightValidator, IAccessor accessor, IBMICalculatior bmiCalculatior, IChangePersonDataViewForm changePersonDataView)
        {
            _weightValidator = weightValidator;
            _access = accessor;
            _bmiCalculatior = bmiCalculatior;
            _changePersonDataViewForm = changePersonDataView; 
        }
        public void InitializeData()
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
        public void SetUpMenuForm(IPersonModel person, Form personsForm)
        {
            _currentPerson = person;
            _personViewForm = personsForm;
            InitializeData();
            WireUp();
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
                ValidateWeightInput();
                await Task.Run(() => AddNewWeightToListAndStorageAsync());
                WireUp();
                ErrorLabelsReset();
            }
            catch (Exception ex)
            {
                ErrorInputLabel.Text = ex.Message;
            }
        }
        private void ValidateWeightInput()
        {
            WeightModel weight = new WeightModel();
            weight.Weight = float.Parse(NewWeightTextBox.Text);

            var results = _weightValidator.Validate(weight);
            if (!results.IsValid)
                foreach (var e in results.Errors)
                    throw new Exception(e.ErrorMessage);
        }
        private async Task AddNewWeightToListAndStorageAsync()
        {
            await SaveNewWeightAsync();
        }
        public async Task SaveNewWeightAsync()
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
            await DeleteWeightAsync();
            WireUp();
        }
        public async Task DeleteWeightAsync()
        {
            IWeightModel weightToDelete = (WeightModel)WeightsListBox.SelectedItem;
            await Task.Run(() => _access.DeleteWeightAsync(weightToDelete.Id));
            _currentPerson.WeightRecords.Remove(weightToDelete);
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
            var changeForm = (Form)_changePersonDataViewForm;
            _changePersonDataViewForm.SetUpChangeForm(_currentPerson, this);
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
