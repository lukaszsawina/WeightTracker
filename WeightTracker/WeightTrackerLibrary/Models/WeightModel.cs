using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeightTrackerLibrary.Models
{
    public class WeightModel : IWeightModel
    {
        public int Id { get; set; }
        public float Weight { get; set; }
        public DateTime DateWhenAdd { get; set; }
        public string WeightData 
        {
            get
            {
                return $"{ Id }: { Weight } kg { DateWhenAdd.ToShortDateString() }";
            }
        }
        public WeightModel(int id, float weight)
        {
            Id = id;
            Weight = weight;
            DateWhenAdd = DateTime.Now;
        }
        public WeightModel(int id, float weight, DateTime dateWhenAdd)
        {
            Id = id;
            Weight = weight;
            DateWhenAdd = dateWhenAdd;
        }
        public WeightModel(int id, double weight, DateTime dateWhenAdd)
        {
            Id = id;
            Weight = (float)weight;
            DateWhenAdd = dateWhenAdd;
        }
    }
}
