// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LoginPage.xaml.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the LoginPage type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GS.Mobile.Views.Login
{
    using GS.Mobile.Views.Wrappers;

    using Xamarin.Forms.Xaml;

    /// <summary>
    /// The login page.
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : LoginWrapper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LoginPage"/> class.
        /// </summary>
        public LoginPage()
        {
            this.InitializeComponent();
        }
    }
}