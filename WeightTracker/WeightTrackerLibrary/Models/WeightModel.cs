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
    }
}
