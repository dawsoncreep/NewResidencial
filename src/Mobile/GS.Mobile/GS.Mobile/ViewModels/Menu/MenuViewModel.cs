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
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;
    using System.Windows.Input;

    using GS.Mobile.BusinessLayer.Interfaces;
    using GS.Mobile.Share.Messages;
    using GS.Mobile.Share.Routing;
    using GS.Mobile.Types.Menu;
    using GS.Mobile.ViewModels.Attributes;
    using GS.Mobile.Views;

    using Xamarin.Forms;

    /// <summary>
    /// The menu view model.
    /// </summary>
    [Authorization]
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
            this.MenuItemList = new ObservableCollection<MenuPageItem>
                                    {
                                        new MenuPageItem { Id = 1, PageName = "Home", ImageSource = "https://upload.wikimedia.org/wikipedia/commons/thumb/0/0b/Cuc.Phuong.Primate.Rehab.center.jpg/320px-Cuc.Phuong.Primate.Rehab.center.jpg" },
                                        new MenuPageItem { Id = 2, PageName = "Visitas", ImageSource = "visitas.png" },
                                        new MenuPageItem { Id = 3, PageName = "Ajustes", ImageSource = "ajustes.png", PageType = typeof(HomePage) }
                                    };
        }

        /// <inheritdoc />
        public ObservableCollection<MenuPageItem> MenuItemList { get; set; }

        /// <inheritdoc />
        public MenuPageItem SelectedMenuItem { get; set; }

        /// <inheritdoc />
        public ICommand NavigateCommand => new Command(
            async () =>
                {
                    if (this.SelectedMenuItem != null && this.SelectedMenuItem.PageType != null)
                    {
                        await this.RoutingService.PushAsync(this.SelectedMenuItem.PageType);
                        this.SelectedMenuItem = null;
                    }

                    await Task.CompletedTask;
                });
    }
}