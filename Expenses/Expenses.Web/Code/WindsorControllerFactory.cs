using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Castle.MicroKernel.Lifestyle;

namespace Expenses.Web.Code
{
    public class WindsorControllerFactory : DefaultControllerFactory
    {
        private IWindsorContainer container;
        public WindsorControllerFactory(Castle.Windsor.IWindsorContainer container)
        {
            this.container = container;
        }

        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
        {
            container.Resolve<IDisposable>(App_Start.WindsorConfig.ScopeComponentName); // ensure scope
            return container.Resolve(controllerType) as IController;
        }
    }
}