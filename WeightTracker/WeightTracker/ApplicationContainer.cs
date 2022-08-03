using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeightTracker
{
    public class ApplicationContainer : IApplicationContainer
    {
        Application _app;

        public ApplicationContainer(Application app)
        {
            _app = app;
        }

        public void Run()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            _app.Run(new PersonsViewForm());
        }
    }
}
