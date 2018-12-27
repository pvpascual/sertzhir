using SertzHir.Common;
using SertzHir.Core.Interfaces;
using SertzHir.Core.Interfaces.Services;
using System.Web.Mvc;
using SearchzHir.Web.Models;
using Unity;
using Unity.Mvc5;
using System.Data.Entity;
using Unity.Lifetime;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SearchzHir.Web.Controllers;
using Unity.Injection;

namespace SearchzHir.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IApiHandler, ApiHandler>();
            container.RegisterType<DbContext, SertzHirAdminDbContext>(new HierarchicalLifetimeManager());
            container.RegisterType<UserManager<ApplicationUser>>(new HierarchicalLifetimeManager());
            container.RegisterType<IUserStore<ApplicationUser>, UserStore<ApplicationUser>>(new HierarchicalLifetimeManager());
            container.RegisterType<AccountController>(new InjectionConstructor());

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}