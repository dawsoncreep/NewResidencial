// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WebApiConfig.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the WebApiConfig type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Residential.Identity
{
    using System.Web.Http;

    /// <summary>
    /// The web api config.
    /// </summary>
    public static class WebApiConfig
    {
        /// <summary>
        /// Register application basic transport configurations.
        /// </summary>
        /// <param name="config">
        /// The configurations.
        /// </param>
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });
        }
    }
}
