using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeightTrackerLibrary.Models
{
    public class PersonModelDB
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Height { get; set; }

        public PersonModelDB(int id, string name, int age, int height)
        {
            Id = id;
            Name = name;
            Age = age;
            Height = height;
        }
    }
}
