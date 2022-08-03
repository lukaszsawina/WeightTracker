using Autofac.Extras.Moq;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WeightTracker.Controller;
using WeightTracker.Views;
using WeightTrackerLibrary.Models;
using Xunit;

namespace WeightTracker.Test
{
    public class AccessorTests
    {

        [Fact]
        public async Task SaveNewPersonTest()
        {
            using (var mock = AutoMock.GetLoose())
            {
                var person = GetSomePeople()[0];

                mock.Mock<IAccessor>().Setup(x => x.SaveNewPersonAsync(person));
                var cls = mock.Create<PersonsViewForm>();
                await cls.SaveNewPersonAsync();

                mock.Mock<IAccessor>().Verify(x => x.SaveNewPersonAsync(person), Times.Exactly(1));
            }
        }

        [Fact]
        public async Task SaveNewWeightTest()
        {
            using (var mock = AutoMock.GetLoose())
            {
                var weight = GetSomeWeights()[0];
                var person = GetSomePeople()[0];


                mock.Mock<IAccessor>().Setup(x => x.SaveNewWeightAsync(person.Id, weight));
                var cls = mock.Create<PersonMenuViewForm>();
                await cls.SaveNewWeightAsync();

                mock.Mock<IAccessor>().Verify(x => x.SaveNewWeightAsync(person.Id, weight), Times.Exactly(1));
            }
        }

        [Fact]
        public async Task DeleteWeightTest()
        {
            using (var mock = AutoMock.GetLoose())
            {
                var Weight = GetSomeWeights()[0];

                mock.Mock<IAccessor>().Setup(x => x.DeleteWeightAsync(Weight.Id));
                var cls = mock.Create<PersonMenuViewForm>();
                await cls.DeleteWeightAsync();

                mock.Mock<IAccessor>().Verify();
            }
        }
        [Fact]
        public async Task ChangePersonAsyncTestAsync()
        {
            using(var mock = AutoMock.GetLoose())
            {
                var person = GetSomePeople()[0];

                mock.Mock<IAccessor>().Setup(x => x.ChangePersonDataAsync(person));
                var cls = mock.Create<ChangePersonDataViewForm>();
                await Task.Run(() => cls.SaveChangesAsync());

                mock.Mock<IAccessor>().Verify(x => x.ChangePersonDataAsync(person), Times.Exactly(1));
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

        public List<IWeightModel> GetSomeWeights()
        {
            List<IWeightModel> output = new List<IWeightModel>();
            IWeightModel weight = new WeightModel(1, 75f);
            output.Add(weight);
            output.Add(weight);
            output.Add(weight);

            return output;
        }
    }
}
