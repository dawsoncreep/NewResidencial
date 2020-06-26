// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserListPage.xaml.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the UserListPage type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GS.Mobile.Views.Users
{
    using GS.Mobile.Views.Wrappers;

    using Xamarin.Forms.Xaml;

    /// <summary>
    /// The home page.
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserListPage : UserListWrapper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserListPage"/> class.
        /// </summary>
        public UserListPage()
        {
            this.InitializeComponent();
        }
    }
}