using CarpoolApp.Web.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CarpoolApp.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            UnityConfig.Register(config);

            //ActionFilters
           // FilterConfig.RegisterWebAPIGlobalFilters(config);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Formatters.JsonFormatter.SerializerSettings.Converters.Add(new CarpoolDateTimeFormatConverter());
        }
    }
}
