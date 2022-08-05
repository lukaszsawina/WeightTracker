using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;

namespace WeightTrackerLibrary.Models
{
    public class PersonModel : IPersonModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Height { get; set; }
        public List<IWeightModel> WeightRecords { get; set; } = new List<IWeightModel>();
        public string FullName
        {
            get
            {
                return $"{Id}: {Name}";
            }
        }
        public PersonModel()
        {

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
