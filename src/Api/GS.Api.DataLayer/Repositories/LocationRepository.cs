// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserRepository.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the UserRepository type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GS.Api.DataLayer.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using GS.Api.DataLayer.Interfaces;
    using GS.Api.OperationalManagement.Extensions;
    using GS.Api.Types.Exceptions;
    using GS.Api.Types.Models;
    using GS.Api.Types.Models.Persistence;

    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// The location repository
    /// </summary>
    class LocationRepository : BaseRepository<SLocation>, ILocationRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository"/> class
        /// </summary>
        /// <param name="context">
        /// The context
        /// </param>
        public LocationRepository(DbContext context) : base(context)
        {
        }

        public async Task<Location> FindById(int id)
        {
            var result = await this.FindAsync(item => item.Id == id);
            return result.First().MapTo<Location>();
        }

        public async Task<IEnumerable<Location>> FindByUserId(int id)
        {
            List<Location> Response = new List<Location>();
            if (!(this.CurrentContext is ApplicationContext context))
            {
                throw new InvalidUserRolException();
            }

            var locations = await (from userLocation in context.UserLocation
                                   join location in context.Location on userLocation.IdUbicacion equals location.Id
                                   where userLocation.IdUsuario == id
                                   select location).ToListAsync();
            

            foreach (var locate in locations)
            {
                Response.Add(new Location { Id = locate.Id, Nombre = locate.Nombre, Activo = locate.Activo, IdTipoUbicacion = locate.IdTipoUbicacion });
            }
            return Response;
        }
    }
}
