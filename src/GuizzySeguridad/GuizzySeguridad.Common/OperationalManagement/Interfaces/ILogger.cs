// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ILogger.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the ILogger type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GuizzySeguridad.Common.OperationalManagement.Interfaces
{
    using System;
    using System.Threading.Tasks;

    using GuizzySeguridad.Common.Types.Exceptions;

    /// <summary>
    /// The Logger interface.
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Gets the category.
        /// </summary>
        int Category { get; }

        /// <summary>
        /// Logs an information message asynchronously.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <param name="category">
        /// The message category.
        /// </param>
        /// <param name="extra">
        /// Optional data to be logged.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task InfoAsync(string message, int category, object extra = null);

        /// <summary>
        /// Logs a warning message asynchronously.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <param name="category">
        /// The warning category.
        /// </param>
        /// <param name="extra">
        /// Optional data to be logged.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task WarningAsync(string message, int category, object extra = null);

        /// <summary>
        /// Logs a warning message asynchronously.
        /// </summary>
        /// <param name="exception">
        /// The exception.
        /// </param>
        /// <param name="category">
        /// The warning category.
        /// </param>
        /// <param name="extra">
        /// Optional data to be logged.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task WarningAsync(BusinessLayerException exception, int category, object extra = null);
        
        /// <summary>
        /// Logs an error message asynchronously.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <param name="category">
        /// The error category.
        /// </param>
        /// <param name="extra">
        /// Optional data to be logged.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task ErrorAsync(string message, int category, object extra = null);

        /// <summary>
        /// Logs an error message asynchronously.
        /// </summary>
        /// <param name="exception">
        /// The error exception.
        /// </param>
        /// <param name="category">
        /// The error category.
        /// </param>
        /// <param name="extra">
        /// Optional data to be logged.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task ErrorAsync(Exception exception, int category, object extra = null);
    }
}