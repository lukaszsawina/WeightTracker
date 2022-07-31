using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeightTrackerLibrary.Models;

namespace WeightTracker.Controller
{
    public class FileAccessor : IAccessor
    {
        private readonly string PersonFile = @"C:\dev\C#\WeightTracker_WinFormApp\WeightTracker\Person.csv";
        private readonly string WeightFile = @"C:\dev\C#\WeightTracker_WinFormApp\WeightTracker\Weight.csv";

        public async Task LoadPersonAsync(List<IPersonModel> listOfPerson, IProgress<int> progress)
        {
            if (!File.Exists(PersonFile))
                return;

            List<IPersonModel> LoadedPersons = await Task.Run(() => LoadPerson(PersonFile));
            foreach(var person in LoadedPersons)
            {
                listOfPerson.Add(person);
                var progressComplete = listOfPerson.Count * 100 / LoadedPersons.Count;
                progress.Report(progressComplete);
            }
            //await Task.Run(() => LoadWeight(WeightFile, listOfPerson));
        }
        private List<IPersonModel> LoadPerson(string file)
        {
            List<IPersonModel> output = new List<IPersonModel>();
            var lines = File.ReadAllLines(file);
            foreach (var line in lines)
            {
                string[] splitedLine = line.Split(';');
                IPersonModel newPerson = new PersonModel(Int32.Parse(splitedLine[0]), splitedLine[1], Int32.Parse(splitedLine[2]), Int32.Parse(splitedLine[3]));
                output.Add(newPerson);
            }

            return output;
        }
        private void LoadWeight(string file, List<IPersonModel> listOfPerson)
        {
            var lines = File.ReadAllLines(file);

            foreach (var line in lines)
            {
                if (line.Length == 0)
                    continue;
                string[] splitedLine = line.Split(';');
                IWeightModel newWeight = new WeightModel(Int32.Parse(splitedLine[1]), float.Parse(splitedLine[2]), DateTime.Parse(splitedLine[3]));
                listOfPerson.Where(x => x.Id == Int32.Parse(splitedLine[0])).FirstOrDefault().WeightRecords.Add((WeightModel)newWeight);
            }
            
        }
        public async Task SaveDatanAsync(List<IPersonModel> listOfPerson)
        {
            await SavePersonAsync(PersonFile, WeightFile, listOfPerson);
        }

        private async Task SavePersonAsync(string personFile, string weightFile, List<IPersonModel> listOfPerson)
        {
            using (StreamWriter sw = new StreamWriter(personFile))
            {
                foreach(var p in listOfPerson)
                {
                    string line = $"{p.Id};{p.Name};{p.Age};{p.Height}";
                    await sw.WriteLineAsync(line);
                }
            }

            await SaveWeightsAsync(weightFile, listOfPerson);

        }
        private async Task SaveWeightsAsync(string file, List<IPersonModel> listOfPerson)
        {

            using (StreamWriter wsw = new StreamWriter(file))
            {
                foreach(var p in listOfPerson)
                foreach(var w in p.WeightRecords)
                {
                    string line = $"{p.Id};{w.Id};{w.Weight};{w.DateWhenAdd}";
                    await Task.Run(() => wsw.WriteLineAsync(line));
                }
            }
        }

        public Task SaveNewPersonAsync(IPersonModel person)
        {
            throw new NotImplementedException();
        }

        public Task SaveNewWeightAsync(int PersonId, IWeightModel weight)
        {
            throw new NotImplementedException();
        }
    }
}
