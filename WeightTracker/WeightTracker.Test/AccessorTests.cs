using Autofac.Extras.Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeightTracker.Controller;
using WeightTrackerLibrary.Models;
using Xunit;

namespace WeightTracker.Test
{
    public class AccessorTests
    {

        [Fact]
        public async void LoadPersons()
        {
            using(var mock = AutoMock.GetLoose())
            {
                List<IPersonModel> persons = new List<IPersonModel>();
                var progress = new Progress<int>();
                mock.Mock<IAccessor>().Setup(x => x.LoadPersonAsync(persons, progress));


                //var cls = mock.Create<>();

            }
        }

        public List<IPersonModel> GetSomePeople()
        {
            List<IPersonModel> output = new List<IPersonModel>();
            IPersonModel person = new PersonModel(1, "Jan", 21, 183);
            output.Add(person);
            output.Add(person);
            output.Add(person);

            return output;
        }
    }
}
