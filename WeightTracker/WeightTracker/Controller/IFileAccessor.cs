using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeightTrackerLibrary.Models;

namespace WeightTracker.Controller
{
    public interface IFileAccessor
    {
        Task LoadPersonFromFileAsync(List<IPersonModel> listOfPerson, IProgress<int> progress);
        Task SavePersonToFileAsync(List<IPersonModel> listOfPerson);
    }
}