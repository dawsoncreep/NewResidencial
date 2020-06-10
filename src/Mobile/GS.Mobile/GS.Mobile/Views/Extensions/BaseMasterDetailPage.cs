// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BaseMasterDetailPage.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   The base master detail page.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GS.Mobile.Views.Extensions
{
    using GS.Mobile.ViewModels;
    using GS.Mobile.ViewModels.Extensions;

    using Xamarin.Forms;

    /// <summary>
    /// The base master detail page.
    /// </summary>
    /// <typeparam name="TViewModel">
    /// Specific view model to work.
    /// </typeparam>
    public class BaseMasterDetailPage<TViewModel> : MasterDetailPage where TViewModel : IViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseMasterDetailPage{TViewModel}"/> class.
        /// </summary>
        protected BaseMasterDetailPage()
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