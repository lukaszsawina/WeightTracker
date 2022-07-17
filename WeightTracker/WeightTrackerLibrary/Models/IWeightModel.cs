using System;

namespace WeightTrackerLibrary.Models
{
    public interface IWeightModel
    {
        DateTime DateWhenAdd { get; }
        int Id { get; }
        float Weight { get; }
    }
}