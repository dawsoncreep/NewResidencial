// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MasterViewModel.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the MasterViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GS.Mobile.ViewModels.Master
{
    using System.Windows.Input;

    using GS.Mobile.BusinessLayer.Interfaces;
    using GS.Mobile.Share.Messages;
    using GS.Mobile.Share.Routing;
    using GS.Mobile.ViewModels.Attributes;
    using GS.Mobile.Views.Login;

    using Xamarin.Forms;

    /// <summary>
    /// The master view model.
    /// </summary>
    [AllowAnonymous("Revision here is OK.")]
    public class MasterViewModel : BaseViewModel, IMasterViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MasterViewModel"/> class.
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
        public MasterViewModel(IRoutingService routingService, IMessageService messageService, ISessionProcessor sessionProcessor) : base(routingService, messageService, sessionProcessor)
        {
        }

        /// <inheritdoc />
        public override ICommand OnLoadCommand => new Command(
             async () =>
                {
                    var accessToken = await this.SessionProcessor.GetAccessToken();

                    if (string.IsNullOrEmpty(accessToken))
                    {
                        this.RoutingService.SetMaster<LoginPage>();
                    }
                });
    }
}