using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WeightTracker.Controller;
using WeightTracker.Utilities;
using WeightTracker.Views;

namespace WeightTracker
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            //Template for single class
            builder.RegisterType<ApplicationContainer>().As<IApplicationContainer>();
            builder.RegisterType<PersonsViewForm>().As<IPersonsViewForm>();
            builder.RegisterType<PersonMenuViewForm>().As<IPersonMenuViewForm>();
            builder.RegisterType<ChangePersonDataViewForm>().As<IChangePersonDataViewForm>();
            builder.RegisterType<Validator>().As<IValidator>();
            builder.RegisterType<SQLAccessor>().As<IAccessor>();
            builder.RegisterType<BMICalculatior>().As<IBMICalculatior>();

            return builder.Build();
        }
    }
}
