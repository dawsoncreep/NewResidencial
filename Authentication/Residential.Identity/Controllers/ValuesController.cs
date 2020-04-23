// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ValuesController.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the ValuesController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Residential.Identity.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Web.Http;

    /// <summary>
    /// The values controller.
    /// </summary>
    public class ValuesController : BaseApiController
    {
        /// <summary>
        /// Gets a list of values.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable{T}"/>.
        /// </returns>
        public async Task<IHttpActionResult> Get()
        {
            return await this.ExecuteProcess(async () => { return await Task.FromResult(new string[] { "value1", "value2" }); });
        }

        /// <summary>
        /// Returns a specific value
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string Get(int id)
        {
            return "value";
        }

        /// <summary>
        /// Creates a new value.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        public void Post([FromBody]string value)
        {
        }

        /// <summary>
        /// Updates a specific value.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        public void Put(int id, [FromBody]string value)
        {
        }

        /// <summary>
        /// Deletes a value.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        public void Delete(int id)
        {
        }
    }
}
