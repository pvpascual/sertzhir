using SertzHir.Common;
using SertzHir.Core.Interfaces;
using SertzHir.Core.Interfaces.Services;
using SertzHir.Services;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace SertzHir.Api
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IPersonService, PersonService>();
            container.RegisterType<IStateService, StateService>();
            container.RegisterType<ISertzHirDataUow, SertzHirDataUow>();
            container.RegisterType<IUtility, Utilities>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}