using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Owin;
using Owin;
using SimpleInjector;

namespace BoundedContext2
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

            HttpConfiguration config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            appBuilder.UseWebApi(config);

            container.RegisterWebApiControllers(config, Assembly.GetExecutingAssembly());
        }
    }
}
