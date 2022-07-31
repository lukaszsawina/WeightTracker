using System.Collections.Generic;

namespace WeightTrackerLibrary.Models
{
    public interface IPersonModel
    {
        int Id { get; set; }
        string Name { get; set; }
        int Age { get; set; }
        int Height { get; set; }
        string FullName { get; }
        List<IWeightModel> WeightRecords { get; set; }
        void ChangeData(string name, int age, int height);
    }
}