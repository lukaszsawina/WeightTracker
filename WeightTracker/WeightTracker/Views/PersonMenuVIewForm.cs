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
using WeightTrackerLibrary.Models;

namespace WeightTracker.Views
{
    public partial class PersonMenuVIewForm : Form
    {
        private IPersonModel _currentPerson;
        private IFileAccessor _fileAccess;

        public PersonMenuVIewForm(IPersonModel selectedPerson, IFileAccessor fileAccessor)
        {
            _currentPerson = selectedPerson;
            _fileAccess = fileAccessor;
            InitializeComponent();
        }
    }
}
