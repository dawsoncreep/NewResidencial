// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUserFacade.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the IUserFacade type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GuizzySeguridad.Common.Server.Interfaces.Facade
{
    using System.Threading.Tasks;

    using GuizzySeguridad.Common.Types.Exceptions;
    using GuizzySeguridad.Common.Types.Models;

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
        /// <exception cref="TypeValidationException">
        /// Thrown when input <see cref="LoginRequest"/> has validation errors.
        /// </exception>
        /// <exception cref="InvalidUserAccessException">
        /// Thrown whe <see cref="LoginRequest"/> data is not valid into system.
        /// </exception>
        /// <exception cref="TokenGenerationException">
        /// Thrown whe the system cannot generate a new JWT for the user.
        /// </exception>
        Task<string> Authenticate(LoginRequest request);
    }
}