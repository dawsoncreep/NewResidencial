// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserFacade.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the UserFacade type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Authentication.BusinessLayer.Facade
{
    using System.Threading.Tasks;

    using Authentication.BusinessLayer.Interfaces.Facade;
    using Authentication.BusinessLayer.Interfaces.Processor;
    using Authentication.Types.Exceptions;
    using Authentication.Types.Models;

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
    }
}