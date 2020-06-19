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
    using System.Threading;
    using System.Threading.Tasks;

    using GS.Mobile.Types.Exceptions;
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

        private HttpClient httpClient;

        /// <inheritdoc />
        public async Task<ServiceCallResult<TResult>> ExecuteGet<TResult>(string url)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(url);
                var result = new ServiceCallResult<TResult>((int)response.StatusCode, JsonConvert.DeserializeObject<TResult>(response.Content.ReadAsStringAsync().Result));
                return await Task.FromResult(result);
            }
        }

        /// <inheritdoc />
        public async Task<ServiceCallResult<TResult>> ExecutePost<TResult>(string url, object content)
        {
            try
            {
                this.httpClient = new HttpClient { Timeout = TimeSpan.FromSeconds(TimeoutInSeconds) };

                var json = JsonConvert.SerializeObject(content);
                var response = await this.httpClient.PostAsync(url, new StringContent(json, Encoding.UTF8, "application/json"));

                if (!response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == HttpStatusCode.BadRequest)
                    {
                        throw new InvalidUserAccessException();
                    }

                    if (response.StatusCode == HttpStatusCode.InternalServerError)
                    {
                        throw new ServiceCallException();
                    }
                }

                var result = new ServiceCallResult<TResult>((int)response.StatusCode, JsonConvert.DeserializeObject<TResult>(response.Content.ReadAsStringAsync().Result));
                return await Task.FromResult(result);
            }
            catch (Exception exception)
            {
                throw new ServiceCallException(exception);
            }
            finally
            {
                this.httpClient.Dispose();
                this.httpClient = null;
            }
        }
    }
}