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
    using GS.Mobile.Share.Messages;
    using GS.Mobile.Share.Routing;
    using GS.Mobile.Types.Exceptions;
    using GS.Mobile.Types.Messages;
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
        /// <param name="messageService">
        /// The message Service.
        /// </param>
        /// <param name="sessionProcessor">
        /// The session processor.
        /// </param>
        /// <param name="userProcessor">
        /// The user Processor.
        /// </param>
        public LoginViewModel(IRoutingService routingService, IMessageService messageService, ISessionProcessor sessionProcessor, IUserProcessor userProcessor) : base(routingService, messageService, sessionProcessor)
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
                        await this.MessageService.ShowMessageAsync(MessageType.Warning, this.ErrorMessage = new InvalidLoginException().Message);
                        this.CleanUi();
                        return;
                    }

                    try
                    {
                        this.IsBusy = true;
                        var token = await this.userProcessor.Login(this.UserName, this.Password);
                        await this.SessionProcessor.SaveToken(token);
                        this.RoutingService.SetMaster<MasterPage>();
                        this.IsBusy = false;
                    }
                    catch (BusinessRuleException exception)
                    {
                        await this.MessageService.ShowMessageAsync(MessageType.Warning, this.ErrorMessage = exception.Message);
                        this.CleanUi();
                    }
                    catch (Exception exception)
                    {
                        await this.MessageService.ShowMessageAsync(MessageType.Error, this.ErrorMessage = exception.Message);
                        this.CleanUi();
                    }
                });

        #region Public Methods

        /// <inheritdoc />
        public override void CleanUi()
        {
            this.IsBusy = false;
            this.UserName = string.Empty;
            this.Password = string.Empty;
        }
        #endregion
    }
}