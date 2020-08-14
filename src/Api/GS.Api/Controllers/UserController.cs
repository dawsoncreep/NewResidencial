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
    using GS.Api.BusinessLayer.Interfaces.Processor;
    using GS.Api.OperationalManagement.Interfaces;
    using GS.Api.Types.Models;

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
        /// The user processor
        /// </summary>
        private readonly IUserProcessor userProcessor;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class.
        /// </summary>
        /// <param name="logger">
        /// The logger.
        /// </param>
        /// <param name="userFacade">
        /// The user facade.
        /// </param>
        /// <param name="userProcessor">
        /// The user processor
        /// </param>
        public UserController(IApplicationLogger logger, IUserFacade userFacade, IUserProcessor userProcessor) : base(logger)
        {
            this.userFacade = userFacade;
            this.userProcessor = userProcessor;
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

        /// <summary>
        /// Insert User
        /// </summary>
        /// <param name="user"></param>
        /// <returns>
        /// The <see cref="Task"/>
        /// </returns>
        [HttpPost]
        [ActionName("Insert")]
        public async Task<IHttpActionResult> Insert([FromBody] User user)
        {
            var result = await this.ExecuteProcess(async () => await this.userFacade.Insert(user));
            return await Task.FromResult(result);

        }

        /// <summary>
        /// Gets user by ID.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [HttpGet]
        [ActionName("GetByID")]
        public async Task<IHttpActionResult> GetById(int id)
        {
            var result = await this.ExecuteProcess(async () => await this.userFacade.FindById(id));
            return await Task.FromResult(result);
        }

        /// <summary>
        /// Gets all rols.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [HttpGet]
        [ActionName("GetAllRols")]
        public async Task<IHttpActionResult> GetAllRols()
        {
            var result = await this.ExecuteProcess(async () => await this.userFacade.GetAllRol());
            return await Task.FromResult(result);
        }
    }
}