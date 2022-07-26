using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeightTrackerLibrary.Models
{
    public class PersonModel : IPersonModel
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int Age { get; private set; }
        public int Height { get; private set; }
        public List<IWeightModel> WeightRecords { get; set; } = new List<IWeightModel>();
        public string FullName
        {
            get
            {
                return $"{Id}: {Name}";
            }
        }


        public PersonModel(int id, string name, int age, int height)
        {
            Id = id;
            Name = name;
            Age = age;
            Height = height;
        }

        public void ChangeData(string name, int age, int height)
        {
            Name = name;
            Age = age;
            Height = height;
        }
    }
}
