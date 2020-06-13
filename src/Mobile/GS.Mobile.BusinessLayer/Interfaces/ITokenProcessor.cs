// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ITokenProcessor.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the ITokenProcessor type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GS.Mobile.BusinessLayer.Interfaces
{
    using System.Threading.Tasks;

    using GS.Mobile.Types.Security;

    /// <summary>
    /// The TokenProcessor interface.
    /// </summary>
    public interface ITokenProcessor
    {
        /// <summary>
        /// Decodes a JWT payload into a <see cref="Token"/>.
        /// </summary>
        /// <param name="token">
        /// The token.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<Token> DecodeTokenString(string token);

        /// <summary>
        /// The validate token string.
        /// </summary>
        /// <param name="token">
        /// The token.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        bool ValidateTokenString(string token);
    }
}