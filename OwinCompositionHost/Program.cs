using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;
using Owin;

namespace OwinCompositionHost
{
    class Program
    {
        static void Main(string[] args)
        {

            var context1 = new BoundedContext1.Context();
            var context2 = new BoundedContext2.Context();


            using (WebApp.Start("http://localhost:8001", app =>
            {
                app.Map("/context1", appBuilder => context1.RegisterApp(appBuilder));
                app.Map("/context2", appBuilder => context2.RegisterApp(appBuilder));
            }))
            {

                Console.ReadLine();
            }
        }
    }
}
