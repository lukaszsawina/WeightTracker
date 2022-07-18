using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeightTrackerLibrary.Models;

namespace WeightTracker.Controller
{
    public class FileAccessor
    {
        private readonly string PersonFile = @"C:\dev\C#\WeightTracker_WinFormApp\WeightTracker\Person.csv";
        private readonly string WeightFile = "Weight.csv";

        public async Task LoadPersonFromFileAsync(List<IPersonModel> listOfPerson)
        {
            listOfPerson.AddRange(await Task.Run(() => LoadPerson(PersonFile)));
        }

        public List<IPersonModel> LoadPerson(string file)
        {
            List<IPersonModel> output = new List<IPersonModel>();   
            var lines = File.ReadAllLines(file);

            foreach(var line in lines)
            {
                string[] splitedLine = line.Split(';');
                IPersonModel newPerson = new PersonModel(Int32.Parse(splitedLine[0]), splitedLine[1], Int32.Parse(splitedLine[2]), Int32.Parse(splitedLine[3]));
                output.Add(newPerson);
            }

            return output;
        }
    }
}
