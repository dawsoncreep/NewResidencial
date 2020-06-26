﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRoutingService.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the IRoutingService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GS.Mobile.Share.Routing
{
    using System;
    using System.Threading.Tasks;

    using Xamarin.Forms;

    /// <summary>
    /// The application routing service interface.
    /// </summary>
    public interface IRoutingService
    {
        /// <summary>
        /// The set master.
        /// </summary>
        /// <typeparam name="TPage">
        /// <see cref="ContentPage"/> to be display
        /// </typeparam>
        void SetMaster<TPage>();
        
        /// <summary>
        /// The push async.
        /// </summary>
        /// <typeparam name="TPage">
        /// <see cref="ContentPage"/> to be display
        /// </typeparam>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task PushAsync<TPage>() where TPage : ContentPage;

        /// <summary>
        /// The push async.
        /// </summary>
        /// <param name="pageType">
        /// The page type.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task PushAsync(Type pageType);

        /// <summary>
        /// The pop async.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task PopAsync();

        /// <summary>
        /// Pops all pages to root page.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task PopToRootAsync();
    }
}