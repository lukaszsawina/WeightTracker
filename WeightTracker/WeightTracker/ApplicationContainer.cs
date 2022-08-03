using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeightTracker.Controller;
using WeightTracker.Utilities;

namespace WeightTracker
{
    public class ApplicationContainer : IApplicationContainer
    {
        private IPersonsViewForm _personsViewForm;

        public ApplicationContainer(IPersonsViewForm personForm)
        {
            _personsViewForm = personForm;
        }

        public void Run()
        {
            Application.Run((Form)_personsViewForm);
        }
    }
}
