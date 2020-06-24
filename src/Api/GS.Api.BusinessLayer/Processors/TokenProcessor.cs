// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TokenProcessor.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the TokenProcessor type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GS.Api.BusinessLayer.Processors
{
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;

    using GS.Api.BusinessLayer.Interfaces.Processor;
    using GS.Api.OperationalManagement.Interfaces;
    using GS.Api.Types.Exceptions;
    using GS.Api.Types.Models;

    using Microsoft.IdentityModel.Tokens;

    /// <summary>
    /// The token processor.
    /// </summary>
    public class TokenProcessor : ITokenProcessor
    {
        /// <summary>
        /// The configuration file secret key.
        /// </summary>
        private const string SecretKey = "JWT_SECRET_KEY";

        /// <summary>
        /// The configuration file audience key.
        /// </summary>
        private const string AudienceKey = "JWT_AUDIENCE_TOKEN";

        /// <summary>
        /// The configuration file issuer key.
        /// </summary>
        private const string IssuerKey = "JWT_ISSUER_TOKEN";

        /// <summary>
        /// The configuration file expire time key.
        /// </summary>
        private const string ExpireKey = "JWT_EXPIRE_MINUTES";

        /// <summary>
        /// The data manager.
        /// </summary>
        private readonly IDataManager dataManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="TokenProcessor"/> class.
        /// </summary>
        /// <param name="dataManager">
        /// The data manager.
        /// </param>
        public TokenProcessor(IDataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        /// <inheritdoc />
        public Task<string> GenerateToken(User user)
        {
            string key, issuer, audience;
            int minutesToExpire;

            try
            {
                key = this.dataManager.GetSettingsValue(SecretKey);
                issuer = this.dataManager.GetSettingsValue(IssuerKey);
                audience = this.dataManager.GetSettingsValue(AudienceKey);
                minutesToExpire = Convert.ToInt32(this.dataManager.GetSettingsValue(ExpireKey));
            }
            catch (NullConfigurationException exception)
            {
                throw new TokenGenerationException(exception);
            }

            var securityKey = new SymmetricSecurityKey(Encoding.Default.GetBytes(key));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            var claimsIdentity = new ClaimsIdentity(
                new[]
                    {
                        new Claim(ClaimTypes.PrimarySid, user.Id.ToString()),
                        new Claim(ClaimTypes.Name, user.Name),
                        new Claim(ClaimTypes.Email, user.Email),
                        new Claim(ClaimTypes.Role, user.Role),
                    });

            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = tokenHandler.CreateJwtSecurityToken(
                audience: audience,
                issuer: issuer,
                subject: claimsIdentity,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddMinutes(minutesToExpire),
                signingCredentials: signingCredentials);

            return Task.FromResult(tokenHandler.WriteToken(jwtSecurityToken));
        }
    }
}