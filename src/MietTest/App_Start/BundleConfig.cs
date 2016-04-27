using System.Web;
using System.Web.Optimization;

namespace MietTest
{
    public class BundleConfig
    {
        //Дополнительные сведения об объединении см. по адресу: http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            var transform = new CssRewriteUrlTransform();
            bundles.Add(new StyleBundle("~/Bundles/css/main")
                .Include("~/Content/Site.css", transform)); 

            bundles.Add(new ScriptBundle("~/Bundles/js/main").Include(
                       "~/Scripts/angular.js",
                       "~/Scripts/angular-ui/ui-bootstrap-tpls.js",
                       "~/Scripts/i18n/angular-locale_ru-ru.js",
                       "~/Scripts/jquery-1.10.2.js",
                       "~/Scripts/bootstrap.js",
                       "~/Scripts/angular-filter.js"
                ));

            bundles.Add(new ScriptBundle("~/Bundles/js/app")
                .IncludeDirectory("~/app/Test", "*.js")
                .IncludeDirectory("~/app/Modal", "*.js")
                .IncludeDirectory("~/app/Generic", "*.js"));
                

#if DEBUG
            System.Web.Optimization.BundleTable.EnableOptimizations = false;
#else
            System.Web.Optimization.BundleTable.EnableOptimizations = true;
#endif
           

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js",
            //          "~/Scripts/respond.js"));

            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //          "~/Content/bootstrap.css",
            //          "~/Content/site.css"));
        }
    }
}
