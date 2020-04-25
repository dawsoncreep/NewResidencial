﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUserProcessor.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the IUserProcessor type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Authentication.BusinessLayer.Processors
{
    using System.Threading.Tasks;

    using Authentication.Types.Exceptions;
    using Authentication.Types.Models;

    /// <summary>
    /// The IUserProcessor interface.
    /// </summary>
    public interface IUserProcessor
    {
        /// <summary>
        /// Retrieves <see cref="User"/> information using the nickname(userName).
        /// </summary>
        /// <param name="userName">
        /// The user name.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        /// <exception cref="InvalidUserAccessException">
        /// Thrown whe <see cref="LoginRequest"/> data is not valid into system.
        /// </exception>
        Task<User> GetUserByUserName(string userName);
    }
}