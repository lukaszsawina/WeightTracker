using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeightTracker.Utilities
{
    public interface IValidator
    {
        void NewPersonValid(int id, string name, string age, string height);
        void NewWeightValid(int id, string weight);
    }
}
