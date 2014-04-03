using System.Web;
using System.Web.Optimization;

namespace NgQuiz.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Scripts/vendor").Include(
                        "~/Scripts/jquery-2.0.3.js",
                        "~/Scripts/angular.js",
                        "~/Scripts/angular-animate.js",
                        "~/Scripts/angular-route.js",
                        "~/Scripts/angular-sanitize.js",
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/toastr.js",
                        "~/Scripts/moment.js",
                        "~/Scripts/ui-bootstrap-tpls-0.10.0.js",
                        "~/Scripts/spin.js", 
                        "~/Scripts/q.js",
                        "~/Scripts/breeze.debug.js",
                        "~/Scripts/breeze.angular.js",
                        "~/Scripts/breeze.directives.js",
                        "~/Scripts/breeze.saveErrorExtensions.js"));
                        
            bundles.Add(new ScriptBundle("~/Scripts/bootstrap").Include(
                        "~/app/app.js",
                        "~/app/config.js",
                        "~/app/config.exceptionHandler.js",
                        "~/app/config.route.js"));

            bundles.Add(new ScriptBundle("~/app/common").Include(
                        "~/app/common/common.js",
                        "~/app/common/logger.js",
                        "~/app/common/spinner.js"));

            bundles.Add(new ScriptBundle("~/app/common/bootstrap").Include(
                        "~/app/common/bootstrap/bootstrap.dialog.js"));

            bundles.Add(new ScriptBundle("~/app").Include(
                        "~/app/admin/admin.js",
                        "~/app/dashboard/dashboard.js",
                        "~/app/layout/shell.js",
                        "~/app/layout/sidebar.js"));

            bundles.Add(new ScriptBundle("~/app/services").Include(
                        "~/app/services/entityManagerFactory.js",
                        "~/app/services/datacontext.js",
                        "~/app/services/directives.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/ie10mobile.css",
                "~/Content/bootstrap.min.css",
                "~/Content/font-awesome.min.css",
                "~/Content/toastr.css",
                "~/Content/customtheme.css",
                "~/Content/styles.css",
                "~/Content/breeze.directives.css"));
        }
    }
}
