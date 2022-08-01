using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeightTrackerLibrary;
using WeightTracker;
using Xunit;
using WeightTracker.Utilities;
using WeightTrackerLibrary.Models;

namespace WeightTracker.Test
{

    public class BMIcalculationTests
    {
        IBMICalculatior _bmi = new BMICalculatior();

        [Theory]
        [InlineData(84.3f, 183, "Overweight (Pre-obese)")]
        [InlineData(70f, 183, "Normal range")]
        [InlineData(40f, 183, "Underweight (Severe thinness)")]
        [InlineData(50f, 183, "Underweight (Moderate thinness)")]
        public void BMI_MatchCategoryShouldMatch(float weight, int height, string expected)
        {
            _bmi.CalculateBMI(weight, height);
            string actual = _bmi.MatchCategory();

            Assert.Equal(expected, actual);
        }
    }
}
