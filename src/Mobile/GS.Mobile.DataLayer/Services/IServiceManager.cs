// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IServiceManager.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the IServiceManager type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GS.Mobile.DataLayer.Services
{
    using System.Threading.Tasks;

    using GS.Mobile.Types.Network;

    /// <summary>
    /// The ServiceManager interface.
    /// </summary>
    public interface IServiceManager
    {
        /// <summary>
        /// Executes an HTTP GET operation and transforms the response into an instance of type <see cref="TResult"/>.
        /// </summary>
        /// <param name="url">
        /// The endpoint url.
        /// </param>
        /// <typeparam name="TResult">
        /// The operation result.
        /// </typeparam>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<ServiceCallResult<TResult>> ExecuteGet<TResult>(string url);

        /// <summary>
        /// Executes an HTTP POST operation and transforms the response into an instance of type <see cref="TResult"/>.
        /// </summary>
        /// <param name="url">
        /// The endpoint url.
        /// </param>
        /// <param name="content">
        /// The content to be posted.
        /// </param>
        /// <typeparam name="TResult">
        /// The operation result.
        /// </typeparam>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<ServiceCallResult<TResult>> ExecutePost<TResult>(string url, object content);
    }
}