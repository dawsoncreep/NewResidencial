// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WindowsEventLogger.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the WindowsEventLogger type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GS.Api.OperationalManagement.Abstractions
{
    using System;
    using System.Diagnostics;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    using GS.Api.OperationalManagement.Extensions;
    using GS.Api.OperationalManagement.Interfaces;
    using GS.Api.Types.Exceptions;

    /// <summary>
    /// The windows event logger.
    /// </summary>
    public class WindowsEventLogger : ILogger
    {
        /// <summary>
        /// The event log name.
        /// </summary>
        private const string EventLogName = "Authentication.Api";

        /// <summary>
        /// The event source name.
        /// </summary>
        private const string EventSourceName = "Resicencial";

        /// <summary>
        /// Initializes a new instance of the <see cref="WindowsEventLogger"/> class.
        /// </summary>
        public WindowsEventLogger()
        {
            if (!(EventLog.SourceExists(EventSourceName) && EventLog.Exists(EventLogName)))
            {
                EventLog.CreateEventSource(EventSourceName, EventLogName);
            }
        }

        /// <inheritdoc />
        public int Category => Thread.CurrentThread.ManagedThreadId;

        /// <inheritdoc />
        public async Task InfoAsync(string message, int category, object extra = null)
        {
            await WriteLog(message, EventLogName, category, EventLogEntryType.Information, extra);
        }

        /// <inheritdoc />
        public async Task WarningAsync(string message, int category, object extra = null)
        {
            await WriteLog(message, EventLogName, category, EventLogEntryType.Warning, extra);
        }

        /// <inheritdoc />
        public async Task WarningAsync(BusinessLayerException exception, int category, object extra = null)
        {
            await WriteLog(exception.Handle(), EventLogName, category, EventLogEntryType.Warning, extra);
        }

        /// <inheritdoc />
        public async Task ErrorAsync(string message, int category, object extra = null)
        {
            await WriteLog(message, EventLogName, category, EventLogEntryType.Error, extra);
        }

        /// <inheritdoc />
        public async Task ErrorAsync(Exception exception, int category, object extra = null)
        {
            await WriteLog(exception.Handle(), EventLogName, category, EventLogEntryType.Error, extra);
        }

        /// <summary>
        /// Manages insertions on windows event log.
        /// </summary>
        /// <param name="message">
        /// Message to be placed in windows event log.
        /// </param>
        /// <param name="logName">
        /// The log Name.
        /// </param>
        /// <param name="category">
        /// The category.
        /// </param>
        /// <param name="entryType">
        /// Message' type
        /// </param>
        /// <param name="extra">
        /// The extra.
        /// </param>
        /// <returns>
        /// Returns a Task object.
        /// </returns>
        private static async Task WriteLog(string message, string logName, int category, EventLogEntryType entryType, object extra)
        {
            var messageToLog = new StringBuilder(message);

            if (extra != null)
            {
                messageToLog.Append(Environment.NewLine);
                messageToLog.Append("Extra data has been logged: ");
                messageToLog.Append(extra.ToJson());
                messageToLog.Append(Environment.NewLine);
            }

            using (var log = new EventLog(logName, ".", logName))
            {
                log.WriteEntry(messageToLog.ToString(), entryType, category);
            }

            await Task.CompletedTask;
        }
    }
}