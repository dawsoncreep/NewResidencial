// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IAuthenticationService.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the IAuthenticationService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GS.Mobile.DataLayer.Services.Authentication
{
    using System.Threading.Tasks;

    using GS.Mobile.Types.Security;

    /// <summary>
    /// The AuthenticationService interface.
    /// </summary>
    public interface IAuthenticationService
    {
        /// <summary>
        /// Authenticates a user using the system REST API.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<string> Login(LoginRequest request);
    }
}