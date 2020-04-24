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

    /// <summary>
    /// The base api controller.
    /// </summary>
    public class BaseApiController : ApiController
    {
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

                // TODO: Log information
                return await Task.FromResult(this.Ok(result));
            }
            catch (Exception exception)
            {
                // TODO: Log error
                return await Task.FromResult(this.InternalServerError(exception));
            }
        }
    }
}