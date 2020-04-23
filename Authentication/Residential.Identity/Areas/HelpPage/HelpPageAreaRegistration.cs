// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HelpPageAreaRegistration.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the HelpPageAreaRegistration type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Residential.Identity.Areas.HelpPage
{
    using System.Web.Http;
    using System.Web.Mvc;

    using Residential.Identity.Areas.HelpPage.App_Start;

    /// <summary>
    /// The help page area registration.
    /// </summary>
    public class HelpPageAreaRegistration : AreaRegistration
    {
        /// <summary>
        /// Gets the area name.
        /// </summary>
        public override string AreaName => "HelpPage";

        /// <summary>
        /// Register this area.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "HelpPage_Default",
                "Help/{action}/{apiId}",
                new { controller = "Help", action = "Index", apiId = UrlParameter.Optional });

            HelpPageConfig.Register(GlobalConfiguration.Configuration);
        }
    }
}