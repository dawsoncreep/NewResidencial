﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataManager.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the DataManager type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GuizzySeguridad.Common.OperationalManagement.Generals
{
    using GuizzySeguridad.Common.OperationalManagement.Abstractions.Interfaces;
    using GuizzySeguridad.Common.OperationalManagement.Interfaces;
    using GuizzySeguridad.Common.Types.Exceptions;

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
        public string GetSettingsValue(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new NullConfigurationException();
            }

            var value = this.configurationManager.AppSettings[key];

            if (string.IsNullOrEmpty(value))
            {
                var data = this.configurationManager.ConnectionStrings[key];
                value = data != null ? data.ConnectionString : string.Empty;
            }
            
            if (string.IsNullOrEmpty(value))
            {
                throw new NullConfigurationException();
            }

            return value.Trim();
        }
    }
}