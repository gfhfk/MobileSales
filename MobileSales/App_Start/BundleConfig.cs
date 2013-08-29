using System.Web;
using System.Web.Optimization;

namespace MobileSales
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/knockout").Include(
                      "~/Scripts/knockout-*"));
            bundles.Add(new ScriptBundle("~/bundles/breeze").Include(
         "~/Scripts/q.js",
         "~/Scripts/datajs-{version}.js",
         "~/Scripts/breeze.debug.js"
         ));
            bundles.Add(new ScriptBundle("~/bundles/dx").Include(
                       "~/Scripts/dx.phonejs.js",
                       "~/Scripts/globalize.js",
                       "~/Scripts/layout/NavbarLayout.js",
                       "~/Scripts/layout/SlideOutLayout.js"
                       ));

            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                       "~/Scripts/App/app.init.js",
                       "~/Scripts/App/logger.js",
                       "~/Scripts/App/app.model.js",
                       "~/Scripts/App/app.dataservice.js",
                       "~/Scripts/App/app.viewmodel.js"
                       ));


            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/bootstrap-responsive.css"));
            bundles.Add(new StyleBundle("~/Content/dx").Include(
                      "~/Content/dx/dx.*"));
            bundles.Add(new StyleBundle("~/Content/layout").Include(
             "~/Content/dx/layout/SlideOutLayout.css",
             "~/Content/dx/layout/DesktopLayout.css",
              "~/Content/dx/layout/NavbarLayout.css"));


        }
    }
}
