// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataManager.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the DataManager type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Authentication.OperationalManagement.Common
{
    using Authentication.OperationalManagement.Abstractions.Interfaces;
    using Authentication.OperationalManagement.Interfaces;
    using Authentication.Types.Exceptions;

    /// <summary>
    /// The application data manager.
    /// </summary>
    public class DataManager : IDataManager
    {
        /// <summary>
        /// The configuration manager.
        /// </summary>
        private readonly IConfigurationManager configurationManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="DataManager"/> class.
        /// </summary>
        /// <param name="configurationManager">
        /// The configuration manager.
        /// </param>
        public DataManager(IConfigurationManager configurationManager)
        {
            this.configurationManager = configurationManager;
        }

        /// <inheritdoc />
        public string GetAppSettingsValue(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new NullConfigurationException();
            }

            var value = this.configurationManager.AppSettings[key];
            
            if (string.IsNullOrEmpty(value))
            {
                throw new NullConfigurationException();
            }

            return value.Trim();
        }
    }
}