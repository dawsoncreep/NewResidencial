// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SessionProcessor.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the SessionProcessor type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GS.Mobile.BusinessLayer.Processors
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using GS.Mobile.BusinessLayer.Interfaces;
    using GS.Mobile.DataLayer.Entities;
    using GS.Mobile.DataLayer.Repository.Token;
    using GS.Mobile.Types.Exceptions;

    /// <summary>
    /// The session processor.
    /// </summary>
    public class SessionProcessor : ISessionProcessor
    {
        /// <summary>
        /// The token repository.
        /// </summary>
        private readonly ITokenRepository tokenRepository;

        /// <summary>
        /// The token processor.
        /// </summary>
        private readonly ITokenProcessor tokenProcessor;

        /// <summary>
        /// Initializes a new instance of the <see cref="SessionProcessor"/> class.
        /// </summary>
        /// <param name="tokenProcessor">
        /// The token Processor.
        /// </param>
        /// <param name="tokenRepository">
        /// The token repository.
        /// </param>
        public SessionProcessor(ITokenProcessor tokenProcessor, ITokenRepository tokenRepository)
        {
            this.tokenProcessor = tokenProcessor;
            this.tokenRepository = tokenRepository;
        }

        /// <inheritdoc />
        public async Task<string> GetAccessToken()
        {
            try
            {
                string token;
                var data = await this.tokenRepository.GetAllByPageAsync();

                if (data == null || !data.Any())
                {
                    token = string.Empty;
                }
                else if (data.Count > 1)
                {
                    await this.tokenRepository.RemoveAll();
                    token = string.Empty;
                }
                else
                {
                    token = data.First().Data;
                }

                return await Task.FromResult(token);
            }
            catch (Exception)
            {
                return await Task.FromResult(default(string));
            }
        }

        /// <inheritdoc />
        public async Task<bool> ValidateSessionWithRoles(string allowedRoles)
        {
            var roles = allowedRoles.Split(',');
            var token = await this.GetAccessToken();
            var tokenData = await this.tokenProcessor.DecodeTokenString(token);

            if (tokenData == null)
            {
                return await Task.FromResult(false);
            }

            return await Task.FromResult(roles.Any(item => item == tokenData.Role));
        }

        /// <inheritdoc />
        public async Task SaveToken(string token)
        {
            if (!this.tokenProcessor.ValidateTokenString(token))
            {
                throw new InvalidTokenValidationException();
            }

            try
            {
                var entity = new SToken { Id = Guid.NewGuid(), Data = token };
                await this.tokenRepository.AddAsync(entity);
            }
            catch (Exception exception)
            {
                throw new InvalidTokenValidationException(exception);
            }
        }
    }
}