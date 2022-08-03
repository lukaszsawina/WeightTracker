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

        [Fact]
        public void BMI_CalculateShouldMatch()
        {
            float expected = 25f;

            float actual = _bmi.CalculateBMI(75f, 183);

            Assert.Equal(expected, actual);
        }

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

        [Theory]
        [InlineData(-10, 193)]
        [InlineData(10, -193)]
        [InlineData(-10, -193)]
        public void BMI_WeightLessThenZeroExceptionThrow(float weight, int height)
        {
            Assert.Throws<ArgumentException>(() => _bmi.CalculateBMI(weight, height));
        }
    }
}
