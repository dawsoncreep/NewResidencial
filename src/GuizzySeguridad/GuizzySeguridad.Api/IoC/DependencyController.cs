// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DependencyController.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the DependencyController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GuizzySeguridad.Api.IoC
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Reflection;
    using System.Web.Http.Dependencies;

    using Autofac;
    using Autofac.Integration.WebApi;

    using GuizzySeguridad.Common.OperationalManagement.Abstractions;
    using GuizzySeguridad.Common.OperationalManagement.Abstractions.Interfaces;
    using GuizzySeguridad.Common.OperationalManagement.Generals;
    using GuizzySeguridad.Common.OperationalManagement.Interfaces;
    using GuizzySeguridad.Common.Server.BusinessLayer.Facade;
    using GuizzySeguridad.Common.Server.BusinessLayer.Processors;
    using GuizzySeguridad.Common.Server.DataLayer.Repositories;
    using GuizzySeguridad.Common.Server.Interfaces.Facade;
    using GuizzySeguridad.Common.Server.Interfaces.Processor;
    using GuizzySeguridad.Common.Server.Interfaces.Repository;

    using Microsoft.EntityFrameworkCore;

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
        /// <returns>
        /// The <see cref="IDependencyResolver"/>.
        /// </returns>
        public static IDependencyResolver GetDependencyResolver()
        {
            RegisterToBuilder();
            return new AutofacWebApiDependencyResolver(Builder.Build());
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
            Builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
        }

        /// <summary>
        /// Registers all common objects.
        /// </summary>
        private static void RegisterCommonLayerObjects()
        {
            var isReleaseVersion = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["IsReleaseVersion"]);

            if (isReleaseVersion)
            {
                Builder.RegisterType<WindowsEventLogger>().As<ILogger>();
            }
            else
            {
                Builder.RegisterType<DevelopmentLogger>().As<ILogger>();
            }

            Builder.RegisterType<ApplicationLogger>().As<IApplicationLogger>();
            Builder.RegisterType<DummyConfigurationManager>().As<IConfigurationManager>();
            Builder.RegisterType<DataManager>().As<IDataManager>();
        }

        /// <summary>
        /// Registers all business layer objects.
        /// </summary>
        private static void RegisterBusinessLayerObjects()
        {
            Builder.RegisterType<UserFacade>().As<IUserFacade>();
            Builder.RegisterType<UserProcessor>().As<IUserProcessor>();
            Builder.RegisterType<TokenProcessor>().As<ITokenProcessor>();
        }

        /// <summary>
        /// Registers all data layer objects.
        /// </summary>
        private static void RegisterDataLayerObjects()
        {
            Builder.RegisterType<ApplicationContext>().As<DbContext>().PreserveExistingDefaults();
            Builder.RegisterType<UserRepository>().As<IUserRepository>();
            Builder.RegisterType<RoleRepository>().As<IRolRepository>();
        }
        #endregion
    }
}