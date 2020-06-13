// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BaseContentPage.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the BaseContentPage type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GS.Mobile.Views.Extensions
{
    using GS.Mobile.ViewModels;

    using Xamarin.Forms;

    /// <summary>
    /// The base content page.
    /// </summary>
    /// <typeparam name="TViewModel">
    /// Specific view model to work.
    /// </typeparam>
    public class BaseContentPage<TViewModel> : ContentPage where TViewModel : IViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseContentPage{TViewModel}"/> class.
        /// </summary>
        public BaseContentPage()
        {
            this.ViewModel = App.DependencyResolver.Resolve<TViewModel>();
            this.BindingContext = this.ViewModel;
        }

        /// <summary>
        /// Gets the view model.
        /// </summary>
        public IViewModel ViewModel { get; }
    }
}