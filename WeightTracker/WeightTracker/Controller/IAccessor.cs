using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeightTrackerLibrary.Models;

namespace WeightTracker.Controller
{
    public interface IAccessor
    {
        Task LoadPersonAsync(List<IPersonModel> listOfPerson, IProgress<int> progress);
        Task SavePersonAsync(List<IPersonModel> listOfPerson);
    }
}