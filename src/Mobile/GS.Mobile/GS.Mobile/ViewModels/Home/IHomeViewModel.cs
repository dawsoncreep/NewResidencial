// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IHomeViewModel.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the IHomeViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GS.Mobile.ViewModels.Home
{
    using System.Windows.Input;

    using GS.Mobile.ViewModels.Extensions;

    /// <summary>
    /// The HomeViewModel interface.
    /// </summary>
    public interface IHomeViewModel : IViewModel
    {
        /// <summary>
        /// Gets the do something.
        /// </summary>
        ICommand DoSomething { get; }
    }
}