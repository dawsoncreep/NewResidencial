// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IConfigurationManager.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   The ConfigurationManager interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GS.OperationalManagement.Configurations
{
    using GS.Mobile.Types.Exceptions;

    /// <summary>
    /// The ConfigurationManager interface.
    /// </summary>
    public interface IConfigurationManager
    {
        /// <summary>
        /// Gets the value of an AppSettings key inside the configuration file.-
        /// </summary>
        /// <typeparam name="TResult">
        /// Specific type to be converted.
        /// </typeparam>
        /// <param name="key">
        /// The key.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        /// <exception cref="NullConfigurationValueException">
        /// Thrown when  key is not present or is empty or the value cannot be converted to specified TResult type.
        /// </exception>
        TResult GetAppSettingsValue<TResult>(string key);
    }
}