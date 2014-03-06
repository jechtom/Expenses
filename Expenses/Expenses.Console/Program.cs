using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.MicroKernel.Lifestyle;

namespace Expenses.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new WindsorContainer();
            container.Install(FromAssembly.Named("Expenses"));
            container.Register(Component.For<BL.UnitOfWorkContext>().LifestyleTransient());

            using(container.BeginScope())
            {
                var iconsService = container.Resolve<BL.ExpenseIconService>();
                var context = container.Resolve<BL.UnitOfWorkContext>();
                foreach (var file in System.IO.Directory.GetFiles(@"..\..\Icons\", "*.png"))
                {
                    iconsService.CreateNewFromFile(Path.GetFileNameWithoutExtension(file), "image/png", File.ReadAllBytes(file));
                    context.SaveChanges();
                }
            }

        }
    }
}
