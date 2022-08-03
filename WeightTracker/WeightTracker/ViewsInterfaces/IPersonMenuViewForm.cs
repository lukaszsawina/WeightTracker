using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeightTrackerLibrary.Models;

namespace WeightTracker.Views
{
    public interface IPersonMenuViewForm
    {
        void SetUpMenuForm(IPersonModel person, Form personsForm);
    }
}
