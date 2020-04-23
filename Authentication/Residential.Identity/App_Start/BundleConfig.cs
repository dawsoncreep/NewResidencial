// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BundleConfig.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the BundleConfig type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Residential.Identity
{
    using System.Web.Optimization;

    /// <summary>
    /// The bundle config.
    /// </summary>
    public class BundleConfig
    {
        /// <summary>
        /// Register application bundles.
        /// </summary>
        /// <param name="bundles">
        /// The bundles to be registered.
        /// </param>
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/Scripts/jquery-{version}.js"));
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include("~/Scripts/modernizr-*"));
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include("~/Scripts/bootstrap.js"));
            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/bootstrap.css", "~/Content/site.css"));
        }
    }
}
