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

    using Syncfusion.Licensing;

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
            // Favor de revisar FAQ de la siguiente liga
            // https://www.syncfusion.com/products/communitylicense
            // Actual license key is provided by Xavier Hernandez Reyes.
            // To upgrade or create a new license key, a Syncfusion account must be created.
            SyncfusionLicenseProvider.RegisterLicense("Mjc2OTY2QDMxMzgyZTMxMmUzMG5jZnlwU0VWbThtT0R4emsrdWZRQ1FucDFuS0dhRlZhK3RNWXpuMmtoa3c9");
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
