﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HomeViewModel.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the HomeViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GS.Mobile.ViewModels.Home
{
    using System.Threading.Tasks;
    using System.Windows.Input;

    using GS.Mobile.BusinessLayer.Interfaces;
    using GS.Mobile.Tools.Routing;
    using GS.Mobile.ViewModels.Attributes;

    using Xamarin.Forms;

    /// <summary>
    /// The home view model.
    /// </summary>
    [Authorization]
    public class HomeViewModel : BaseViewModel, IHomeViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HomeViewModel"/> class.
        /// </summary>
        /// <param name="routingService">
        /// The routing service.
        /// </param>
        /// <param name="sessionProcessor">
        /// The session Processor.
        /// </param>
        public HomeViewModel(IRoutingService routingService, ISessionProcessor sessionProcessor) : base(routingService, sessionProcessor)
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