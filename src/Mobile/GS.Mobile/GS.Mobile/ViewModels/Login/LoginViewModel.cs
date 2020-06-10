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
    using System.Threading.Tasks;
    using System.Windows.Input;

    using GS.Mobile.BusinessLayer.Interfaces;
    using GS.Mobile.Tools.Routing;
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
        /// Initializes a new instance of the <see cref="LoginViewModel"/> class.
        /// </summary>
        /// <param name="routingService">
        /// The routing service.
        /// </param>
        /// <param name="sessionProcessor">
        /// The session processor.
        /// </param>
        public LoginViewModel(IRoutingService routingService, ISessionProcessor sessionProcessor) : base(routingService, sessionProcessor)
        {
        }

        /// <inheritdoc />
        public ICommand LoginCommand => new Command(
            async () =>
                {
                    this.RoutingService.SetMaster<MasterPage>();
                    await Task.CompletedTask;
                });
    }
}