// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AuthenticationService.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the AuthenticationService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GS.Mobile.DataLayer.Services.Authentication
{
    using System.Net;
    using System.Threading.Tasks;

    using GS.Mobile.Types.Exceptions;
    using GS.Mobile.Types.Security;

    /// <summary>
    /// The authentication service.
    /// </summary>
    public class AuthenticationService : IAuthenticationService
    {
        /// <summary>
        /// The service manager.
        /// </summary>
        private readonly IServiceManager serviceManager;

        /// <summary>
        /// The server.
        /// </summary>
        private readonly string server;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationService"/> class.
        /// </summary>
        /// <param name="serviceManager">
        /// The service Manager.
        /// </param>
        public AuthenticationService(IServiceManager serviceManager)
        {
            this.serviceManager = serviceManager;
            this.server = "http://development.blyxitsolutions.lab:63100";
        }

        /// <inheritdoc />
        public async Task<string> Login(LoginRequest request)
        {
            var url = $"{this.server}/api/Authentication/Login";
            var response = await this.serviceManager.ExecutePost<string>(url, request);
            
            if ((HttpStatusCode)response.StatusCode == HttpStatusCode.BadRequest)
            {
                throw new InvalidUserAccessException();
            }

            if ((HttpStatusCode)response.StatusCode == HttpStatusCode.InternalServerError)
            {
                throw new ServiceCallException(response.Error);
            }

            return response.Result;
        }
    }
}