using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WeightTracker.Controller;
using WeightTracker.Utilities;

namespace WeightTracker
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            //Template for single class
            builder.RegisterType<ApplicationContainer>().As<IApplicationContainer>();
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
