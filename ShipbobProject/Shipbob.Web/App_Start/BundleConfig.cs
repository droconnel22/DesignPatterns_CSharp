using System.Web;
using System.Web.Optimization;

namespace Shipbob.Web
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

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                  "~/Scripts/bootstrap.js"));


            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                "~/Scripts/angular.js",
                "~/Scripts/angular-ui-router.js",
                "~/Scripts/angular-local-storage.js"));

            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                "~/App/app.js",
                "~/App/Utility/app.Configuration.js",
                "~/App/Orders/order.Factory.js",
                "~/App/Orders/order.Service.js",
                "~/App/Orders/order.Controller.js",
                "~/App/Orders/order.Inventory.Directive.js",
                 "~/App/Orders/order.StateAbbreviation.Directive.js",
                  "~/App/Orders/Order.ItemInput.Controller.js",
                  "~/App/Orders/order.ItemInput.Directive.js"
                ));


            bundles.Add(new StyleBundle("~/Content/css").Include(
                  "~/Content/font-awesome.css",
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/OrderPageStyles").Include(
                "~/Content/OrderPage.css"));
        }
    }
}
