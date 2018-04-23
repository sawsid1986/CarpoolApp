using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using CarpoolApp.Service.Configuration;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Optimization;

[assembly: OwinStartup(typeof(CarpoolApp.Web.Startup))]

namespace CarpoolApp.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            AutoMapperServiceConfiguration.InitializeAutomapper();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var webApiConfiguration = new HttpConfiguration();            
            WebApiConfig.Register(webApiConfiguration);
            OAuthConfig.ConfigureAuth(app);            
            app.UseWebApi(webApiConfiguration);
        }        
    }
}
