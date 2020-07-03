// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Log4NetLogger.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the Log4NetLogger type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GS.Api.OperationalManagement.Abstractions
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using GS.Api.OperationalManagement.Extensions;
    using GS.Api.Types.Exceptions;

    using log4net;
    using log4net.Core;

    using ILogger = GS.Api.OperationalManagement.Interfaces.ILogger;

    /// <summary>
    /// The log 4 net logger.
    /// </summary>
    public class Log4NetLogger : ILogger
    {
        /// <summary>
        /// The Log4nNet log object.
        /// </summary>
        private ILog log;

        /// <summary>
        /// Initializes a new instance of the <see cref="WindowsEventLogger"/> class.
        /// </summary>
        public Log4NetLogger()
        {
            this.log = LogManager.GetLogger(typeof(DevelopmentLogger));
        }

        /// <inheritdoc />
        public int Category => Thread.CurrentThread.ManagedThreadId;

        /// <inheritdoc />
        public async Task InfoAsync(string message, int category, object extra = null)
        {
            await Task.Run(() => this.log.Logger.Log(this.GetType(), Level.Info, message, null));
        }

        /// <inheritdoc />
        public async Task WarningAsync(string message, int category, object extra = null)
        {
            await Task.Run(() => this.log.Logger.Log(this.GetType(), Level.Warn, message, null));
        }

        /// <inheritdoc />
        public async Task WarningAsync(BusinessLayerException exception, int category, object extra = null)
        {
            await Task.Run(() => this.log.Logger.Log(this.GetType(), Level.Warn, exception.Handle(), null));
        }

        /// <inheritdoc />
        public async Task ErrorAsync(string message, int category, object extra = null)
        {
            await Task.Run(() => this.log.Logger.Log(this.GetType(), Level.Error, message, null));
        }

        /// <inheritdoc />
        public async Task ErrorAsync(Exception exception, int category, object extra = null)
        {
            await Task.Run(() => this.log.Logger.Log(this.GetType(), Level.Error, exception.Handle(), exception));
        }
    }
}