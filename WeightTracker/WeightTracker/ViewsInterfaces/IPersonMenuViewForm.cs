using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeightTracker.Controller;
using WeightTracker.Utilities;
using WeightTrackerLibrary.Models;

namespace WeightTracker.Views
{
    public interface IPersonMenuViewForm
    {
        void InitializeData();
        void SetUpMenuForm(IPersonModel person, Form personsForm);
        Task DeleteWeightAsync();
        Task AddNewWeightToListAndStorageAsync(IWeightModel newWeight);
    }
}
