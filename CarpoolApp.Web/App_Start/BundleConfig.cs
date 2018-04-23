using System.Web;
using System.Web.Optimization;

namespace CarpoolApp.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/scripts").Include(
                      "~/Scripts/vendor/jquery/jquery.min.js",
                      "~/Scripts/vendor/bootstrap/bootstrap.min.js",
                      "~/Scripts/vendor/angular/angular.min.js",
                      "~/Scripts/vendor/angular-bootstrap/ui-bootstrap-tpls.min.js",
                      "~/Scripts/vendor/angular-ui-router/angular-ui-router.min.js",
                      "~/Scripts/vendor/angular-resource/angular-resource.min.js",
                      "~/Scripts/vendor/angular-loading-bar/loading-bar.min.js",
                      "~/Scripts/vendor/toastr/toastr.min.js",
                      "~/Scripts/vendor/angular-local-storage/angular-local-storage.min.js",
                      "~/Scripts/External/jquery.datetimepicker/jquery.datetimepicker.full.min.js",

                      "~/Scripts/app/carpoolApp.js",
                      "~/Scripts/app/Cars/carpoolApp.cars.js",
                      "~/Scripts/app/Posts/carpoolApp.posts.js")
                      .IncludeDirectory("~/Scripts/app/Services", "*.js", true)
                      .IncludeDirectory("~/Scripts/app/Directives", "*.js", true)
                      .IncludeDirectory("~/Scripts/app/Factories", "*.js", true)
                      .IncludeDirectory("~/Scripts/app/Controllers", "*.js", true)
                      .IncludeDirectory("~/Scripts/app/Cars/Controllers", "*.js",true)
                      .IncludeDirectory("~/Scripts/app/Posts/Controllers", "*.js", true)
                      .IncludeDirectory("~/Scripts/app/Posts/Directives", "*.js", true));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/scripts/vendor/bootstrap/bootstrap.min.css",
                      "~/scripts/vendor/angular-loading-bar/loading-bar.min.css",
                      "~/scripts/vendor/toastr/toastr.min.css",
                      "~/Scripts/External/jquery.datetimepicker/jquery.datetimepicker.min.css",
                      "~/Content/site.css"));
        }
    }
}
