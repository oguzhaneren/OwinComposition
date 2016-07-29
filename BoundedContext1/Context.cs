using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using System.Web.Http.Routing;
using BoundedContext1.Controllers;
using Microsoft.Owin;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Owin;
using Shared.WebApi;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;

namespace BoundedContext1
{
    public class Context
    {
        public void HandleRequests(Func<IOwinContext, Task> handler)
        {

        }

        public void RegisterApp(IAppBuilder appBuilder)
        {
            var container = new Container();
            appBuilder.Use((context, next) =>
            {
                return next();
            });


            var assemblies = new[] {Assembly.GetExecutingAssembly()};
            var config = new HttpConfiguration();
            config.Formatters.Clear();
            config.Formatters.Add(new JsonMediaTypeFormatter());
            config.Formatters.JsonFormatter.SerializerSettings.Formatting = Formatting.None;
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            config.Services.Replace(typeof(IHttpControllerTypeResolver), new AssemblyScanControllerResolver(config, assemblies));

            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            container.RegisterWebApiControllers(config, assemblies);

            appBuilder.UseWebApi(config);
         
            container.Verify();
            config.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);


        }
    }

  
}
