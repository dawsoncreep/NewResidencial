// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AuthenticationController.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the AuthenticationController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Authentication.Api.Controllers
{
    using System.Threading.Tasks;
    using System.Web.Http;

    using Authentication.BusinessLayer.Interfaces.Facade;
    using Authentication.OperationalManagement.Interfaces;
    using Authentication.Types.Enums;
    using Authentication.Types.Models;

    /// <summary>
    /// The authentication controller.
    /// </summary>
    [AllowAnonymous]
    public class AuthenticationController : BaseApiController
    {
        /// <summary>
        /// The user facade.
        /// </summary>
        private readonly IUserFacade userFacade;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationController"/> class.
        /// </summary>
        /// <param name="logger">
        /// The logger.
        /// </param>
        /// <param name="userFacade">
        /// The user facade.
        /// </param>
        public AuthenticationController(IApplicationLogger logger, IUserFacade userFacade) : base(logger)
        {
            this.userFacade = userFacade;
        }

        /// <summary>
        /// Authenticates a user, if valid returns a valid Json Web Token.
        /// </summary>
        /// <param name="loginRequest">
        /// The login request.
        /// </param>
        /// <returns>
        /// returns a JWT asynchronously.
        /// </returns>
        [HttpPost]
        [ActionName("Authenticate")]
        public async Task<IHttpActionResult> Authenticate([FromBody] LoginRequest loginRequest)
        {
            var result = await this.ExecuteProcess(async () => await this.userFacade.Authenticate(loginRequest));
            await this.Logger.Log(LogType.Information, $"Token successfully generated for user {loginRequest.UserName}");
            return await Task.FromResult(result);
        }
    }
}