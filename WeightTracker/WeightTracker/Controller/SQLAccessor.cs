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
            UpdateprogessBar(listOfPerson, LoadedPersons, progress);
            await Task.Run(() => LoadWeight(listOfPerson));
        }
        private List<IPersonModel> LoadPerson()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("WeightsDB")))
            {
                var output = connection.Query<PersonModel>("SELECT * FROM PersonView").ToList<IPersonModel>();
                return output;
            }
        }
        private void UpdateprogessBar(List<IPersonModel> listOfPerson, List<IPersonModel> loadedPersons, IProgress<int> progress)
        {
            foreach (var person in loadedPersons)
            {
                listOfPerson.Add(person);
                progress.Report(listOfPerson.Count * 100 / loadedPersons.Count);
            }
        }
        private void LoadWeight(List<IPersonModel> listOfPerson)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("WeightsDB")))
            {
                foreach (var p in listOfPerson)
                    p.WeightRecords = connection.Query<WeightModel>("sp_SelectWeightsByPerson", new {PersonId = p.Id}, commandType: CommandType.StoredProcedure ).ToList<IWeightModel>();
            }
        }

        public async Task SaveNewPersonAsync(IPersonModel p)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("WeightsDB")))
            {
                await connection.ExecuteAsync("sp_NewPerson", new { Id = p.Id, Name = p.Name, Age = p.Age, Height = p.Height }, commandType: CommandType.StoredProcedure);
            }
        }
        public async Task SaveNewWeightAsync(int PersonId, IWeightModel weight)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("WeightsDB")))
            {
                await connection.ExecuteAsync("sp_NewWeight", new { PersonId = PersonId, Id = weight.Id, Weight = weight.Weight, DateWhenAdd = weight.DateWhenAdd }, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task DeleteWeightAsync(int id)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("WeightsDB")))
            {
                await connection.ExecuteAsync("sp_DeleteWeight", new { Id = id }, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task ChangePersonData(IPersonModel p)
        {
            {
                using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("WeightsDB")))
                {
                    await connection.ExecuteAsync("sp_ChangePersonData", new { id = p.Id, name = p.Name, age = p.Age, height = p.Height }, commandType: CommandType.StoredProcedure);
                }
            }
        }
    }
}
