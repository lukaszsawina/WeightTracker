using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeightTrackerLibrary.Models
{
    public class WeightModelDB
    {
        public int PersonId { get; set; }
        public int Id { get; set; }
        public float Weight { get; set; }
        public DateTime DateWhenAdd { get; set; }

    }
}
