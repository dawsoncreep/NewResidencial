// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUserProcessor.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the IUserProcessor type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GS.Api.BusinessLayer.Interfaces.Processor
{
    using System.Threading.Tasks;

    using GS.Api.Types.Exceptions;
    using GS.Api.Types.Models;

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
        /// <exception cref="InvalidUserRolException">
        /// Thrown when role/permission is empty or incomplete.
        /// </exception>
        Task<User> GetUserByUserName(string userName);
    }
}