// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DummyConfigurationManager.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the DummyConfigurationManager type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GuizzySeguridad.Common.OperationalManagement.Abstractions
{
    using System.Collections.Specialized;
    using System.Configuration;

    using GuizzySeguridad.Common.OperationalManagement.Abstractions.Interfaces;

    /// <summary>
    /// A super basic dummy implementation of the famous 'ConfigurationManager' class.
    /// </summary>
    public class DummyConfigurationManager : IConfigurationManager
    {
        /// <inheritdoc />
        public NameValueCollection AppSettings => ConfigurationManager.AppSettings;

        /// <inheritdoc />
        public ConnectionStringSettingsCollection ConnectionStrings => ConfigurationManager.ConnectionStrings;
    }
}