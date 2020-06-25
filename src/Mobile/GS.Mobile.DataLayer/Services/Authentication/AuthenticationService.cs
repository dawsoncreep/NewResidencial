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
    using System.Threading.Tasks;

    using GS.Mobile.Types.Exceptions;
    using GS.Mobile.Types.Security;
    using GS.OperationalManagement.Configurations;

    /// <summary>
    /// The authentication service.
    /// </summary>
    public class AuthenticationService : BaseService, IAuthenticationService
    {
        /// <summary>
        /// The service manager.
        /// </summary>
        private readonly IServiceManager serviceManager;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationService"/> class.
        /// </summary>
        /// <param name="configurationManager">
        /// The configuration Manager.
        /// </param>
        /// <param name="serviceManager">
        /// The service Manager.
        /// </param>
        public AuthenticationService(IConfigurationManager configurationManager, IServiceManager serviceManager) : base(configurationManager)
        {
            this.serviceManager = serviceManager;
        }

        /// <inheritdoc />
        public async Task<string> Login(LoginRequest request)
        {
            var url = $"{this.ServerUrl}/api/Authentication/Login";
            var response = await this.serviceManager.ExecutePost<string>(url, request);

            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new InvalidLoginException(response.Error);
            }

            return response.Result;
        }
    }
}