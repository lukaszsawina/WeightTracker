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
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("DapperDB")))
            {
                var output = connection.Query<IPersonModel>("Select * From Persons").ToList();

                return output;
            }
        }

        private void LoadWeight(List<IPersonModel> listOfPerson)
        {
            List<WeightModelDB> output = new List<WeightModelDB>();
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("DapperDB")))
            {
                output = connection.Query<WeightModelDB>("Select * From Weights").ToList();
            }
            foreach(var w in output)
            {
                IWeightModel newWeight = new WeightModel(w.Id, w.Weight, w.DateWhenAdd);
                listOfPerson.Where(x => x.Id == w.PersonId).FirstOrDefault().WeightRecords.Add((WeightModel)newWeight);
            }
           
        }

        public Task SavePersonAsync(List<IPersonModel> listOfPerson)
        {
            throw new NotImplementedException();
        }
    }
}
