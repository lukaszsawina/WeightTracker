using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeightTrackerLibrary.Models
{
    public class WeightModel : IWeightModel
    {
        public int Id { get; private set; }
        public float Weight { get; private set; }
        public DateTime DateWhenAdd { get; private set; }
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
        public WeightModel(int id, float weight, DateTime datWhenAdd)
        {
            Id = id;
            Weight = weight;
            DateWhenAdd = datWhenAdd;
        }
    }
}
