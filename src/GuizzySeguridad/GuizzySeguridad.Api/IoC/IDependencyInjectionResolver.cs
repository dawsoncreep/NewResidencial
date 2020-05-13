// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDependencyInjectionResolver.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the IResolver type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GuizzySeguridad.Api.IoC
{
    using System;
    using System.Web.Http.Dependencies;

    /// <summary>
    /// The Dependency Resolver interface.
    /// </summary>
    public interface IDependencyInjectionResolver : IDisposable
    {
        /// <summary>
        /// Initialize the DI module with a specific hardware instance.
        /// </summary>
        void Initialize();

        /// <summary>
        /// Gets the <see cref="IDependencyResolver"/> from 'AutoFac' IoC engine.
        /// </summary>
        /// <returns>
        /// The <see cref="IDependencyResolver"/>.
        /// </returns>
        IDependencyResolver GetApiResolver();

        /// <summary>
        /// Resolves an instance.
        /// </summary>
        /// <typeparam name="TInstance">
        /// Instance to be resolve.
        /// </typeparam>
        /// <returns>
        /// Specific instance to be resolved.
        /// </returns>
        TInstance Resolve<TInstance>();
    }
}