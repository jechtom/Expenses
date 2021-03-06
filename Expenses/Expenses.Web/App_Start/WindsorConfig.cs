﻿using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Castle.MicroKernel.Lifestyle;
using System.Web.Http;
using Expenses.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

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

        public const string ScopeComponentName = "WindsorScopeComponent";

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            // webAPI
            GlobalConfiguration.Configuration.Services.Replace(
                typeof(System.Web.Http.Dispatcher.IHttpControllerActivator),
                new Code.WindsorHttpControllerActivator(container));

            // MVC
            DependencyResolver.SetResolver(new Code.WindsorDependencyResolver(container));
            container.Register(Component.For<IControllerFactory>().Instance(new Code.WindsorControllerFactory(container)));

            // all classes
            container.Register(Classes.FromThisAssembly().Pick().LifestyleTransient());

            // scope
            container.Register(Component.For<IDisposable>().Named(ScopeComponentName)
                .UsingFactoryMethod((f, c) => container.BeginScope()).LifestylePerWebRequest());

            // security - user manager
            container.Register(Component.For<UserManager<ApplicationUser>>().LifestylePerWebRequest());

            // security - identity user store
            container.Register(Component.For<IUserStore<ApplicationUser>>().ImplementedBy<UserStore<ApplicationUser>>()
                .DependsOn(ServiceOverride.ForKey<DbContext>().Eq("UserStoreContext"))
                .LifestylePerWebRequest());

            // security - identity user store context
            container.Register(Component.For<DbContext>().Named("UserStoreContext").ImplementedBy<ApplicationDbContext>()
                .LifestylePerWebRequest());
        }
    }
}