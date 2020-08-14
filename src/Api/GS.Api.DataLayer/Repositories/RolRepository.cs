// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RolRepository.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the RolRepository type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GS.Api.DataLayer.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using GS.Api.DataLayer.Interfaces;
    using GS.Api.Types.Exceptions;
    using GS.Api.Types.Models;
    using GS.Api.Types.Models.Persistence;

    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// The rol repository.
    /// </summary>
    public class RolRepository : BaseRepository<SRol>, IRolRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RolRepository"/> class.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        public RolRepository(DbContext context) : base(context)
        {
        }

        public async Task CreateUserRol(SUserRol userRol)
        {
            await this.CurrentContext.AddAsync(userRol);
            await this.CurrentContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<SRol>> GetAllRols()
        {
            var result = await this.FindAsync(x => x.Activo == true);
            return result;
        }

        /// <inheritdoc />
        public async Task<Authorization[]> GetAuthorizationData(int userId)
        {
            if (!(this.CurrentContext is ApplicationContext context))
            {
                throw new InvalidUserRolException();
            }

            var result = new List<Authorization>();

            var roles = await (from userRol in context.UserRol
                               join rol in context.Rol on userRol.IdRol equals rol.IdRol
                               where userRol.IdUsuario == userId && rol.Activo
                               select new { id = rol.IdRol, name = rol.Nombre }).ToListAsync();

            if (roles is null || !roles.Any())
            {
                throw new InvalidUserRolException();
            }

            foreach (var rol in roles)
            {
                var permissions = await (from rolPermission in context.RolPermission
                                         join permission in context.Permission on rolPermission.IdPermiso equals permission.IdPermiso
                                         where rolPermission.IdRol == rol.id && rolPermission.Activo
                                         select permission.Nombre).ToArrayAsync();

                result.Add(new Authorization { Role = rol.name, Permission = permissions });
            }

            return await Task.FromResult(result.ToArray());
        }

        public async Task<SRol> GetRolByName(string name)
        {
            var result = await this.FindAsync(x => x.Nombre == name);
            return result.First();
        }
    }
}