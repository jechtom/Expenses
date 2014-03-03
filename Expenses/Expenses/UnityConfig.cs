using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expenses
{
    public class UnityConfig
    {
        public static void RegisterTypes(IUnityContainer container, Func<LifetimeManager> defaultRequestLifetimeManager)
        {
            container.RegisterType<Expenses.DL.DbDataContext>(defaultRequestLifetimeManager());
        }
    }
}
