// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDataManager.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the IDataManager type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GuizzySeguridad.Common.OperationalManagement.Interfaces
{
    using GuizzySeguridad.Common.Types.Exceptions;

    /// <summary>
    /// The ConfigurationManager interface.
    /// </summary>
    public interface IDataManager
    {
        /// <summary>
        /// Gets an 'AppSettings' or 'ConnectionString' value inside the configuration file.
        /// </summary>
        /// <param name="key">
        /// The target key.
        /// </param>        
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        /// <exception cref="NullConfigurationException">
        /// Thrown when key is not present or its value is incorrect.
        /// </exception>        
        string GetSettingsValue(string key);
    }
}