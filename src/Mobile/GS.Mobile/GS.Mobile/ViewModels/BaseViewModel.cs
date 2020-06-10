﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BaseViewModel.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the BaseViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GS.Mobile.ViewModels
{
    using System;
    using System.ComponentModel;
    using System.Threading.Tasks;
    using System.Windows.Input;

    using GS.Mobile.BusinessLayer.Interfaces;
    using GS.Mobile.Tools.Routing;
    using GS.Mobile.ViewModels.Extensions;
    using GS.Mobile.Views.Login;

    using Xamarin.Forms;

    /// <inheritdoc />
    /// <summary>
    /// The base view model.
    /// </summary>
    public abstract class BaseViewModel : IViewModel
    {
        /// <summary>
        /// The routing service.
        /// </summary>
        protected readonly IRoutingService RoutingService;

        /// <summary>
        /// The session processor.
        /// </summary>
        protected readonly ISessionProcessor SessionProcessor;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseViewModel"/> class.
        /// </summary>
        /// <param name="routingService">
        /// The routing Service.
        /// </param>
        /// <param name="sessionProcessor">
        /// The session Processor.
        /// </param>
        protected BaseViewModel(IRoutingService routingService, ISessionProcessor sessionProcessor)
        {
            this.RoutingService = routingService;
            this.SessionProcessor = sessionProcessor;

            // TODO: Manage dependencies thorough constructor.
            this.ValidateAuthorizationRules();
        }

#pragma warning disable 067

        /// <inheritdoc />
        public event PropertyChangedEventHandler PropertyChanged;
#pragma warning restore 067

        /// <inheritdoc />
        public bool IsBusy { get; set; }

        /// <inheritdoc />
        public string PageTitle { get; set; }

        /// <inheritdoc />
        public virtual ICommand OnLoadCommand => new Command(async () => await Task.CompletedTask);

        /// <inheritdoc />
        public virtual ICommand OnCloseCommand => new Command(async () => await Task.CompletedTask);

        /// <inheritdoc />
        public async Task CleanUi()
        {
            await Task.CompletedTask;
        }

        #region private Methods

        /// <summary>
        /// The validate user roles.
        /// </summary>
        private void ValidateAuthorizationRules()
        {
            if (this.IsAnonymousAllowed())
            {
                return;
            }

            if (this.IsAuthorizationRequired())
            {
                var viewModelRoles = this.GetViewModelAuthorizationRoles();
                var isValid = this.SessionProcessor.ValidateCurrentSession(viewModelRoles);

                if (!isValid)
                {
                    this.RoutingService.PushAsync<LoginPage>().GetAwaiter();
                }
            }
            else
            {
                throw new Exception("'AllowAnonymous' or 'Authorization' attribute is missing.");
            }
        }
        #endregion
    }
}