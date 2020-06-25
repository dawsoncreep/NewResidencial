// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ApplicationDataManager.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the ApplicationDataManager type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GS.OperationalManagement.Configurations
{
    using System;
    using System.Collections.Specialized;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Xml;

    using GS.Mobile.Types.Exceptions;

    /// <summary>
    /// The application data manager.
    /// </summary>
    public class ApplicationDataManager : IConfigurationManager
    {
        /// <summary>
        /// The settings.
        /// </summary>
        private readonly NameValueCollection settings;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationDataManager"/> class.
        /// </summary>
        /// <param name="configFilePath">
        /// The config File Path.
        /// </param>
        /// <exception cref="FileNotFoundException">
        /// Thrown when the configuration file is not found. 
        /// </exception>
        public ApplicationDataManager(string configFilePath)
        {
            this.settings = new NameValueCollection();

            if (!File.Exists(configFilePath))
            {
                throw new FileNotFoundException("The \"Settings.xml\" file was not found");
            }

            this.LoadConfigFile(configFilePath);
        }

        /// <inheritdoc />
        public TResult GetAppSettingsValue<TResult>(string key)
        {
            TResult result;

            var value = this.settings[key];

            if (string.IsNullOrEmpty(value))
            {
                throw new NullConfigurationValueException();
            }

            try
            {
                result = (TResult)Convert.ChangeType(value, typeof(TResult), CultureInfo.InvariantCulture);
            }
            catch (Exception exception)
            {
                throw new NullConfigurationValueException(exception);
            }

            return result;
        }

        /// <summary>
        /// The load config file.
        /// </summary>
        /// <param name="path">
        /// The path.
        /// </param>
        /// <exception cref="FileNotFoundException">
        /// Thrown when the configuration file is not found. 
        /// </exception>
        private void LoadConfigFile(string path)
        {
            var xmlConfig = new XmlDocument();
            xmlConfig.Load(path);
            var xmlNodes = xmlConfig.GetElementsByTagName("appSettings");

            foreach (var key in from XmlNode node in xmlNodes from XmlNode key in node.ChildNodes select key)
            {
                if (key.Attributes != null)
                {
                    this.settings.Add(key.Attributes["key"].Value, key.Attributes["value"].Value);
                }
            }
        }
    }
}