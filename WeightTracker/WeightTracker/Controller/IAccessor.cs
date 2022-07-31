using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeightTrackerLibrary.Models;

namespace WeightTracker.Controller
{
    public interface IAccessor
    {
        Task LoadPersonAsync(List<IPersonModel> listOfPerson, IProgress<int> progress);
        Task SaveNewPersonAsync(IPersonModel person);
        Task SaveNewWeightAsync(int PersonId, IWeightModel weight);
        Task DeleteWeightAsync(int id);
        Task ChangePersonData(IPersonModel person);
    }
}