// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BaseService.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the BaseService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GS.Mobile.DataLayer.Services
{
    using GS.OperationalManagement.Configurations;

    /// <summary>
    /// The base service.
    /// </summary>
    public abstract class BaseService
    {
        /// <summary>
        /// The key to be used in configuration file.
        /// </summary>
        private const string ServerUrlKey = "ServerUrl";

        /// <summary>
        /// The configuration manager.
        /// </summary>
        private readonly IConfigurationManager configurationManager;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseService"/> class.
        /// </summary>
        /// <param name="configurationManager">
        /// The configuration manager.
        /// </param>
        protected BaseService(IConfigurationManager configurationManager)
        {
            this.configurationManager = configurationManager;
        }

        /// <summary>
        /// Gets or sets the server url.
        /// </summary>
        protected string ServerUrl => this.configurationManager.GetAppSettingsValue<string>(ServerUrlKey);
    }
}