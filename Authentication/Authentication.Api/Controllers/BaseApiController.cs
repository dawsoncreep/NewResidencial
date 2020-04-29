// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BaseApiController.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the BaseApiController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Authentication.Api.Controllers
{
    using System;
    using System.Threading.Tasks;
    using System.Web.Http;

    using Authentication.OperationalManagement.Interfaces;
    using Authentication.Types.Exceptions;

    /// <summary>
    /// The base api controller.
    /// </summary>
    public class BaseApiController : ApiController
    {
        /// <summary>
        /// The logger.
        /// </summary>
        private readonly IApplicationLogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseApiController"/> class.
        /// </summary>
        /// <param name="logger">
        /// The logger.
        /// </param>
        protected BaseApiController(IApplicationLogger logger)
        {
            this.logger = logger;
        }

        /// <summary>
        /// Gets the current logger.
        /// </summary>
        public IApplicationLogger Logger => this.logger;

        /// <summary>
        /// Execute the corresponding business logic.
        /// </summary>
        /// <typeparam name="T">
        /// Return type for the execution process.
        /// </typeparam>
        /// <param name="action">
        /// The action to be executed.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        protected async Task<IHttpActionResult> ExecuteProcess<T>(Func<Task<T>> action)
        {
            try
            {
                var result = await action.Invoke();
                return await Task.FromResult(this.Ok(result));
            }
            catch (BusinessLayerException exception)
            {
                await this.logger.Log(exception);
                return await Task.FromResult(this.BadRequest(exception.Message));
            }
            catch (Exception exception)
            {
                await this.logger.Log(exception);
                return await Task.FromResult(this.InternalServerError(exception));
            }
        }
    }
}