using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Castle.MicroKernel.Lifestyle;

namespace Expenses.Web.App_Start
{
    public class WindsorConfig : IWindsorInstaller
    {
        public static IWindsorContainer Container { get; private set; }
        
        public static void InitContainer()
        {
            Container = new WindsorContainer();
            Container.Install(
                FromAssembly.This(),
                FromAssembly.Named("Expenses")
            );
        }

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            DependencyResolver.SetResolver(new Code.WindsorDependencyResolver(container));
            container.Register(Component.For<IControllerFactory>().Instance(new Code.WindsorControllerFactory(container)));
            container.Register(Classes.FromThisAssembly().Pick().LifestyleTransient());

            container.Register(Component.For<IDisposable>().Named(Code.WindsorControllerFactory.ScopeComponentName)
                .UsingFactoryMethod((f, c) => container.BeginScope()).LifestylePerWebRequest());
        }
    }
}