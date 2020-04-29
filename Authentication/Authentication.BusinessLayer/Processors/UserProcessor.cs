﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserProcessor.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the UserProcessor type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Authentication.BusinessLayer.Processors
{
    using System.Threading.Tasks;

    using Authentication.BusinessLayer.Interfaces.Processor;
    using Authentication.DataLayer.Interfaces;
    using Authentication.Types.Models;

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

        /// <inheritdoc />
        public async Task<User> GetUserByUserName(string userName)
        {
            var user = await this.userRepository.FindByUserName(userName);
            user.Authorizations = await this.rolRepository.GetAuthorizationData(user.Id);
            return await Task.FromResult(user);
        }
    }
}