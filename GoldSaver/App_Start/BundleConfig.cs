using System.Web;
using System.Web.Optimization;

namespace GoldSaver
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/underscore-min.js",
                        "~/Scripts/jquery.dd.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                        "~/Scripts/MyScripts/Services/CategoriesService.js",
                        "~/Scripts/MyScripts/Services/WalletsService.js",
                        "~/Scripts/MyScripts/Controllers/CategoriesController.js",
                        "~/Scripts/MyScripts/Controllers/WalletsController.js"));

            bundles.Add(new ScriptBundle("~/bundles/material").Include(
                        "~/Content/materialize/js/materialize.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/materialize/css/materialize.min.css",
                      "~/Content/Site.css",
                      "~/Content/google-material/material-icon.css"));
        }
    }
}
