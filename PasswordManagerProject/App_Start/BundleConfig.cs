using System.Web;
using System.Web.Optimization;

namespace PasswordManagerProject
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            StyleBundle(bundles);
            ScriptBundle(bundles);
        }

        public static void StyleBundle(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/css")
                     .Include("~/Content/bootstrap.css")
                     .Include("~/Content/mystyles.css")
                     .Include("~/Content/font-awesome.css"));
        }

        public static void ScriptBundle(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/js")
                     .Include("~/Scripts/jquery-{version}.js")
                     .Include("~/Scripts/bootstrap.js"));
        }

    }
}