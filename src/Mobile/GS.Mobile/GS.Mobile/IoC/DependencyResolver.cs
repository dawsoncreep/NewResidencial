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
    using GS.Mobile.Tools.Routing;
    using GS.Mobile.ViewModels.Home;
    using GS.Mobile.ViewModels.Login;
    using GS.Mobile.ViewModels.Master;

    /// <summary>
    /// The dependency resolver.
    /// </summary>
    public class DependencyResolver
    {
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
        }

        /// <summary>
        /// Register all view models.
        /// </summary>
        private void RegisterViewModels()
        {
            this.builder.RegisterType<MasterViewModel>().As<IMasterViewModel>().SingleInstance();
            this.builder.RegisterType<HomeViewModel>().As<IHomeViewModel>().SingleInstance();
            this.builder.RegisterType<LoginViewModel>().As<ILoginViewModel>().SingleInstance();
        }

        /// <summary>
        /// Register all view model tools.
        /// </summary>
        private void RegisterTools()
        {
            this.builder.RegisterType<RoutingService>().As<IRoutingService>().SingleInstance();
        }

        /// <summary>
        /// Register all processors.
        /// </summary>
        private void RegisterProcessors()
        {
            this.builder.RegisterType<SessionProcessor>().As<ISessionProcessor>();
        }

        #endregion
    }
}