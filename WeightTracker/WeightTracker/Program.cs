using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeightTracker.Controller;
using WeightTracker.Utilities;
using WeightTracker.Views;

namespace WeightTracker
{

    internal static class Program
    {
        public static IContainer Container;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Container = Configure();
            using(var scope = Container.BeginLifetimeScope())
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new PersonsViewForm(Container.Resolve<IAccessor>(), Container.Resolve<IValidator>(), Container.Resolve<IBMICalculatior>()));
            }            
        }
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            //Template for single class
            builder.RegisterType<Validator>().As<IValidator>();
            builder.RegisterType<SQLAccessor>().As<IAccessor>();
            builder.RegisterType<BMICalculatior>().As<IBMICalculatior>();


            builder.RegisterAssemblyTypes(Assembly.Load(nameof(WeightTracker)))
                .Where(t => t.Namespace.Contains("Utilities"))
                .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == "I" + t.Name));

            return builder.Build();
        }
    }
}
