// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TokenProcessor.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the TokenProcessor type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Authentication.BusinessLayer.Processors
{
    using System.Threading.Tasks;

    using Authentication.BusinessLayer.Interfaces.Processor;
    using Authentication.Types.Models;

    /// <summary>
    /// The token processor.
    /// </summary>
    public class TokenProcessor : ITokenProcessor
    {
        /// <inheritdoc />
        public Task<string> GenerateToken(User user)
        {
            throw new System.NotImplementedException();
        }
    }
}