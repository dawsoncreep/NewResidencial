// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IConfigurationManager.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the IConfigurationManager type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Authentication.OperationalManagement.Abstractions.Interfaces
{
    using System.Collections.Specialized;
    using System.Configuration;

    /// <summary>
    /// A super basic interface abstraction of the famous 'ConfigurationManager' class.
    /// </summary>
    public interface IConfigurationManager
    {
        /// <summary>
        /// Gets the app settings.
        /// </summary>
        NameValueCollection AppSettings { get; }   

        /// <summary>
        /// Gets the connection string settings.
        /// </summary>
        ConnectionStringSettingsCollection ConnectionStrings { get; }
    }
}