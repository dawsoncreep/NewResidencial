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
    using System.Diagnostics.CodeAnalysis;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;

    using GS.Mobile.Types.Network;

    using Newtonsoft.Json;

    /// <summary>
    /// The service manager.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class ServiceManager : IServiceManager
    {
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
            using (var httpClient = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(content);
                var response = await httpClient.PostAsync(url, new StringContent(json, Encoding.UTF8, "application/json"));
                var result = new ServiceCallResult<TResult>((int)response.StatusCode, JsonConvert.DeserializeObject<TResult>(response.Content.ReadAsStringAsync().Result));
                return await Task.FromResult(result);
            }
        }
    }
}