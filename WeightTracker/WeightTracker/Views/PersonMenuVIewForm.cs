using System;
using System.Windows.Forms;
using WeightTracker.Utilities;
using WeightTrackerLibrary.Models;

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

        private void 
    }
}
