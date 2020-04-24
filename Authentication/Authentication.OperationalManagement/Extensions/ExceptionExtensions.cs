// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExceptionExtensions.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the ExceptionExtensions type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Authentication.OperationalManagement.Extensions
{
    using System;
    using System.Text;

    using Authentication.Types.Exceptions;

    /// <summary>
    /// The exception extensions.
    /// </summary>
    public static class ExceptionExtensions
    {
        /// <summary>
        /// Handles the exception an prepares a detail report.
        /// </summary>
        /// <param name="target">
        /// The target exception that was thrown.
        /// </param>
        /// <returns>
        /// Detail report as <see cref="string"/>.
        /// </returns>
        public static string Handle(this Exception target)
        {
            if (target is AggregateException exception)
            {
                return WalkAggregateException(exception);
            }

            return WalkException(target);
        }
        
        #region Private Methods

        /// <summary>
        /// Walks through each exception and prepares a detail report.
        /// </summary>
        /// <param name="aex">
        /// The aggregate exception.
        /// </param>
        /// <returns>
        /// Detail report as <see cref="string"/>.
        /// </returns>
        private static string WalkAggregateException(AggregateException aex)
        {
            var counter = 1;
            var message = new StringBuilder();
            message.Append("\nAn aggregate error has detected.\n\nExceptions:\n\n");

            foreach (var ex in aex.Flatten().InnerExceptions)
            {
                var innerMessage = WalkException(ex, false);
                message.Append($"{counter++})\n\n");
                message.Append($"{innerMessage}\n\n");
            }
            
            message.Append("\nStackTrace: \n\n");
            message.Append(aex.StackTrace);

            return message.ToString();
        }

        /// <summary>
        /// Walks through the exception and prepares a detail report.
        /// </summary>
        /// <param name="ex">
        /// The exception.
        /// </param>
        /// <param name="includeStackTrace">
        /// The include Stack Trace.
        /// </param>
        /// <returns>
        /// Detail report as <see cref="string"/>.
        /// </returns>
        private static string WalkException(Exception ex, bool includeStackTrace = true)
        {
            var messageType = ex.GetType() == typeof(BusinessLayerException) ? "business" : "application";
            var message = new StringBuilder();
            message.Append($"\nAn '{messageType}' error has been detected. \n");
            message.Append($"\nMain error: \n\n {ex.Message} \n\nDetails: \n\n");

            var inner = ex.InnerException;

            if (inner == null)
            {
                message.Append("No details");
            }
            else
            {
                while (inner != null)
                {
                    message.Append($"  InnerException: {inner.Message} \n");
                    inner = inner.InnerException;
                }
            }

            if (!includeStackTrace)
            {
                return message.ToString();
            }

            message.Append("\nStackTrace: \n\n");
            message.Append(ex.StackTrace);

            return message.ToString();
        }
        #endregion
    }
} 