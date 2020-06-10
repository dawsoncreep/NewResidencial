// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MasterPage.xaml.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the MasterPage type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GS.Mobile.Views.Main
{
    using GS.Mobile.Views.Wrappers;

    using Xamarin.Forms.Xaml;

    /// <summary>
    /// The master page.
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterPage : MasterWrapper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MasterPage"/> class.
        /// </summary>
        public MasterPage()
        {
            this.InitializeComponent();
        }
    }
}