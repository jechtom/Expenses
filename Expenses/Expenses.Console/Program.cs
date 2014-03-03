using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expenses.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new UnityContainer();
            Expenses.UnityConfig.RegisterTypes(container, new ContainerControlledLifetimeManager()); // single data context

            var context = container.Resolve<BL.UnitOfWorkContext>();
            var iconsService = container.Resolve<BL.ExpenseIconService>();
            
            foreach(var file in System.IO.Directory.GetFiles(@"..\..\Icons\", "*.png"))
            {
                iconsService.CreateNewFromFile(Path.GetFileNameWithoutExtension(file), "image/png", File.ReadAllBytes(file));
                context.SaveChanges();
            }

        }
    }
}
