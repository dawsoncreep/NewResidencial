// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TokenProcessor.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the TokenProcessor type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GS.Mobile.BusinessLayer.Processors
{
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Threading.Tasks;

    using GS.Mobile.BusinessLayer.Interfaces;
    using GS.Mobile.Types.Security;

    /// <summary>
    /// The token processor.
    /// </summary>
    public class TokenProcessor : ITokenProcessor
    {
        /// <inheritdoc />
        public async Task<Token> DecodeTokenString(string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                return await Task.FromResult(default(Token));
            }

            if (!this.ValidateTokenString(token))
            {
                return await Task.FromResult(default(Token));
            }

            try
            {
                var handler = new JwtSecurityTokenHandler();
                var result = handler.ReadJwtToken(token);
                return await Task.FromResult(new Token
                {
                    SingleId = Convert.ToInt32(result.Payload["primarysid"]),
                    UniqueName = result.Payload["unique_name"].ToString(),
                    Email = result.Payload["email"].ToString(),
                    Role = result.Payload["role"].ToString()
                });
            }
            catch (Exception)
            {
                return await Task.FromResult(default(Token));
            }
        }

        /// <inheritdoc />
        public bool ValidateTokenString(string token)
        {
            try
            {
                var handler = new JwtSecurityTokenHandler();
                var result = handler.ReadJwtToken(token);
                return result != null;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}