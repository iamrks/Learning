using Unity;
using System;
using System.Linq;
using Unity.Lifetime;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.Cors;
using Newtonsoft.Json.Serialization;
using Learning.Data;
using Learning.WebApi.DI;
using Learning.BusinessLogic.Infrastructure.Interfaces;
using Learning.WebApi.Filters;

namespace Learning.WebApi
{
    public static class WebApiConfig
    {
        public static Type IUnitOfWork { get; private set; }

        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var container = new UnityContainer();
            container.RegisterType<IUnitOfWork, UnitOfWork>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityResolver(container);

            // Configure Json response type
            ConfigureWebApiReponse(config);

            // Web API routes
            config.MapHttpAttributeRoutes();

            // Enable CORS
            var corsAttr = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(corsAttr);

            // Register global filters
            config.Filters.Add(new GZipCompressionAttribute());

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }

        private static void ConfigureWebApiReponse(HttpConfiguration config)
        {            
            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }
    }
}
