// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUserFacade.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the IUserFacade type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Authentication.BusinessLayer.Interfaces.Facade
{
    using System.Threading.Tasks;

    using Authentication.Types.Models;

    /// <summary>
    /// The UserFacade interface.
    /// </summary>
    public interface IUserFacade
    {
        /// <summary>
        /// Generates a JWT for a valid <see cref="LoginRequest"/> object.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<string> Authenticate(LoginRequest request);
    }
}