// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserProcessor.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the UserProcessor type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GS.Mobile.BusinessLayer.Processors
{
    using System;
    using System.Threading.Tasks;

    using GS.Mobile.BusinessLayer.Interfaces;
    using GS.Mobile.DataLayer.Services.Authentication;
    using GS.Mobile.Types.Exceptions;
    using GS.Mobile.Types.Security;

    /// <summary>
    /// The user processor.
    /// </summary>
    public class UserProcessor : IUserProcessor
    {
        /// <summary>
        /// The authentication service.
        /// </summary>
        private readonly IAuthenticationService authenticationService;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserProcessor"/> class.
        /// </summary>
        /// <param name="authenticationService">
        /// The authentication service.
        /// </param>
        public UserProcessor(IAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;
        }

        /// <inheritdoc />
        public async Task<string> Login(string userName, string password)
        {
            try
            {
                var request = new LoginRequest { UserName = userName, Password = password };
                return await this.authenticationService.Login(request);
            }
            catch (Exception exception)
            {
                throw new ServiceCallException(exception);
            }
        }
    }
}