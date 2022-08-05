using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeightTracker.Views;
using WeightTrackerLibrary.Models;

namespace WeightTracker
{
    public interface IChangePersonDataViewForm
    {
        void SetUpChangeForm(IPersonModel person, PersonMenuViewForm personMenuView);
        Task SaveChangesAsync();
    }
}
