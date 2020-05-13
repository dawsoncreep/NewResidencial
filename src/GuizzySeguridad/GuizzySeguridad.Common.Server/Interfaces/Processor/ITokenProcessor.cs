// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ITokenProcessor.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the ITokenProcessor type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GuizzySeguridad.Common.Server.Interfaces.Processor
{
    using System.Threading.Tasks;

    using GuizzySeguridad.Common.Types.Exceptions;
    using GuizzySeguridad.Common.Types.Models;

    /// <summary>
    /// The TokenProcessor interface.
    /// </summary>
    public interface ITokenProcessor
    {
        /// <summary>
        /// Generates a new Json Web Token for current <see cref="User"/>.
        /// </summary>
        /// <param name="user">
        /// The user data .
        /// </param>
        /// <returns>
        /// The JWT as an asynchronously <see cref="Task"/>.
        /// </returns>
        /// <exception cref="TokenGenerationException">
        /// Thrown whe the system cannot generate a new JWT for the user.
        /// </exception>
        Task<string> GenerateToken(User user);
    }
}