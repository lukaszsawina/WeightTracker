using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeightTrackerLibrary.Models;

namespace WeightTracker
{
    public interface IChangePersonDataViewForm
    {
        void SetUpChangeForm(IPersonModel person);
        Task SaveChangesAsync();
    }
}
