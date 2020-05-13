// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestController.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the TestController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GuizzySeguridad.Api.Controllers
{
    using System;
    using System.Threading.Tasks;
    using System.Web.Http;

    /// <summary>
    /// The test controller.
    /// </summary>
    [Authorize]
    public class TestController : ApiController
    {
        /// <summary>
        /// Gets a random int value between 1 and 10.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [HttpGet]
        [ActionName("GetRandomNumber")]
        public async Task<IHttpActionResult> GetRandomNumber()
        {
            return await Task.FromResult(this.Ok(new Random().Next(1, 10)));
        }
    }
}
