﻿using System;
using System.Data.Entity;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Autofac;
using Autofac.Builder;
using Autofac.Extras.DynamicProxy2;
using Autofac.Integration.Mvc;
using Web.Models;
using Web.Models.Entity;
using Web.Models.Model;
using Web.Service;
using Web.Service.Interface;

namespace Web
{
    public class IocConfig
    {
        public static IContainer AutoContainer;

        public static ILifetimeScope AutoFacContainer
        {
            get
            {
                try
                {
                    return AutofacRequestLifetimeHttpModule.GetLifetimeScope(AutoContainer, null);
                }
                catch (Exception)
                {
                    return AutoContainer;
                }

            }
        }

        public static void Register()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // register dbcontext
            builder.Register(c => new ApplicationDbContext()).As<DbContext>().InstancePerRequest();

            //register service
            var dataAccess = Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(dataAccess)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces();

            builder.RegisterGeneric(typeof(PagingHandler<>)).As(typeof(IPagingHandler<>)).InstancePerRequest();
            
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

    }

    public class AutofacRequestLifetimeHttpModule : IHttpModule
    {
        /// <summary>
        /// Tag used to identify registrations that are scoped to the HTTP request level.
        /// </summary>
        //in the previous versions of Autofac (for MVC3) it was set to "httpRequest"
        public static readonly object HttpRequestTag = "AutofacWebRequest";

        /// <summary>
        /// Initializes a module and prepares it to handle requests.
        /// </summary>
        /// <param name="context">An <see cref="T:System.Web.HttpApplication"/> that provides access to the 
        /// methods, properties, and events common to all application objects within an ASP.NET application</param>
        public void Init(HttpApplication context)
        {
            context.EndRequest += ContextEndRequest;
        }

        /// <summary>
        /// Gets a nested lifetime scope that services can be resolved from.
        /// </summary>
        /// <param name="container">The parent container.</param>
        /// <param name="configurationAction">Action on a <see cref="ContainerBuilder"/>
        /// that adds component registations visible only in nested lifetime scopes.</param>
        /// <returns>A new or existing nested lifetime scope.</returns>
        public static ILifetimeScope GetLifetimeScope(ILifetimeScope container, Action<ContainerBuilder> configurationAction)
        {
            //little hack here to get dependencies when HttpContext is not available
            if (HttpContext.Current != null)
            {
                return LifetimeScope ?? (LifetimeScope = InitializeLifetimeScope(configurationAction, container));
            }
            else
            {
                //throw new InvalidOperationException("HttpContextNotAvailable");
                return InitializeLifetimeScope(configurationAction, container);
            }
        }

        /// <summary>
        /// Disposes of the resources (other than memory) used by the module that implements <see cref="T:System.Web.IHttpModule"/>.
        /// </summary>
        public void Dispose()
        {
        }

        static ILifetimeScope LifetimeScope
        {
            get
            {
                return (ILifetimeScope)HttpContext.Current.Items[typeof(ILifetimeScope)];
            }
            set
            {
                HttpContext.Current.Items[typeof(ILifetimeScope)] = value;
            }
        }

        public static void ContextEndRequest(object sender, EventArgs e)
        {
            ILifetimeScope lifetimeScope = LifetimeScope;
            if (lifetimeScope != null)
                lifetimeScope.Dispose();
        }

        static ILifetimeScope InitializeLifetimeScope(Action<ContainerBuilder> configurationAction, ILifetimeScope container)
        {
            return (configurationAction == null)
                ? container.BeginLifetimeScope(HttpRequestTag)
                : container.BeginLifetimeScope(HttpRequestTag, configurationAction);
        }
    }
}