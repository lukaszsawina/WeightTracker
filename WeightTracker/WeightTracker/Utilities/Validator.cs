using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeightTracker.Utilities;

namespace WeightTracker
{
    public class Validator : IValidator
    {
        public void NewPersonValid(int id, string name, string age, string height)
        {
            int newAge, newHeight;

            if (id < 0)
                throw new Exception("Invalid ID number");
            else if (name == null || name == "")
                throw new Exception("Name field is empty");
            else if (!Int32.TryParse(age, out newAge))
                throw new Exception("Invalid age value");
            else if (newAge < 0 || newAge > 120)
                throw new Exception("Invalid age value");
            else if (!Int32.TryParse(height, out newHeight))
                throw new Exception("Invalid height value");
            else if (newHeight < 0 || newHeight > 300)
                throw new Exception("Invalid height value");
        }
    }
}
