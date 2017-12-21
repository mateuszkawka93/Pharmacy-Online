﻿using System.Web.Optimization;

namespace Pharmacy_Online
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jqueryAndUI").Include
                ("~/Scripts/jquery-{version}.js",
                "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new StyleBundle("~/Content/themes/base/css")
                .Include("~/Content/themes/base/core.css",
                    "~/Content/themes/base/autocomplete.css",
                    "~/Content/themes/base/theme.css",
                    "~/Content/themes/base/menu.css"
                ));


            ;
        }
    }
}