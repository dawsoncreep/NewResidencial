// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DependencyController.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the WebApiApplication type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GuizzySeguridad.Web.IoC
{
    using System.Diagnostics.CodeAnalysis;
    using System.Web.Mvc;

    using Autofac;
    using Autofac.Integration.Mvc;

    /// <summary>
    /// The dependency resolver.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class DependencyController
    {
        /// <summary>
        /// The DI builder.
        /// </summary>
        private static readonly ContainerBuilder Builder;

        /// <summary>
        /// Initializes static members of the <see cref="DependencyController"/> class. 
        /// </summary>
        static DependencyController()
        {
            Builder = new ContainerBuilder();
        }

        /// <summary>
        /// Gets the ASP MVC API dependency resolver to be used.
        /// </summary>
        public static void SetDependencyResolver()
        {
            RegisterToBuilder();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(Builder.Build()));
        }

        #region Private Methods

        /// <summary>
        /// Registers dependencies to container builder.
        /// </summary>
        private static void RegisterToBuilder()
        {
            RegisterWebApiControllers();
            RegisterCommonLayerObjects();
            RegisterBusinessLayerObjects();
            RegisterDataLayerObjects();
        }

        /// <summary>
        /// Registers all web application program interface controllers.
        /// </summary>
        private static void RegisterWebApiControllers()
        {
            Builder.RegisterControllers(typeof(MvcApplication).Assembly);
        }

        /// <summary>
        /// Registers all common objects.
        /// </summary>
        private static void RegisterCommonLayerObjects()
        {
            // Builder.RegisterType<class>().As<interface>();
        }

        /// <summary>
        /// Registers all business layer objects.
        /// </summary>
        private static void RegisterBusinessLayerObjects()
        {
            // Builder.RegisterType<class>().As<interface>();
        }

        /// <summary>
        /// Registers all data layer objects.
        /// </summary>
        private static void RegisterDataLayerObjects()
        {
            // Builder.RegisterType<class>().As<interface>();
        }
        #endregion
    }
}