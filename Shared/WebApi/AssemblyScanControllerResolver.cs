using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Dispatcher;

namespace Shared.WebApi
{
    public class AssemblyScanControllerResolver
            : IHttpControllerTypeResolver
    {
        private readonly HttpConfiguration _configuration;
        private readonly Assembly[] _assemblies;

        public AssemblyScanControllerResolver(HttpConfiguration configuration, Assembly[] assemblies)
        {
            _configuration = configuration;
            _assemblies = assemblies;
        }

        public ICollection<Type> GetControllerTypes(IAssembliesResolver assembliesResolver)
        {
            var controllers = _assemblies.SelectMany(a => a.GetExportedTypes())
                .Where(t => typeof(ApiController).IsAssignableFrom(t))
                .Select(t => t)
                .ToArray();

            return controllers;
        }
    }
}
