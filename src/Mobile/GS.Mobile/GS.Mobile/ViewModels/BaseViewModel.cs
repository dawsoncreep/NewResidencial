// --------------------------------------------------------------------------------------------------------------------
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
    using GS.Mobile.Share.Messages;
    using GS.Mobile.Share.Routing;
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
        /// The message service.
        /// </summary>
        protected readonly IMessageService MessageService;

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
        /// <param name="messageService">
        /// The message Service.
        /// </param>
        /// <param name="sessionProcessor">
        /// The session Processor.
        /// </param>
        protected BaseViewModel(IRoutingService routingService, IMessageService messageService, ISessionProcessor sessionProcessor)
        {
            this.RoutingService = routingService;
            this.SessionProcessor = sessionProcessor;
            this.MessageService = messageService;

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
        public string ErrorMessage { get; set; }

        /// <inheritdoc />
        public virtual ICommand OnLoadCommand => new Command(async () => await Task.CompletedTask);

        /// <inheritdoc />
        public virtual ICommand OnCloseCommand => new Command(async () => await Task.CompletedTask);

        #region Virtual Methods

        /// <inheritdoc />
        public virtual void CleanUi()
        {
            // Each viewmodel will decide what items to clean.
        }
        #endregion

        #region private Methods

        /// <summary>
        /// Validates if current viewmodel hast proper permissions.
        /// </summary>
        /// <exception cref="Exception">
        /// Thrown when the viewmodel does not have proper validation attributes.
        /// </exception>
        private void ValidateAuthorizationRules()
        {
            if (this.IsAnonymousAllowed())
            {
                return;
            }

            if (this.IsAuthorizationRequired())
            {
                var viewModelRoles = this.GetViewModelAuthorizationRoles();
                var isValid = this.ValidateCurrentSession(viewModelRoles);

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

        /// <summary>
        /// Validates current session against viewmodel roles.
        /// </summary>
        /// <param name="viewModelRoles">
        /// The view model roles.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool ValidateCurrentSession(string viewModelRoles)
        {
            bool result;

            if (string.IsNullOrEmpty(viewModelRoles))
            {
                var token = this.SessionProcessor.GetAccessToken().GetAwaiter().GetResult();
                result = !string.IsNullOrEmpty(token);
            }
            else
            {
                result = this.SessionProcessor.ValidateSessionWithRoles(viewModelRoles).GetAwaiter().GetResult();
            }

            return result;
        }
        #endregion
    }
}