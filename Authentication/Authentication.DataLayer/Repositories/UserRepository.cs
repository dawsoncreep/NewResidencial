﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserRepository.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the UserRepository type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Authentication.DataLayer.Repositories
{
    using System.Linq;
    using System.Threading.Tasks;

    using Authentication.DataLayer.Interfaces;
    using Authentication.OperationalManagement.Extensions;
    using Authentication.Types.Exceptions;
    using Authentication.Types.Models;
    using Authentication.Types.Models.Persistence;

    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// The user repository.
    /// </summary>
    public class UserRepository : BaseRepository<SUser>, IUserRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository"/> class.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        public UserRepository(DbContext context) : base(context)
        {
        }

        /// <inheritdoc />
        public async Task<User> FindByUserName(string userName)
        {
            var results = await this.FindAsync(item => item.Usuario == userName && item.Activo);

            if (results == null || !results.Any())
            {
                throw new InvalidUserAccessException();
            }

            return results.First().MapTo<User>();
        }

    }
}