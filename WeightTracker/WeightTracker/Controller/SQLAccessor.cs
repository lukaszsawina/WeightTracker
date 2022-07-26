using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeightTrackerLibrary.Models;

namespace WeightTracker.Controller
{
    public class SQLAccessor : IAccessor
    {
        public async Task LoadPersonAsync(List<IPersonModel> listOfPerson, IProgress<int> progress)
        {
            List<IPersonModel> LoadedPersons = await Task.Run(() => LoadPerson());
            foreach (var person in LoadedPersons)
            {
                listOfPerson.Add(person);
                var progressComplete = listOfPerson.Count * 100 / LoadedPersons.Count;
                progress.Report(progressComplete);
            }

            await Task.Run(() => LoadWeight(listOfPerson));
        }
        private List<IPersonModel> LoadPerson()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("WeightsDB")))
            {
                var returnedList = connection.Query<PersonModelDB>("Select * From Persons").ToList();
                var output = new List<IPersonModel>();
                foreach (var person in returnedList)
                    output.Add(new PersonModel(person.Id, person.Name, person.Age, person.Height));

                return output;
            }
        }

        private void LoadWeight(List<IPersonModel> listOfPerson)
        {
            List<WeightModelDB> output = new List<WeightModelDB>();
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("WeightsDB")))
            {
                output = connection.Query<WeightModelDB>("Select * From Weights").ToList();
            }
            foreach (var w in output)
            {
                IWeightModel newWeight = new WeightModel(w.Id, w.Weight, w.DateWhenAdd);
                listOfPerson.Where(x => x.Id == w.PersonId).FirstOrDefault().WeightRecords.Add((WeightModel)newWeight);
            }

        }
        public async Task SaveDatanAsync(List<IPersonModel> listOfPerson)
        {
            await SavePersonAsync(listOfPerson);
            await SaveWeightsAsync(listOfPerson);

        }
        private async Task SavePersonAsync(List<IPersonModel> listOfPerson)
        {

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("WeightsDB")))
            {
                foreach (var person in listOfPerson)
                {
                    PersonModelDB newPewron = new PersonModelDB( person.Id, person.Name, person.Age, person.Height );
                    string processQuery = "INSERT INTO Persons VALUES (@Id, @Name, @Age, @Weight)";
                    await connection.ExecuteAsync(processQuery, newPewron);
                }
            }

        }

        private async Task SaveWeightsAsync(List<IPersonModel> listOfPerson)
        {

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("WeightsDB")))
            {
                foreach (var person in listOfPerson)
                {
                    int personId = person.Id;
                    foreach (var weight in person.WeightRecords)
                        await connection.QueryAsync("insert into Weights(PersonId, Id, Weight, DateWhenAdd) values (@PersonId, @Id, @Weight, @DateWhenAdd)", new { personId, weight.Id, weight.Weight, weight.DateWhenAdd });
                }
            }
        }

        private async Task ResetTable(string name)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("WeightsDB")))
            {
                await connection.QueryAsync($"TRUNCATE TABLE {name}");
            }
        }

    }
}
