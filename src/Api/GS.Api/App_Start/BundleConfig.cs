// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BundleConfig.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the BundleConfig type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Authentication.Api
{
    using System.Diagnostics.CodeAnalysis;
    using System.Web.Optimization;

    /// <summary>
    /// The bundle config.
    /// </summary>
    [ExcludeFromCodeCoverage]
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
            bundles.Add(new StyleBundle("~/Resources/css")
                .Include("~/Content/css/bootstrap.min.css")
                .Include("~/Content/css/site.css"));

            bundles.Add(new ScriptBundle("~/Resources/js").Include("~/Content/js/jquery.min.js")
                    .Include("~/Content/js/bootstrap.min.js").Include("~/Content/js/jquery.easing.min.js")
                    .Include("~/Content/js/site.js"));
        }
    }
}