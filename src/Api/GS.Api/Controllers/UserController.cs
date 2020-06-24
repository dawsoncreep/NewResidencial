// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserController.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
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

    /// <summary>
    /// The user controller.
    /// </summary>
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
        /// Gets all settler user.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
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