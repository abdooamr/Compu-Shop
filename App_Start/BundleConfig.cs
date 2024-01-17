using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.UI;

namespace web_project_asp
{
    public class BundleConfig
    {
        // For more information on Bundling, visit https://go.microsoft.com/fwlink/?LinkID=303951
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/WebFormsJs").Include(
                            "/wwwroot/Scripts/WebForms/WebForms.js",
                            "/wwwroot/Scripts/WebForms/WebUIValidation.js",
                            "/wwwroot/Scripts/WebForms/MenuStandards.js",
                            "/wwwroot/Scripts/WebForms/Focus.js",
                            "/wwwroot/Scripts/WebForms/GridView.js",
                            "/wwwroot/Scripts/WebForms/DetailsView.js",
                            "/wwwroot/Scripts/WebForms/TreeView.js",
                            "/wwwroot/Scripts/WebForms/WebParts.js"));

            // Order is very important for these files to work, they have explicit dependencies
            bundles.Add(new ScriptBundle("~/bundles/MsAjaxJs").Include(
                    "/wwwroot/Scripts/WebForms/MsAjax/MicrosoftAjax.js",
                    "/wwwroot/Scripts/WebForms/MsAjax/MicrosoftAjaxApplicationServices.js",
                    "/wwwroot/Scripts/WebForms/MsAjax/MicrosoftAjaxTimer.js",
                    "/wwwroot/Scripts/WebForms/MsAjax/MicrosoftAjaxWebForms.js"));

            // Use the Development version of Modernizr to develop with and learn from. Then, when you’re
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                            "/wwwroot/Scripts/modernizr-*"));
        }
    }
}