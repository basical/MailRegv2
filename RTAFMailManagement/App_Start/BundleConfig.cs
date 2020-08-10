using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.UI;

namespace RTAFMailManagement
{
    public class BundleConfig
    {
        // For more information on Bundling, visit https://go.microsoft.com/fwlink/?LinkID=303951
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/WebFormsJs").Include(
                            "~/Scripts/WebForms/WebForms.js",
                            "~/Scripts/WebForms/WebUIValidation.js",
                            "~/Scripts/WebForms/MenuStandards.js",
                            "~/Scripts/WebForms/Focus.js",
                            "~/Scripts/WebForms/GridView.js",
                            "~/Scripts/WebForms/DetailsView.js",
                            "~/Scripts/WebForms/TreeView.js",
                            "~/Scripts/WebForms/WebParts.js"));

            // Order is very important for these files to work, they have explicit dependencies
            bundles.Add(new ScriptBundle("~/bundles/MsAjaxJs").Include(
                    "~/Scripts/WebForms/MsAjax/MicrosoftAjax.js",
                    "~/Scripts/WebForms/MsAjax/MicrosoftAjaxApplicationServices.js",
                    "~/Scripts/WebForms/MsAjax/MicrosoftAjaxTimer.js",
                    "~/Scripts/WebForms/MsAjax/MicrosoftAjaxWebForms.js"));

            // Use the Development version of Modernizr to develop with and learn from. Then, when you’re
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                            "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/AdminLTE").Include(
                    "~/Content/plugins/jquery/jquery.min.js",
                    "~/Content/plugins/jquery-ui/jquery-ui.min.js",
                    "~/Content/plugins/bootstrap/js/bootstrap.bundle.min.js",
                    "~/Content/plugins/chart.js/Chart.min.js",
                    "~/Content/plugins/sparklines/sparkline.js",
                    "~/Content/plugins/jqvmap/jquery.vmap.min.js",
                    "~/Content/plugins/jqvmap/maps/jquery.vmap.usa.js",
                    "~/Content/plugins/jquery-knob/jquery.knob.min.js",
                    "~/Content/plugins/moment/moment.min.js",
                    "~/Content/plugins/daterangepicker/daterangepicker.js",
                    "~/Content/plugins/tempusdominus-bootstrap-4/js/tempusdominus-bootstrap-4.min.js",
                    "~/Content/plugins/summernote/summernote-bs4.min.js",
                    "~/Content/plugins/overlayScrollbars/js/jquery.overlayScrollbars.min.js",
                    "~/Content/plugins/datatables/jquery.dataTables.min.j",
                    "~/Content/plugins/datatables-bs4/js/dataTables.bootstrap4.min.js",
                    "~/Content/plugins/datatables-responsive/js/dataTables.responsive.min.js",
                    "~/Content/plugins/datatables-responsive/js/responsive.bootstrap4.min.js",
                    "~/Content/dist/js/adminlte.min.js",
                    "~/Content/dist/js/jquery.datetimepicker.full.min.js",
                    "~/Content/dist/js/pages/dashboard.js",
                    "~/Content/dist/js/demo.js"));
        }
    }
}