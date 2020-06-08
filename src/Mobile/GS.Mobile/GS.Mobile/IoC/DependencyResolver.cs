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

    using GS.Mobile.ViewModels.Home;

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
            return this.container.IsRegistered<TInstance>() ? this.container.Resolve<TInstance>() : default;
        }

        #region Private Methods

        /// <summary>
        /// The register objects to current DI builder.
        /// </summary>
        private void RegisterToBuilder()
        {
            this.RegisterViewModels();
        }

        /// <summary>
        /// The register own types.
        /// </summary>
        private void RegisterViewModels()
        {
            this.builder.RegisterType<HomeViewModel>().As<IHomeViewModel>().SingleInstance();
        }
        #endregion
    }
}