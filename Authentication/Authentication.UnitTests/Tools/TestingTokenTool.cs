// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestingTokenTool.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the TestingTokenTool type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Authentication.UnitTests.Tools
{
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;

    using Microsoft.IdentityModel.Tokens;

    /// <summary>
    /// A tool to validate Json Web Tokens in 'Unit Test' and 'Integration Tests' only.
    /// </summary>
    public static class TestingTokenTool
    {
        /// <summary>
        /// Gets a value indicating whatever a JWT is valid.
        /// </summary>
        /// <param name="token">
        /// The token.
        /// </param>
        /// <param name="key">
        /// The secret key.
        /// </param>
        /// <param name="issuer">
        /// The token issuer.
        /// </param>
        /// <param name="audience">
        /// The token audience.
        /// </param>
        /// <returns>
        /// The validation result as <see cref="bool"/>.
        /// </returns>
        public static bool IsTokenValid(string token, string key, string issuer, string audience)
        {
            SecurityToken validatedToken;
            var tokenHandler = new JwtSecurityTokenHandler();
            var bytes = Encoding.UTF8.GetBytes(key);

            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(bytes),
                ValidAudience = audience,
                ValidIssuer = issuer
            };

            try
            {
                tokenHandler.ValidateToken(token, validationParameters, out validatedToken);
            }
            catch (Exception)
            {
                return false;
            }

            return validatedToken != null;
        }

        /// <summary>
        /// Generates a new JWT for the current user.
        /// </summary>
        /// <param name="username">
        /// The username.
        /// </param>
        /// <param name="secretKey">
        /// The secret key.
        /// </param>
        /// <param name="issuer">
        /// The token issuer.
        /// </param>
        /// <param name="audience">
        /// The token audience.
        /// </param>
        /// <returns>
        /// The JWT as <see cref="string"/>.
        /// </returns>
        public static string GenerateToken(string username, string secretKey, string issuer, string audience)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.Default.GetBytes(secretKey));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            var claimsIdentity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, username, ClaimTypes.UserData, "{\"userData\":[{\"role\":\"Administrator\",\"allowTo\":[\"Read\",\"Modify\",\"Add\",\"Delete\"]},{\"role\":\"Mortal\",\"allowTo\":[\"Read\"]}]}") });

            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = tokenHandler.CreateJwtSecurityToken(
                audience: audience,
                issuer: issuer,
                subject: claimsIdentity,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddMinutes(720),
                signingCredentials: signingCredentials);

            var jwtTokenString = tokenHandler.WriteToken(jwtSecurityToken);
            return jwtTokenString;
        }
    }
}