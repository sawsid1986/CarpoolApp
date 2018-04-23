using CarpoolApp.Web.Filters;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace CarpoolApp.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterWebAPIGlobalFilters(HttpConfiguration config)
        {
            config.Filters.Add(new ValidateModelAttribute());
        }
    }
}
