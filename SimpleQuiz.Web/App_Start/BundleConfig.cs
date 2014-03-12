using System.Web;
using System.Web.Optimization;

namespace SimpleQuiz.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

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
                      "~/Content/bootstrap.slate.css",
                      "~/Content/site.css",
                      "~/Content/toaster.css",
                      "~/Content/loading-bar.css"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                    "~/Scripts/angular.js",
                    "~/Scripts/angular-route.js",
                    "~/Scripts/angular-resource.js",
                    "~/Scripts/angular-animate.js",
                    "~/Scripts/toaster.js",
                    "~/Scripts/ui-bootstrap-0.10.0.js",
                    "~/Scripts/ui-bootstrap-tpls-0.10.0.js",
                    "~/Scripts/loading-bar.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                    "~/app/app.js",
                    "~/app/directives/directives.js",
                    "~/app/filters/filters.js",
                    "~/app/controllers/listControllerBase.js",
                    "~/app/controllers/modalControllerBase.js",
                    "~/app/controllers/question/questionListController.js",
                    "~/app/controllers/quiz/quizAddController.js",
                    "~/app/controllers/quiz/quizDeleteController.js",
                    "~/app/controllers/quiz/quizEditController.js",
                    "~/app/controllers/quiz/quizListController.js",
                    "~/app/controllers/package/packageAddController.js",
                    "~/app/controllers/package/packageDeleteController.js",
                    "~/app/controllers/package/packageEditController.js",
                    "~/app/controllers/package/packageListController.js",
                    "~/app/controllers/question/categoryQuestionAddController.js",
                    "~/app/controllers/question/openQuestionAddController.js",
                    "~/app/controllers/question/sortQuestionAddController.js",
                    "~/app/controllers/question/testQuestionAddController.js",
                    "~/app/services/packageService.js",
                    "~/app/services/quizService.js",
                    "~/app/services/questionService.js"
                ));
        }
    }
}
