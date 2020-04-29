// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUserRepository.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the IUserRepository type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Authentication.DataLayer.Interfaces
{
    using System.Threading.Tasks;

    using Authentication.Types.Exceptions;
    using Authentication.Types.Models;
    using Authentication.Types.Models.Persistence;

    /// <summary>
    /// The UserRepository interface.
    /// </summary>
    public interface IUserRepository : IRepository<SUser>
    {
        /// <summary>
        /// Finds a user by its 'username' field.
        /// </summary>
        /// <param name="userName">
        /// The user name.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        /// <exception cref="InvalidUserAccessException">
        /// Thrown when no user has been found in data base
        /// </exception>
        Task<User> FindByUserName(string userName);
    }
}