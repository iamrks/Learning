using Owin;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Learning.WebApi
{
    public class Startup
    {
        public static HttpConfiguration config = new HttpConfiguration();

        public void Configuration(IAppBuilder app)
        {
            WebApiConfig.Register(config);

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            app.UseWebApi(config);
        }
    }
}