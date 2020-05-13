// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TokenValidationHandler.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Validador de clave de autenticación en los delegados
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GuizzySeguridad.Api
{
    using System;
    using System.Configuration;
    using System.Diagnostics.CodeAnalysis;
    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web;
    using Microsoft.IdentityModel.Tokens;

    /// <summary>
    /// The token validation handler.
    /// </summary>
    public class TokenValidationHandler : DelegatingHandler
    {
        /// <summary>
        /// The authorization.
        /// </summary>
        private const string Authorization = "Authorization";

        /// <summary>
        /// The bearer.
        /// </summary>
        private const string Bearer = "Bearer ";

        /// <summary>
        /// The lifetime validator.
        /// </summary>
        /// <param name="notBefore">
        /// The not before.
        /// </param>
        /// <param name="expires">
        /// The expires.
        /// </param>
        /// <param name="securityToken">
        /// The security token.
        /// </param>
        /// <param name="validationParameters">
        /// The validation parameters.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool LifetimeValidator(DateTime? notBefore, DateTime? expires, SecurityToken securityToken, TokenValidationParameters validationParameters)
        {
            return expires != null && DateTime.UtcNow < expires;
        }

        /// <summary>
        /// The send async.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <param name="cancellationToken">
        /// The cancellation token.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1126:PrefixCallsCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            HttpStatusCode statusCode;

            try
            {
                // determine whether a jwt exists or not
                if (!TryRetrieveToken(request, out var token))
                {
                    return base.SendAsync(request, cancellationToken);
                }

                var securityKey = new SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(ConfigurationManager.AppSettings["JWT_SECRET_KEY"]));
                var tokenHandler = new JwtSecurityTokenHandler();
                var validationParameters = new TokenValidationParameters()
                {
                    ValidAudience = ConfigurationManager.AppSettings["JWT_AUDIENCE_TOKEN"],
                    ValidIssuer = ConfigurationManager.AppSettings["JWT_ISSUER_TOKEN"],
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    LifetimeValidator = this.LifetimeValidator,
                    IssuerSigningKey = securityKey
                };

                // Extract and assign Current Principal and user
                Thread.CurrentPrincipal = tokenHandler.ValidateToken(token, validationParameters, out _);
                HttpContext.Current.User = tokenHandler.ValidateToken(token, validationParameters, out _);

                return base.SendAsync(request, cancellationToken);
            }
            catch (SecurityTokenValidationException)
            {
                statusCode = HttpStatusCode.Unauthorized;
            }
            catch (Exception)
            {
                statusCode = HttpStatusCode.InternalServerError;
            }

            return Task<HttpResponseMessage>.Factory.StartNew(() => new HttpResponseMessage(statusCode), cancellationToken);
        }

        /// <summary>
        /// The try retrieve token.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <param name="token">
        /// The token.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private static bool TryRetrieveToken(HttpRequestMessage request, out string token)
        {
            token = null;

            if (!request.Headers.TryGetValues(Authorization, out var authzHeaders) || authzHeaders.Count() > 1 || !authzHeaders.ElementAt(0).StartsWith(Bearer))
            {
                return false;
            }

            var bearerToken = authzHeaders.ElementAt(0);
            token = bearerToken.StartsWith(Bearer) ? bearerToken.Substring(7) : null;
            return true;
        }
    }
}