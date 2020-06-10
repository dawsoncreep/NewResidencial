// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IViewModel.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the IViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GS.Mobile.ViewModels
{
    using System.ComponentModel;
    using System.Threading.Tasks;
    using System.Windows.Input;

    /// <inheritdoc />
    /// <summary>
    /// The BaseViewModel interface.
    /// </summary>
    public interface IViewModel : INotifyPropertyChanged
    {
        #region Properties
        
        /// <summary>
        /// Gets or sets a value indicating whether the view is busy.
        /// </summary>
        bool IsBusy { get; set; }

        /// <summary>
        /// Page tile.
        /// </summary>
        string PageTitle { get; set; }
        #endregion

        #region Commands

        /// <summary>
        /// Gets the on load command.
        /// </summary>
        ICommand OnLoadCommand { get; }

        /// <summary>
        /// Gets the on close command.
        /// </summary>
        ICommand OnCloseCommand { get; }
        #endregion

        #region Methods

        /// <summary>
        /// The clean ui.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task CleanUi();
        #endregion
    }
}