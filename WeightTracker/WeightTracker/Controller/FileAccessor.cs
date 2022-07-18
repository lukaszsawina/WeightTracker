using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeightTrackerLibrary.Models;

namespace WeightTracker.Controller
{
    public class FileAccessor : IFileAccessor
    {
        private readonly string PersonFile = @"C:\dev\C#\WeightTracker_WinFormApp\WeightTracker\Person.csv";
        private readonly string WeightFile = @"C:\dev\C#\WeightTracker_WinFormApp\WeightTracker\Weight.csv";

        public async Task LoadPersonFromFileAsync(List<IPersonModel> listOfPerson, IProgress<int> progress)
        {
            List<IPersonModel> LoadedPersons = await Task.Run(() => LoadPerson(PersonFile));
            foreach(var person in LoadedPersons)
            {
                listOfPerson.Add(person);
                var progressComplete = listOfPerson.Count * 100 / LoadedPersons.Count;
                progress.Report(progressComplete);
            }
        }
        public async Task SavePersonToFileAsync(List<IPersonModel> listOfPerson)
        {
            await SavePersonAsync(PersonFile, listOfPerson);
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

        private async Task SavePersonAsync(string file, List<IPersonModel> listOfPerson)
        {
            using (StreamWriter sw = new StreamWriter(file))
            {
                foreach(var p in listOfPerson)
                {
                    string line = $"{p.Id};{p.Name};{p.Age};{p.Height}";
                    await sw.WriteLineAsync(line);
                }
            }
        }
    }
}
