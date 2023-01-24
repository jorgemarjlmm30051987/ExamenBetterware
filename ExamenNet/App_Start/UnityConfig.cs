using System.Web.Http;
using Unity;
using Unity.WebApi;
using ExamenNet.Controllers.Interfaces;
using ExamenNet.Controllers.Services;

namespace ExamenNet
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IAgruparAsociadas, ExamenBetterWareServices>();
            container.RegisterType<IInegi, ExamenBetterWareServices>();
            
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}