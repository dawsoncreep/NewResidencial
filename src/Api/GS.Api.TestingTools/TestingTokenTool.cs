// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestingTokenTool.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the TestingTokenTool type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Authentication.TestingTools
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
        /// Gets theJWT secret key.
        /// </summary>
        public static string SecretKey => "0d549739-4532-42cf-b3ce-0077008241fe";

        /// <summary>
        /// Gets the JWT issuer.
        /// </summary>
        public static string IssuerKey => "3bd96eff-9a3e-40fc-97df-92484b51fa89";

        /// <summary>
        /// Gets the audience key.
        /// </summary>
        public static string AudienceKey => "eafdac93-3432-406c-89ef-eb8ce63b9daa";

        /// <summary>
        /// Gets the expire time in minutes key.
        /// </summary>
        public static string ExpireTimeKey => "120";

        /// <summary>
        /// Gets a value indicating whatever a JWT is valid.
        /// </summary>
        /// <param name="token">
        /// The token.
        /// </param>
        /// <param name="secretKey">
        /// The secret Key.
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
        public static bool IsTokenValid(string token, string secretKey = null, string issuer = null, string audience = null)
        {
            var key1 = secretKey ?? SecretKey;
            var key2 = audience ?? AudienceKey;
            var key3 = issuer ?? IssuerKey;

            SecurityToken validatedToken;
            var tokenHandler = new JwtSecurityTokenHandler();
            var bytes = Encoding.UTF8.GetBytes(key1);

            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(bytes),
                ValidAudience = key2,
                ValidIssuer = key3
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
        public static string GenerateToken(string username, string secretKey = null, string issuer = null, string audience = null)
        {
            var key1 = secretKey ?? SecretKey;
            var key2 = audience ?? AudienceKey;
            var key3 = issuer ?? IssuerKey;

            var securityKey = new SymmetricSecurityKey(Encoding.Default.GetBytes(key1));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            var claimsIdentity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, username, ClaimTypes.UserData, "{\"userData\":[{\"role\":\"Administrator\",\"allowTo\":[\"Read\",\"Modify\",\"Add\",\"Delete\"]},{\"role\":\"Mortal\",\"allowTo\":[\"Read\"]}]}") });

            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = tokenHandler.CreateJwtSecurityToken(
                audience: key2,
                issuer: key3,
                subject: claimsIdentity,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddMinutes(Convert.ToInt32(ExpireTimeKey)),
                signingCredentials: signingCredentials);

            var jwtTokenString = tokenHandler.WriteToken(jwtSecurityToken);
            return jwtTokenString;
        }

        /// <summary>
        /// Gets the JWT payload object.
        /// </summary>
        /// <param name="token">
        /// The jwt token.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        public static JwtPayload GetTokenPayload(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var result = handler.ReadJwtToken(token);
            return result.Payload;
        }
    }
}