// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DevelopmentLogger.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the DevelopmentLogger type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Authentication.OperationalManagement.Abstractions
{
    using System;
    using System.Threading.Tasks;

    using Authentication.OperationalManagement.Interfaces;
    using Authentication.Types.Exceptions;

    /// <summary>
    /// The development logger.
    /// </summary>
    public class DevelopmentLogger : ILogger
    {
        /// <inheritdoc />
        public int Category => 1;

        /// <inheritdoc />
        public Task InfoAsync(string message, int category, object extra = null)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task WarningAsync(string message, int category, object extra = null)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task WarningAsync(BusinessLayerException exception, int category, object extra = null)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task ErrorAsync(string message, int category, object extra = null)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task ErrorAsync(Exception exception, int category, object extra = null)
        {
            throw new NotImplementedException();
        }
    }
}