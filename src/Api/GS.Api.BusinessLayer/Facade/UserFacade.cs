// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserFacade.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the UserFacade type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GS.Api.BusinessLayer.Facade
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using GS.Api.BusinessLayer.Interfaces.Facade;
    using GS.Api.BusinessLayer.Interfaces.Processor;
    using GS.Api.Types.Exceptions;
    using GS.Api.Types.Models;

    /// <summary>
    /// The user facade.
    /// </summary>
    public class UserFacade : IUserFacade
    {
        /// <summary>
        /// The user processor.
        /// </summary>
        private readonly IUserProcessor userProcessor;

        /// <summary>
        /// The token processor.
        /// </summary>
        private readonly ITokenProcessor tokenProcessor;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserFacade"/> class.
        /// </summary>
        /// <param name="userProcessor">
        /// The user processor.
        /// </param>
        /// <param name="tokenProcessor">
        /// The token Processor.
        /// </param>
        public UserFacade(IUserProcessor userProcessor, ITokenProcessor tokenProcessor)
        {
            this.userProcessor = userProcessor;
            this.tokenProcessor = tokenProcessor;
        }

        /// <inheritdoc />
        public async Task<string> Authenticate(LoginRequest request)
        {
            request.Validate();
            var user = await this.userProcessor.GetUserByUserName(request.UserName);

            if (user.Password != request.Password)
            {
                throw new InvalidUserAccessException();
            }

            return await this.tokenProcessor.GenerateToken(user);
        }

        public async Task<IEnumerable<User>> ListOfSettlerUser()
        {
            var users = await this.userProcessor.GetListOfSettlerUser();
            return users;
        }
    }
}