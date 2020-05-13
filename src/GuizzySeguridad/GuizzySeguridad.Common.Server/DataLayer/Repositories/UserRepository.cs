// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserRepository.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the UserRepository type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GuizzySeguridad.Common.Server.DataLayer.Repositories
{
    using System.Linq;
    using System.Threading.Tasks;

    using GuizzySeguridad.Common.OperationalManagement.Extensions;
    using GuizzySeguridad.Common.Server.Interfaces.Repository;
    using GuizzySeguridad.Common.Types.Exceptions;
    using GuizzySeguridad.Common.Types.Models;
    using GuizzySeguridad.Common.Types.Models.Persistence;

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
            var results = await this.FindAsync(item => item.Correo == userName && item.Activo);

            if (results == null || !results.Any())
            {
                throw new InvalidUserAccessException();
            }

            return results.First().MapTo<User>();
        }
    }
}