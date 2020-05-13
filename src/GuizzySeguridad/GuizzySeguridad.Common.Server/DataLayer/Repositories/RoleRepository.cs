// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RoleRepository.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the RoleRepository type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GuizzySeguridad.Common.Server.DataLayer.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using GuizzySeguridad.Common.Server.Interfaces.Repository;
    using GuizzySeguridad.Common.Types.Exceptions;
    using GuizzySeguridad.Common.Types.Models;
    using GuizzySeguridad.Common.Types.Models.Persistence;

    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// The role repository.
    /// </summary>
    public class RoleRepository : BaseRepository<SRol>, IRolRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RoleRepository"/> class.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        public RoleRepository(DbContext context) : base(context)
        {
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
    }
}