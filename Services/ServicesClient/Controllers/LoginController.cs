using System.Web.Http;
using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;

namespace ServicesClient.Controllers
{
    using System.Text;

    using Newtonsoft.Json;

    using ServicesClient.Models;

    /// <summary>
    /// The login controller.
    /// </summary>
    [AllowAnonymous]
    public class LoginController : ApiController
    {
        /// <summary>
        /// Authenticates a user using the new 'WebAPI authentication API'.
        /// </summary>
        /// <param name="loginRequest">
        /// The login Request.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<IHttpActionResult> AuthenticateUser([FromBody] LoginRequest loginRequest)
        {
            using (var client = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(loginRequest);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var url = $"{ConfigurationManager.AppSettings["AuthenticationWebApiServiceUrl"]}/api/Authentication/Authenticate";

                var response = await client.PostAsync(url, content);

                if (response == null)
                {
                    return await Task.FromResult(this.InternalServerError());
                }
                
                var result = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    // if OK, result has the JWT.
                    return await Task.FromResult(this.Ok(result));
                }
                    
                // Otherwise, result has the validation error message or exception message result.
                return await Task.FromResult(this.BadRequest(result));
            }
        }
    }
}
