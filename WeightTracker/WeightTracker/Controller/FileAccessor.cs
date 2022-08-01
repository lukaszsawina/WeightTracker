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
            if (!CheckIfPersonFileExist())
                return;

            List<IPersonModel> LoadedPersons = await Task.Run(() => LoadPerson(PersonFile));
            LoadPersonToTableAndUpdateProgress(LoadedPersons, listOfPerson, progress);
            await Task.Run(() => LoadWeight(WeightFile, listOfPerson));
        }
        private bool CheckIfPersonFileExist()
        {
            if (!File.Exists(PersonFile))
                return false;
            return true;
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
        private void LoadPersonToTableAndUpdateProgress(List<IPersonModel> LoadedPersons, List<IPersonModel> listOfPerson, IProgress<int> progress)
        {
            int i = 0;
            foreach (var person in LoadedPersons)
            {
                listOfPerson.Add(person);
                UpdateProgressBar(progress, i++, LoadedPersons.Count);
            }
        }
        private void UpdateProgressBar(IProgress<int> progress, int currentlyAdded, int max)
        {
            var progressComplete = currentlyAdded * 100 / max;
            progress.Report(progressComplete);
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
            await SavePersonAsync(PersonFile, listOfPerson);
            await SaveWeightsAsync(WeightFile, listOfPerson);
        }

        private async Task SavePersonAsync(string personFile, List<IPersonModel> listOfPerson)
        {
            using (StreamWriter sw = new StreamWriter(personFile))
            {
                foreach(var p in listOfPerson)
                {
                    string line = $"{p.Id};{p.Name};{p.Age};{p.Height}";
                    await sw.WriteLineAsync(line);
                }
            }
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
        public async Task SaveNewPersonAsync(IPersonModel person)
        {
            using (StreamWriter sw = new StreamWriter(PersonFile, true))
            {
                string line = $"{ person.Id };{ person.Name };{ person.Age };{ person.Height }";
                await Task.Run(() => sw.WriteLineAsync(line));
            }
        }
        public async Task SaveNewWeightAsync(int PersonId, IWeightModel weight)
        {
            using (StreamWriter sw = new StreamWriter(WeightFile, true))
            {
                string line = $"{ PersonId };{ weight.Id };{ weight.Weight };{ weight.DateWhenAdd }";
                await Task.Run(() => sw.WriteLineAsync(line));
            }
        }
        public async Task DeleteWeightAsync(int id)
        {
            List<string[]> Weights = await Task.Run(() => LoadDataToListAsync(WeightFile));
            Weights.RemoveAt(Weights.IndexOf(Weights.Where(x => int.Parse(x[1]) == id).FirstOrDefault()));
            await Task.Run(() => SaveDataAfterChangesAsync(Weights, WeightFile));
        }
        public async Task ChangePersonDataAsync(IPersonModel person)
        {
            var persons = await Task.Run(() => LoadDataToListAsync(PersonFile));
            persons.RemoveAt(persons.IndexOf(persons.Where(x => int.Parse(x[0]) == person.Id).FirstOrDefault()));
            AddChangedPerson(persons, person);
            await Task.Run(() => SaveDataAfterChangesAsync(persons, PersonFile));
        }
        private void AddChangedPerson(List<string[]> persons, IPersonModel person)
        {
            string[] changedPerson = new string[4];
            changedPerson[0] = person.Id.ToString();
            changedPerson[1] = person.Name;
            changedPerson[2] = person.Age.ToString();
            changedPerson[3] = person.Height.ToString();
            persons.Add(changedPerson);
        }
        private List<string[]> LoadDataToListAsync(string file)
        {
            var lines = File.ReadAllLines(file);
            string[][] output = new string[lines.Count()][];
            int i = 0;

            foreach (var line in lines)
            {
                if (line.Length == 0)
                    continue;
                output[i] = line.Split(';');
                i++;
            }
            return output.ToList<string[]>();
        }
        private async Task SaveDataAfterChangesAsync(List<string[]> data, string file)
        {
            using (StreamWriter sw = new StreamWriter(file))
            {
                foreach (var p in data)
                {
                    string line = $"{p[0]};{p[1]};{p[2]};{p[3]}";
                    await Task.Run(() => sw.WriteLineAsync(line));
                }
            }
        }
    }
}
