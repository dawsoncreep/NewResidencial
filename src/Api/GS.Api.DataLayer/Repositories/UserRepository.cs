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
    using System.Linq;
    using System.Threading.Tasks;

    using GS.Api.DataLayer.Interfaces;
    using GS.Api.OperationalManagement.Extensions;
    using GS.Api.Types.Exceptions;
    using GS.Api.Types.Models;
    using GS.Api.Types.Models.Persistence;

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

        public async Task<int> CreateNewUser(User user)
        {
            try
            {
                var entity = new SUser
                {
                    Nombres = user.Name,
                    Apellidos = user.LastName,
                    Correo = user.Email,
                    Alias = user.NickName,
                    Contraseña = user.Password,
                    Activo = true
                };
                await this.CreateAsync(entity);
                await CurrentContext.SaveChangesAsync();
                return 1;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            
        }

        public async Task<User> FindById(int id)
        {
            var results = await this.FindAsync(item => item.Id == id);

            if(results == null)
            {
                throw new System.Exception();
            }

            return results.First().MapTo<User>();
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