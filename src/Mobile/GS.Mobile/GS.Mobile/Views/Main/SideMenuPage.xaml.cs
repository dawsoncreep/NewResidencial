// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SideMenuPage.xaml.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the SideMenuPage type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GS.Mobile.Views.Main
{
    using System;

    using GS.Mobile.Views.Wrappers;

    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    /// <summary>
    /// The side menu page.
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SideMenuPage : MenuWrapper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SideMenuPage"/> class.
        /// </summary>
        public SideMenuPage()
        {
            this.InitializeComponent();
        }
    }
}