// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ILoginViewModel.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the ILoginViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GS.Mobile.ViewModels.Login
{
    using System.Windows.Input;

    /// <summary>
    /// The LoginViewModel interface.
    /// </summary>
    public interface ILoginViewModel : IViewModel
    {
        /// <summary>
        /// Gets or sets the user name.
        /// </summary>
        string UserName { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        string Password { get; set; }

        /// <summary>
        /// Gets the login command.
        /// </summary>
        ICommand LoginCommand { get; }
    }
}