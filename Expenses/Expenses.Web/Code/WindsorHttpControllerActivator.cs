using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Castle.MicroKernel.Lifestyle;
using System.Net.Http;
using System.Web.Http.Dispatcher;
using System.Web.Http.Controllers;

namespace Expenses.Web.Code
{
    public class WindsorHttpControllerActivator : System.Web.Http.Dispatcher.IHttpControllerActivator
    {
        private IWindsorContainer container;
        public WindsorHttpControllerActivator(Castle.Windsor.IWindsorContainer container)
        {
            this.container = container;
        }

        public IHttpController Create(System.Net.Http.HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType)
        {
            container.Resolve<IDisposable>(App_Start.WindsorConfig.ScopeComponentName); // ensure scope
            var result = container.Resolve(controllerType) as IHttpController;
            if(result == null)
                return null;

            request.RegisterForDispose(new Release(() => this.container.Release(result)));
            return result;
        }

        private class Release : IDisposable
        {
            private readonly Action release;

            public Release(Action release)
            {
                this.release = release;
            }

            public void Dispose()
            {
                this.release();
            }
        }
    }
}