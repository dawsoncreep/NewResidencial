// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HomePage.xaml.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the HomePage type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GS.Mobile.Views
{
    using GS.Mobile.Views.Wrappers;

    using Xamarin.Forms.Xaml;

    /// <summary>
    /// The home page.
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : HomeWrapper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HomePage"/> class.
        /// </summary>
        public HomePage()
        {
            this.InitializeComponent();
        }
    }
}