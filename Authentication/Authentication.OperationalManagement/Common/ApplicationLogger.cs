// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ApplicationLogger.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the ApplicationLogger type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Authentication.OperationalManagement.Common
{
    using System;
    using System.Threading.Tasks;

    using Authentication.OperationalManagement.Interfaces;
    using Authentication.Types.Enums;
    using Authentication.Types.Exceptions;

    /// <summary>
    /// The default logger.
    /// </summary>
    public class ApplicationLogger : IApplicationLogger
    {
        /// <summary>
        /// The logger to use.
        /// </summary>
        private readonly ILogger targetLogger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationLogger"/> class.
        /// </summary>
        /// <param name="logger">
        /// The logger.
        /// </param>
        public ApplicationLogger(ILogger logger)
        {
            this.targetLogger = logger;
        }

        #region Public Methods
        
        #endregion

        #region Private Methods
        #endregion

        /// <inheritdoc />
        public async Task Log(LogType type, string message, object extra = null)
        {
            switch (type)
            {
                case LogType.Information:
                    await this.targetLogger.InfoAsync(message, this.targetLogger.Category, extra); 
                    break;
                case LogType.Warning:
                    await this.targetLogger.WarningAsync(message, this.targetLogger.Category, extra);
                    break;
                case LogType.Error:
                    await this.targetLogger.ErrorAsync(message, this.targetLogger.Category, extra);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        /// <inheritdoc />
        public async Task Log(Exception exception, object extra = null)
        {
            if (exception is BusinessLayerException businessLayerException)
            {
                await this.targetLogger.WarningAsync(businessLayerException, this.targetLogger.Category, extra);
            }
            else
            {
                await this.targetLogger.ErrorAsync(exception, this.targetLogger.Category, extra);
            }
        }
    }
}