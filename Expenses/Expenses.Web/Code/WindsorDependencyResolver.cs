using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Expenses.Web.Code
{
    public class WindsorDependencyResolver : IDependencyResolver
    {
        IWindsorContainer container;
        public WindsorDependencyResolver(IWindsorContainer container)
        {
            this.container = container;
        }
        
        public object GetService(Type serviceType)
        {
            if (!container.Kernel.HasComponent(serviceType))
                return null;
            return container.Resolve(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            if (!container.Kernel.HasComponent(serviceType))
                return Enumerable.Empty<object>();

            return container.ResolveAll(serviceType) as IEnumerable<object>;
        }
    }
}