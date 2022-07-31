using System;

namespace WeightTrackerLibrary.Models
{
    public interface IWeightModel
    {
        int Id { get; set; }
        float Weight { get; set; }
        DateTime DateWhenAdd { get; set; }
        string WeightData { get; }
    }
}