// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Global.asax.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the WebApiApplication type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Authentication.Api
{
    using System.Web.Http;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;

    using Authentication.Api.IoC;

    /// <summary>
    /// The web api application main startup point.
    /// </summary>
    public class WebApiApplication : System.Web.HttpApplication
    {
        /// <summary>
        /// The dependency instance resolver.
        /// </summary>
        private static readonly IDependencyInjectionResolver InstanceResolver = new DependencyInjectionResolver();

        /// <summary>
        /// Starts the application.
        /// </summary>
        protected void Application_Start()
        {
            InstanceResolver.Initialize();
            GlobalConfiguration.Configuration.DependencyResolver = InstanceResolver.GetApiResolver();

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
