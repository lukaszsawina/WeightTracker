using WeightTrackerLibrary.Models;

namespace WeightTracker.Utilities
{
    public interface IBMICalculatior
    {
        float CalculateBMI(float weight, int height);
        string MatchCategory();
    }
}