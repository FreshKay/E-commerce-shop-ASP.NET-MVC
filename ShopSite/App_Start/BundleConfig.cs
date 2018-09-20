using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace ShopSite.App_Start
{
    public class BundleConfig
    {

        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/css/style.css",
                      "~/Content/css/bootstrap.css",
                      "~/Content/css/megamenu.css",
                      "~/Content/css/owl.carousel.css",
                      "~/Content/css/etalage.css"                      
                      ));

            
        }
    }
}