// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BaseViewModel.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the BaseViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GS.Mobile.ViewModels.Extensions
{
    using System.ComponentModel;
    using System.Threading.Tasks;
    using System.Windows.Input;

    using Xamarin.Forms;

    /// <inheritdoc />
    /// <summary>
    /// The base view model.
    /// </summary>
    public abstract class BaseViewModel : IViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseViewModel"/> class.
        /// </summary>
        protected BaseViewModel()
        {
            // TODO: Manage dependencies thorough constructor.
        }

#pragma warning disable 067

        /// <inheritdoc />
        public event PropertyChangedEventHandler PropertyChanged;
#pragma warning restore 067

        /// <inheritdoc />
        public bool IsBusy { get; set; }

        /// <inheritdoc />
        public string PageTitle { get; set; }

        /// <inheritdoc />
        public virtual ICommand OnLoadCommand => new Command(async () => await Task.CompletedTask);

        /// <inheritdoc />
        public virtual ICommand OnCloseCommand => new Command(async () => await Task.CompletedTask);

        /// <inheritdoc />
        public async Task CleanUi()
        {
            await Task.CompletedTask;
        }
    }
}