using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using WeightTracker;
using WeightTrackerLibrary;
using System.Threading.Tasks;
using WeightTracker.Utilities;

namespace WeightTracker.Test
{
    public class ValidatorTests
    {
        IValidator _validator = new Validator();

        [Theory]
        [InlineData(-1, "Jan", "21", "183")]
        [InlineData(1, "", "21", "183")]
        [InlineData(1, "Jan", "-21", "183")]
        [InlineData(1, "Jan", "21", "-183")]
        [InlineData(-1, "Jan", "-21", "-183")]
        public void NewPerson_ExceptionThrow(int id, string name, string age, string height)
        {
            Assert.Throws<Exception>(() => _validator.NewPersonValid(id, name, age, height));
        }

        [Theory]
        [InlineData(-1,"75")]
        [InlineData(1,"-75")]
        [InlineData(-1,"-75")]
        public void NewWeight_ExceptionThrow(int id, string weight)
        {
            Assert.Throws<Exception>(() => _validator.NewWeightValid(id, weight));
        }
    }
}
