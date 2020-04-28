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
        /// The sample.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [HttpGet]
        [ActionName("Sample")]
        public async Task<IHttpActionResult> Sample()
        {
            return await Task.FromResult(this.Ok("Sample"));
        }

        /// <summary>
        /// The authenticate.
        /// </summary>
        /// <param name="userRequest">
        /// The user request.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [HttpPost]
        [ActionName("Authenticate")]
        public async Task<IHttpActionResult> Authenticate([FromBody] LoginRequest userRequest)
        {
            return await this.ExecuteProcess(async () => await this.userFacade.Authenticate(userRequest));
        }
    }
}