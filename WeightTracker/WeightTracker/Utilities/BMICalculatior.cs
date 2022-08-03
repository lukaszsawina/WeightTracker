using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeightTrackerLibrary.Models;

namespace WeightTracker.Utilities
{
    public class BMICalculatior : IBMICalculatior
    {
        private IDictionary<float, string> category = InitializeCategory();
        private float BMI;

        public float CalculateBMI(float weight, int height)
        {
            if (ValidInputs(weight, height))
                throw new ArgumentException("Weight less then zero");

            BMI = (weight / (height * height / 10000));
            BMI = (float)Math.Round(BMI, 2);
            return BMI;
        }
        private bool ValidInputs(float weight, int height)
        {
            return weight < 0 || height < 0;
        }
        public string MatchCategory()
        {
            string output = BMI < 40.0f ? category.Where(x => BMI <= x.Key).Select(x => x.Value).FirstOrDefault() : "Obese (Class III)";
            return output;
        }
        private static IDictionary<float, string> InitializeCategory()
        {
            IDictionary<float, string> output = new Dictionary<float, string>();
            output.Add(16.0f, "Underweight (Severe thinness)");
            output.Add(16.99f, "Underweight (Moderate thinness)");
            output.Add(18.49f, "Underweight (Mild thinness)");
            output.Add(24.99f, "Normal range");
            output.Add(29.99f, "Overweight (Pre-obese)");
            output.Add(34.99f, "Obese (Class I)");
            output.Add(39.99f, "Obese (Class II)");

            return output;
        }
    }

}
