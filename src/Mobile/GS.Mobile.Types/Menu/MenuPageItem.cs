// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MenuPageItem.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the MenuItem type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GS.Mobile.Types.Menu
{
    using System;

    /// <summary>
    /// The menu item.
    /// </summary>
    public class MenuPageItem
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string PageName { get; set; }

        /// <summary>
        /// Gets or sets the image sorce url.
        /// </summary>
        public string ImageSource { get; set; }

        /// <summary>
        /// Gets or sets the page type.
        /// </summary>
        public Type PageType { get; set; }
    }
}