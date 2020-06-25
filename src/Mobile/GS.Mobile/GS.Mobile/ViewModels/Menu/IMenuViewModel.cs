// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMenuViewModel.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the IMenuViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GS.Mobile.ViewModels.Menu
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Windows.Input;

    using GS.Mobile.Types.Menu;

    /// <summary>
    /// The MenuViewModel interface.
    /// </summary>
    public interface IMenuViewModel : IViewModel
    {
        /// <summary>
        /// Gets or sets the menu item list.
        /// </summary>
        ObservableCollection<MenuPageItem> MenuItemList { get; set; }

        /// <summary>
        /// Gets or sets the selected menu item.
        /// </summary>
        MenuPageItem SelectedMenuItem { get; set; }

        /// <summary>
        /// Gets the navigate command.
        /// </summary>
        ICommand NavigateCommand { get; }
    }
}