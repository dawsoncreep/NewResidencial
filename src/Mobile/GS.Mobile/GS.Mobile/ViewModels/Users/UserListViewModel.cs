﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserListViewModel.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the UserListViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GS.Mobile.ViewModels.Users
{
    using System.Threading.Tasks;
    using System.Windows.Input;

    using GS.Mobile.BusinessLayer.Interfaces;
    using GS.Mobile.Share.Messages;
    using GS.Mobile.Share.Routing;
    using GS.Mobile.ViewModels.Attributes;

    using Xamarin.Forms;

    /// <summary>
    /// The home view model.
    /// </summary>
    [Authorize]
    public class UserListViewModel : BaseViewModel, IUserListViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserListViewModel"/> class.
        /// </summary>
        /// <param name="routingService">
        /// The routing service.
        /// </param>
        /// <param name="messageService">
        /// The message Service.
        /// </param>
        /// <param name="sessionProcessor">
        /// The session Processor.
        /// </param>
        public UserListViewModel(IRoutingService routingService, IMessageService messageService, ISessionProcessor sessionProcessor) : base(routingService, messageService, sessionProcessor)
        {
        }

        /// <inheritdoc />
        public override ICommand OnLoadCommand => new Command(
            async () =>
                {
                    this.PageTitle = "Welcome my friend!!!";
                    await Task.CompletedTask;
                });

        /// <inheritdoc />
        public ICommand DoSomething => new Command(
            async () =>
                {
                    this.PageTitle = "You clicked the button!!!";
                    await Task.CompletedTask;
                });
    }
}