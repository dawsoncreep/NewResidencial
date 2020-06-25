// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DependencyResolver.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   The dependency resolver.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GS.Mobile.IoC
{
    using Autofac;

    using GS.Mobile.BusinessLayer.Interfaces;
    using GS.Mobile.BusinessLayer.Processors;
    using GS.Mobile.DataLayer.Context;
    using GS.Mobile.DataLayer.Repository.Token;
    using GS.Mobile.DataLayer.Services;
    using GS.Mobile.DataLayer.Services.Authentication;
    using GS.Mobile.Share.FileSystem;
    using GS.Mobile.Share.Messages;
    using GS.Mobile.Share.Routing;
    using GS.Mobile.ViewModels.Home;
    using GS.Mobile.ViewModels.Login;
    using GS.Mobile.ViewModels.Master;
    using GS.Mobile.ViewModels.Menu;
    using GS.Mobile.Views;
    using GS.OperationalManagement.Configurations;

    using Microsoft.EntityFrameworkCore;

    using Xamarin.Forms;

    /// <summary>
    /// The dependency resolver.
    /// </summary>
    public class DependencyResolver
    {
        /// <summary>
        /// The context.
        /// </summary>
        private readonly DbContext context;

        /// <summary>
        /// The config file path.
        /// </summary>
        private readonly string configFilePath;

        /// <summary>
        /// The DI container.
        /// </summary>
        private IContainer container;

        /// <summary>
        /// The DI builder.
        /// </summary>
        private ContainerBuilder builder;

        /// <summary>
        /// Initializes a new instance of the <see cref="DependencyResolver"/> class.
        /// </summary>
        public DependencyResolver()
        {
            if (this.builder == null)
            {
                this.builder = new ContainerBuilder();
            }

            var fileSystem = DependencyService.Get<IFileSystem>();

            if (string.IsNullOrEmpty(this.configFilePath))
            {
                this.configFilePath = fileSystem.GetConfigFilePath();
            }

            if (this.context == null)
            {
                var path = fileSystem.GetDatabasePath();
                this.context = new ApplicationContext(path);
            }
        }

        /// <summary>
        /// Initialize the DI module with a specific hardware instance.
        /// </summary>
        public void Initialize()
        {
            if (this.container != null)
            {
                return;
            }

            this.RegisterToBuilder();
            this.container = this.builder.Build();
        }

        /// <summary>
        /// Cleans loaded dependencies.
        /// </summary>
        public void Clean()
        {
            this.builder = null;
            this.container.Dispose();
            this.container = null;
        }

        /// <summary>
        /// Resolves an instance.
        /// </summary>
        /// <typeparam name="TInstance">
        /// Instance to be resolve.
        /// </typeparam>
        /// <returns>
        /// The <see cref="TInstance"/>.
        /// </returns>
        public TInstance Resolve<TInstance>()
        {
            return this.container.Resolve<TInstance>();
        }

        #region Private Methods

        /// <summary>
        /// The register objects to current DI builder.
        /// </summary>
        private void RegisterToBuilder()
        {
            this.RegisterTools();
            this.RegisterViewModels();
            this.RegisterProcessors();
            this.RegisterRepositories();
            this.RegisterServices();
        }

        /// <summary>
        /// Register all view models.
        /// </summary>
        private void RegisterViewModels()
        {
            this.builder.RegisterType<MasterViewModel>().As<IMasterViewModel>().SingleInstance();
            this.builder.RegisterType<LoginViewModel>().As<ILoginViewModel>().SingleInstance();
            this.builder.RegisterType<MenuViewModel>().As<IMenuViewModel>().SingleInstance();
            this.builder.RegisterType<HomeViewModel>().As<IHomeViewModel>().SingleInstance();
        }

        /// <summary>
        /// Register all view model tools.
        /// </summary>
        private void RegisterTools()
        {
            this.builder.RegisterType<RoutingService>().As<IRoutingService>().SingleInstance();
            this.builder.Register(c => DependencyService.Resolve<IMessageService>()).As<IMessageService>().SingleInstance();
            this.builder.RegisterType<ApplicationDataManager>().As<IConfigurationManager>().WithParameter("configFilePath", this.configFilePath);
        }

        /// <summary>
        /// Register all processors.
        /// </summary>
        private void RegisterProcessors()
        {
            this.builder.RegisterType<SessionProcessor>().As<ISessionProcessor>();
            this.builder.RegisterType<TokenProcessor>().As<ITokenProcessor>();
            this.builder.RegisterType<UserProcessor>().As<IUserProcessor>();
        }

        /// <summary>
        /// Register all repositories.
        /// </summary>
        private void RegisterRepositories()
        {
            this.builder.RegisterType<TokenRepository>().As<ITokenRepository>().WithParameter("context", this.context);
        }

        /// <summary>
        /// Register all services.
        /// </summary>
        private void RegisterServices()
        {
            this.builder.RegisterType<ServiceManager>().As<IServiceManager>();
            this.builder.RegisterType<AuthenticationService>().As<IAuthenticationService>();
        }
        #endregion
    }
}