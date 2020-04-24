// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WindowsEventLogger.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the WindowsEventLogger type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Authentication.OperationalManagement.Abstractions
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using Authentication.OperationalManagement.Interfaces;
    using Authentication.Types.Exceptions;

    /// <summary>
    /// The windows event logger.
    /// </summary>
    public class WindowsEventLogger : ILogger
    {
        /// <inheritdoc />
        public int Category => Thread.CurrentThread.ManagedThreadId;

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