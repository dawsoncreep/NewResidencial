// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServiceManager.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the ServiceManager type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GS.Mobile.DataLayer.Services
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;

    using GS.Mobile.Types.Exceptions;
    using GS.Mobile.Types.Messages;
    using GS.Mobile.Types.Network;

    using Newtonsoft.Json;

    /// <summary>
    /// The service manager.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class ServiceManager : IServiceManager
    {
        /// <summary>
        /// The timeout in seconds.
        /// </summary>
        private const int TimeoutInSeconds = 15;

        /// <summary>
        /// The http client.
        /// </summary>
        private HttpClient httpClient;

        /// <inheritdoc />
        public async Task<ServiceCallResult<TResult>> ExecuteGet<TResult>(string url)
        {
            using (this.httpClient = new HttpClient { Timeout = TimeSpan.FromSeconds(TimeoutInSeconds) })
            {
                HttpResponseMessage response;
                
                try
                {
                    response = await this.httpClient.GetAsync(url);
                }
                catch (Exception exception)
                {
                    throw new ServiceCallException(exception);
                }

                return await ManageResponse<TResult>(response);
            }
        }

        /// <inheritdoc />
        public async Task<ServiceCallResult<TResult>> ExecutePost<TResult>(string url, object content)
        {
            using (this.httpClient = new HttpClient { Timeout = TimeSpan.FromSeconds(TimeoutInSeconds) })
            {
                HttpResponseMessage response;

                try
                {
                    var json = JsonConvert.SerializeObject(content);
                    response = await this.httpClient.PostAsync(url, new StringContent(json, Encoding.UTF8, "application/json"));
                }
                catch (Exception exception)
                {
                    throw new ServiceCallException(exception);
                }

                return await ManageResponse<TResult>(response);
            }
        }
        
        /// <summary>
        /// The manage error code.
        /// </summary>
        /// <param name="response">
        /// The response.
        /// </param>
        /// <typeparam name="TResult">
        /// The operation result.
        /// </typeparam>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        private static async Task<ServiceCallResult<TResult>> ManageResponse<TResult>(HttpResponseMessage response)
        {
            ServiceCallResult<TResult> result;

            if (!response.IsSuccessStatusCode)
            {
                if (response.StatusCode == HttpStatusCode.BadRequest)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    var brokenRule = JsonConvert.DeserializeObject<BrokenRule>(data);
                    result = new ServiceCallResult<TResult>((int)response.StatusCode, default, brokenRule.Message);
                    return await Task.FromResult(result);
                }

                if (response.StatusCode == HttpStatusCode.InternalServerError)
                {
                    throw new ServiceCallException();
                }
            }

            result = new ServiceCallResult<TResult>((int)response.StatusCode, JsonConvert.DeserializeObject<TResult>(response.Content.ReadAsStringAsync().Result));
            return await Task.FromResult(result);
        }
    }
}