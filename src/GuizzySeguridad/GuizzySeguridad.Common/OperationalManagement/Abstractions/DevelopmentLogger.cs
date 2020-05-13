// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DevelopmentLogger.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the DevelopmentLogger type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GuizzySeguridad.Common.OperationalManagement.Abstractions
{
    using System;
    using System.Diagnostics;
    using System.Threading.Tasks;

    using GuizzySeguridad.Common.OperationalManagement.Extensions;
    using GuizzySeguridad.Common.OperationalManagement.Interfaces;
    using GuizzySeguridad.Common.Types.Exceptions;

    /// <summary>
    /// The development logger.
    /// </summary>
    public class DevelopmentLogger : ILogger
    {
        /// <inheritdoc />
        public int Category => 1;

        /// <inheritdoc />
        public async Task InfoAsync(string message, int category, object extra = null)
        {
            await this.WriteSimpleMessage(message, category, extra);
        }

        /// <inheritdoc />
        public async Task WarningAsync(string message, int category, object extra = null)
        {
            await this.WriteSimpleMessage(message, category, extra);
        }

        /// <inheritdoc />
        public async Task WarningAsync(BusinessLayerException exception, int category, object extra = null)
        {
            await this.WriteExceptionMessage(exception, category, extra);
        }

        /// <inheritdoc />
        public async Task ErrorAsync(string message, int category, object extra = null)
        {
            await this.WriteSimpleMessage(message, category, extra);
        }

        /// <inheritdoc />
        public async Task ErrorAsync(Exception exception, int category, object extra = null)
        {
            await this.WriteExceptionMessage(exception, category, extra);
        }

        #region Private Methods

        /// <summary>
        /// The write simple message.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <param name="category">
        /// The category.
        /// </param>
        /// <param name="extra">
        /// The extra.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        private async Task WriteSimpleMessage(string message, int category, object extra)
        {
            await Task.Run(() =>
                {
                    Trace.Write(message, category.ToString());

                    if (extra != null)
                    {
                        Trace.Write(extra.ToString());
                    }
                });
        }

        /// <summary>
        /// The write exception message.
        /// </summary>
        /// <param name="exception">
        /// The exception.
        /// </param>
        /// <param name="category">
        /// The category.
        /// </param>
        /// <param name="extra">
        /// The extra.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        private async Task WriteExceptionMessage(Exception exception, int category, object extra)
        {
            await Task.Run(() =>
                {
                    Trace.Write(exception.Handle(), category.ToString());

                    if (extra != null)
                    {
                        Trace.Write(extra.ToString());
                    }
                });
        }
        #endregion
    }
}