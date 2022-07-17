using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeightTrackerLibrary.Models
{
    public class PersonModel
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int Age { get; private set; }
        public int Height { get; private set; }
        public List<WeightModel> WeightRecords { get; set; } = new List<WeightModel>();
        public string FullName
        {
            get
            {
                return $"{ Id }: { Name }";
            }
        }

        public PersonModel(int id, string name, int age, int height)
        {
            Id = id;
            Name = name;
            Age = age;
            Height = height;
        }
    }
}
