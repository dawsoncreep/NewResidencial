// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserProcessor.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the UserProcessor type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GS.Api.BusinessLayer.Processors
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using GS.Api.BusinessLayer.Interfaces.Processor;
    using GS.Api.DataLayer.Interfaces;
    using GS.Api.OperationalManagement.Extensions;
    using GS.Api.Types.Models;

    /// <summary>
    /// The user processor.
    /// </summary>
    public class UserProcessor : IUserProcessor
    {
        /// <summary>
        /// The user repository.
        /// </summary>
        private readonly IUserRepository userRepository;

        /// <summary>
        /// The rol repository.
        /// </summary>
        private readonly IRolRepository rolRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserProcessor"/> class.
        /// </summary>
        /// <param name="userRepository">
        /// The user repository.
        /// </param>
        /// <param name="rolRepository">
        /// The rol Repository.
        /// </param>
        public UserProcessor(IUserRepository userRepository, IRolRepository rolRepository)
        {
            this.userRepository = userRepository;
            this.rolRepository = rolRepository;
        }

        public async Task<IEnumerable<User>> GetListOfSettlerUser()
        {
            List<User> result = new List<User>();
            var users = await this.userRepository.FindAsync(x => x.Activo == true);
            foreach (var item in users)
            {
                result.Add(item.MapTo<User>());
            }
            return result;
        }

        /// <inheritdoc />
        public async Task<User> GetUserByUserName(string userName)
        {
            var user = await this.userRepository.FindByUserName(userName);
            var authorizations = await this.rolRepository.GetAuthorizationData(user.Id);

            var unique = authorizations.First();

            user.Role = unique.Role;
            user.Permissions = unique.Permission;

            return await Task.FromResult(user);
        }
    }
}