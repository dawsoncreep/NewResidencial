// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MenuViewModel.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the MenuViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GS.Mobile.ViewModels.Menu
{
    using System.Collections.Generic;
    using System.Windows.Input;

    using GS.Mobile.BusinessLayer.Interfaces;
    using GS.Mobile.Share.Messages;
    using GS.Mobile.Share.Routing;
    using GS.Mobile.Types.Menu;
    using GS.Mobile.ViewModels.Attributes;
    using GS.Mobile.Views.Main;
    using GS.Mobile.Views.Users;

    using Xamarin.Forms;

    /// <summary>
    /// The menu view model.
    /// </summary>
    [Authorize]
    public class MenuViewModel : BaseViewModel, IMenuViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MenuViewModel"/> class.
        /// </summary>
        /// <param name="routingService">
        /// The routing service.
        /// </param>
        /// <param name="messageService">
        /// The message service.
        /// </param>
        /// <param name="sessionProcessor">
        /// The session processor.
        /// </param>
        public MenuViewModel(IRoutingService routingService, IMessageService messageService, ISessionProcessor sessionProcessor) : base(routingService, messageService, sessionProcessor)
        {
            this.MenuItemList = new List<MenuPageItem>();
        }

        /// <inheritdoc />
        public List<MenuPageItem> MenuItemList { get; set; }

        /// <inheritdoc />
        public MenuPageItem SelectedMenuItem { get; set; }

        /// <inheritdoc />
        public override ICommand OnLoadCommand => new Command(() =>
            {
                this.MenuItemList = new List<MenuPageItem>
                                        {
                                            new MenuPageItem { Id = 1, PageName = "Home", ImageSource = "ic_action_home", PageType = typeof(DashboardPage) },
                                            new MenuPageItem { Id = 2, PageName = "Usuarios", ImageSource = "ic_action_group.png", PageType = typeof(UserListPage) }
                                        };
            });

        /// <inheritdoc />
        public ICommand NavigateCommand => new Command(
            async () =>
                {
                    if (this.SelectedMenuItem == null || this.SelectedMenuItem.PageType == null)
                    {
                        return;
                    }

                    // Home
                    if (this.SelectedMenuItem.Id == 1)
                    {
                        await this.RoutingService.PopToRootAsync();
                    }
                    else
                    {
                        await this.RoutingService.PushAsync(this.SelectedMenuItem.PageType);
                    }

                    this.SelectedMenuItem = null;
                });
    }
}