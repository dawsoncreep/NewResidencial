// --------------------------------------------------------------------------------------------------------------------
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
        /// Initializes a new instance of the <see cref="UserProcessor"/> class.
        /// </summary>
        /// <param name="userRepository">
        /// The user repository.
        /// </param>
        public UserProcessor(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        /// <inheritdoc />
        public async Task<User> GetUserByUserName(string userName)
        {
            return await this.userRepository.FindByUserName(userName);
        }
    }
}