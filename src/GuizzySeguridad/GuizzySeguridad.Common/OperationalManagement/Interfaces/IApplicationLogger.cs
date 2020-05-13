// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IApplicationLogger.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the IApplicationLogger type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GuizzySeguridad.Common.OperationalManagement.Interfaces
{
    using System;
    using System.Threading.Tasks;

    using GuizzySeguridad.Common.Types.Enums;

    /// <summary>
    /// The ApplicationLogger interface.
    /// </summary>
    public interface IApplicationLogger
    {
        /// <summary>
        /// Logs a message into system.
        /// </summary>
        /// <param name="type">
        /// The log type (Information, Warning or Error).
        /// </param>
        /// <param name="message">
        /// The message to be logged.
        /// </param>
        /// <param name="extra">
        /// Extra information to be logged.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task Log(LogType type, string message, object extra = null);

        /// <summary>
        /// Logs an exception into system.
        /// </summary>
        /// <param name="exception">
        /// The exception to be logged.
        /// </param>
        /// <param name="extra">
        /// Extra information to be logged.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task Log(Exception exception, object extra = null);
    }
}