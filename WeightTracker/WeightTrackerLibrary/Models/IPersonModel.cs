using System.Collections.Generic;

namespace WeightTrackerLibrary.Models
{
    public interface IPersonModel
    {
        int Age { get; }
        string FullName { get; }
        int Height { get; }
        int Id { get; }
        string Name { get; }
        List<WeightModel> WeightRecords { get; set; }
    }
}