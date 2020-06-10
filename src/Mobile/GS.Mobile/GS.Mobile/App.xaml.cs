// --------------------------------------------------------------------------------------------------------------------
// <copyright file="App.xaml.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the App type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GS.Mobile
{
    using GS.Mobile.IoC;
    using GS.Mobile.Views.Main;

    using Xamarin.Forms;

    /// <summary>
    /// The application starting point.
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="App"/> class.
        /// </summary>
        public App()
        {
            this.InitializeComponent();

            if (DependencyResolver == null)
            {
                DependencyResolver = new DependencyResolver();
                DependencyResolver.Initialize();
            }

            this.MainPage = new MasterPage();
        }

        /// <summary>
        /// The application dependency resolver.
        /// </summary>
        public static DependencyResolver DependencyResolver { get; private set; }
    }
}
