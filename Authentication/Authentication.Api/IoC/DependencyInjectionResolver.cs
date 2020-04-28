// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DependencyInjectionResolver.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the DependencyInjectionResolver type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Authentication.Api.IoC
{
    using System;
    using System.Reflection;
    using System.Web.Http.Dependencies;

    using Authentication.BusinessLayer.Facade;
    using Authentication.BusinessLayer.Interfaces.Facade;
    using Authentication.BusinessLayer.Interfaces.Processor;
    using Authentication.BusinessLayer.Processors;
    using Authentication.DataLayer.Interfaces;
    using Authentication.DataLayer.Repositories;
    using Authentication.OperationalManagement.Abstractions;
    using Authentication.OperationalManagement.Abstractions.Interfaces;
    using Authentication.OperationalManagement.Common;
    using Authentication.OperationalManagement.Interfaces;

    using Autofac;
    using Autofac.Integration.WebApi;

    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// The dependency resolver.
    /// </summary>
    public class DependencyInjectionResolver : IDependencyInjectionResolver
    {
        #region Fields

        /// <summary>
        /// The disposed flag.
        /// </summary>
        private bool disposed;

        /// <summary>
        /// The DI container.
        /// </summary>
        private IContainer container;

        /// <summary>
        /// The DI builder.
        /// </summary>
        private ContainerBuilder builder;
        #endregion

        /// <inheritdoc />
        public void Initialize()
        {
            if (this.builder == null)
            {
                this.builder = new ContainerBuilder();
            }

            this.RegisterToBuilder();

            this.container = this.builder.Build();
        }

        /// <inheritdoc />
        public IDependencyResolver GetApiResolver()
        {
            return new AutofacWebApiDependencyResolver(this.container);
        }

        /// <inheritdoc />
        public TInstance Resolve<TInstance>()
        {
            return this.container.IsRegistered<TInstance>() ? this.container.Resolve<TInstance>() : default;
        }

        /// <inheritdoc />
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        #region Private Methods

        /// <summary>
        /// Disposed pattern implementation.
        /// </summary>
        /// <param name="disposing">
        /// The disposing.
        /// </param>
        protected virtual void Dispose(bool disposing)
        {
            if (this.disposed)
            {
                return;
            }

            if (disposing)
            {
                this.container.Dispose();
                this.builder = null;
                this.container = null;
            }

            this.disposed = true;
        }

        /// <summary>
        /// Registers dependencies to container builder.
        /// </summary>
        private void RegisterToBuilder()
        {
            this.RegisterWebApiControllers();
            this.RegisterCommonLayerObjects();
            this.RegisterBusinessLayerObjects();
            this.RegisterDataLayerObjects();
        }

        /// <summary>
        /// Registers all web api controllers.
        /// </summary>
        private void RegisterWebApiControllers()
        {
            this.builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
        }

        /// <summary>
        /// Registers all common objects.
        /// </summary>
        private void RegisterCommonLayerObjects()
        {
            this.builder.RegisterType<DummyConfigurationManager>().As<IConfigurationManager>();
            this.builder.RegisterType<DataManager>().As<IDataManager>();

            var isReleaseVersion = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["IsReleaseVersion"]);

            if (isReleaseVersion)
            {
                this.builder.RegisterType<WindowsEventLogger>().As<ILogger>();
            }
            else
            {
                this.builder.RegisterType<DevelopmentLogger>().As<ILogger>();
            }

            this.builder.RegisterType<ApplicationLogger>().As<IApplicationLogger>();
        }

        /// <summary>
        /// Registers all business layer objects.
        /// </summary>
        private void RegisterBusinessLayerObjects()
        {
            this.builder.RegisterType<UserFacade>().As<IUserFacade>();
            this.builder.RegisterType<UserProcessor>().As<IUserProcessor>();
            this.builder.RegisterType<TokenProcessor>().As<ITokenProcessor>();
        }

        /// <summary>
        /// Registers all data layer objects.
        /// </summary>
        private void RegisterDataLayerObjects()
        {
            this.builder.RegisterType<ApplicationContext>().As<DbContext>().PreserveExistingDefaults();
            this.builder.RegisterType<UserRepository>().As<IUserRepository>();
        }
        #endregion
    }
}