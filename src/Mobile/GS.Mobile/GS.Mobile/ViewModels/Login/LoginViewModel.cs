// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LoginViewModel.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the LoginViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GS.Mobile.ViewModels.Login
{
    using System;
    using System.Windows.Input;

    using GS.Mobile.BusinessLayer.Interfaces;
    using GS.Mobile.Share.Routing;
    using GS.Mobile.Types.Exceptions;
    using GS.Mobile.ViewModels.Attributes;
    using GS.Mobile.Views.Main;

    using Xamarin.Forms;

    /// <summary>
    /// The login view model.
    /// </summary>
    [AllowAnonymous("Revision here is OK.")]
    public class LoginViewModel : BaseViewModel, ILoginViewModel
    {
        /// <summary>
        /// The user processor.
        /// </summary>
        private readonly IUserProcessor userProcessor;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginViewModel"/> class.
        /// </summary>
        /// <param name="routingService">
        /// The routing service.
        /// </param>
        /// <param name="sessionProcessor">
        /// The session processor.
        /// </param>
        /// <param name="userProcessor">
        /// The user Processor.
        /// </param>
        public LoginViewModel(IRoutingService routingService, ISessionProcessor sessionProcessor, IUserProcessor userProcessor) : base(routingService, sessionProcessor)
        {
            this.userProcessor = userProcessor;
        }

        /// <inheritdoc />
        public string UserName { get; set; }

        /// <inheritdoc />
        public string Password { get; set; }

        /// <inheritdoc />
        public ICommand LoginCommand => new Command(
            async () =>
                {
                    if (string.IsNullOrEmpty(this.UserName) || string.IsNullOrEmpty(this.Password))
                    {
                        this.ErrorMessage = "El nombre de usuario y/o la contrasena son incorrectos.";
                        return;
                    }

                    try
                    {
                        var token = await this.userProcessor.Login(this.UserName, this.Password);
                        await this.SessionProcessor.SaveToken(token);
                        this.RoutingService.SetMaster<MasterPage>();
                    }
                    catch (BusinessRuleException exception)
                    {
                        this.ErrorMessage = exception.Message;
                    }
                    catch (Exception exception)
                    {
                        // TODO: Add some feature to allow a user to report an unhandled error.
                        this.ErrorMessage = exception.Message;
                    }
                });
    }
}