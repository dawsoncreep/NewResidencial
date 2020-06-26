// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUserListViewModel.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the IUserListViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GS.Mobile.ViewModels.Users
{
    using System.Windows.Input;

    /// <summary>
    /// The UserListViewModel interface.
    /// </summary>
    public interface IUserListViewModel : IViewModel
    {
        /// <summary>
        /// Gets the do something.
        /// </summary>
        ICommand DoSomething { get; }
    }
}