﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ISessionProcessor.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the ISessionProcessor type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GS.Mobile.BusinessLayer.Interfaces
{
    using System.Threading.Tasks;

    /// <summary>
    /// The SessionProcessor interface.
    /// </summary>
    public interface ISessionProcessor
    {
        /// <summary>
        /// Gets current access token.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<string> GetAccessToken();

        /// <summary>
        /// The validate session with roles.
        /// </summary>
        /// <param name="allowedRoles">
        /// The allowed roles.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<bool> ValidateSessionWithRoles(string allowedRoles);

        /// <summary>
        /// Saves a JWT into local storage.
        /// </summary>
        /// <param name="token">
        /// The token.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task SaveToken(string token);
    }
}