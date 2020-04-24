// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DummyConfigurationManager.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the DummyConfigurationManager type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Authentication.OperationalManagement.Abstractions
{
    using System.Collections.Specialized;
    using System.Configuration;

    using Authentication.OperationalManagement.Abstractions.Interfaces;

    /// <summary>
    /// A super basic dummy implementation of the famous 'ConfigurationManager' class.
    /// </summary>
    public class DummyConfigurationManager : IConfigurationManager
    {
        /// <inheritdoc />
        public NameValueCollection AppSettings => ConfigurationManager.AppSettings;
    }
}