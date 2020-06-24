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

    using GS.Api.BusinessLayer.Interfaces.Facade;
    using GS.Api.OperationalManagement.Interfaces;
    using GS.Api.Types.Enums;
    using GS.Api.Types.Models;

    [AllowAnonymous]
    public class UserController : BaseApiController
    {
        /// <summary>
        /// The user facade.
        /// </summary>
        private readonly IUserFacade userFacade;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class.
        /// </summary>
        /// <param name="logger">
        /// The logger.
        /// </param>
        /// <param name="userFacade">
        /// The user facade.
        /// </param>
        public UserController(IApplicationLogger logger, IUserFacade userFacade) : base(logger)
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
        [HttpGet]
        [ActionName("GetAll")]
        public async Task<IHttpActionResult> GetAll()
        {
            var result = await this.ExecuteProcess(async () => await this.userFacade.ListOfSettlerUser());
            return await Task.FromResult(result);
        }
    }
}