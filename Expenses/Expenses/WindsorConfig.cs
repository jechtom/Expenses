using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expenses
{
    public class WindsorConfig : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                    Component.For<BL.UnitOfWorkContext>().LifestyleScoped(),
                    Component.For<DL.DbDataContext>().LifestyleScoped(),
                    Classes.FromThisAssembly().InNamespace("Expenses.BL").If(t => t.Name.EndsWith("Service")).LifestyleScoped()
                );
        }
    }
}
