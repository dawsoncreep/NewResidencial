// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ApplicationDataManagerTests.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the ApplicationDataManagerTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GS.Mobile.UnitTests.ForOperationalManagement
{
    using System.IO;
    using System.Reflection;

    using GS.Mobile.Types.Exceptions;
    using GS.OperationalManagement.Configurations;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// The application data manager test.
    /// </summary>
    [TestClass]
    public class ApplicationDataManagerTests
    {
        /// <summary>
        /// <see cref="IConfigurationManager"/> implementation under test.
        /// </summary>
        private IConfigurationManager objectUt;

        /// <summary>
        /// This method is used to configure the environment before each test.
        /// </summary>
        [TestInitialize]
        public void RunBeforeEachTest()
        {
            var appPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
            var configFile = Path.Combine(appPath, "Settings.xml");

            if (configFile.StartsWith("file:\\"))
            {
                configFile = configFile.Substring(6);
            }

            this.objectUt = new ApplicationDataManager(configFile);
        }

        /// <summary>
        /// This method is used to clean the environment after each test.
        /// </summary>
        [TestCleanup]
        public void RunAfterEachTest()
        {
            this.objectUt = null;
        }

        #region Constructor()

        /// <summary>
        /// This method should fail when configuration file is not found on in given path.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void ConstructorShouldThrownExceptionWhenConfigFileIsNotFound()
        {
            // Arrange
            const string Path = "C:\\NonExistentFolder\\Setting.xml";

            // Act
            this.objectUt = new ApplicationDataManager(Path);

            // Assert
            // Assert.Fail("No exceptions were thrown.");
        }
        #endregion

        #region GetAppSettingsValue()

        /// <summary>
        /// This method should successfully return a value from configuration file.
        /// </summary>
        [TestMethod]
        public void GetAppSettingsValueShouldSucceed()
        {
            // Arrange
            const string AppSettingKey = "TestValue1";
            const string ExpectedValue = "15K|A|M";

            // Act
            var actualValue = this.objectUt.GetAppSettingsValue<string>(AppSettingKey);

            // Assert
            Assert.AreEqual(ExpectedValue, actualValue);
        }

        /// <summary>
        /// This method should thrown <see cref="NullConfigurationValueException"/> when given key is not present inside configuration file. 
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(NullConfigurationValueException))]
        public void GetAppSettingsValueShouldThrownNullConfigurationValueExceptionWhenKeyIsNotPresent()
        {
            // Arrange 
            const string AppSettingKey = "TestValue2";

            // Act
            this.objectUt.GetAppSettingsValue<string>(AppSettingKey);

            // Assert
            // Assert.Fail("No exceptions were thrown.");
        }

        /// <summary>
        /// This method should thrown <see cref="NullConfigurationValueException"/> when given key is present inside configuration file but has no data. 
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(NullConfigurationValueException))]
        public void GetAppSettingsValueShouldThrownNullConfigurationValueExceptionWhenKeyIsNull()
        {
            // Arrange
            const string AppSettingKey = "TestValue3";

            // Act
            this.objectUt.GetAppSettingsValue<string>(AppSettingKey);

            // Assert
            // Assert.Fail("No exceptions were thrown.");
        }

        /// <summary>
        /// The get app settings value should thrown null configuration value exception when convertible.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(NullConfigurationValueException))]
        public void GetAppSettingsValueShouldThrownNullConfigurationValueExceptionWhenConvertible()
        {
            // Arrange
            const string AppSettingKey = "ServerUrl";

            // Act
            this.objectUt.GetAppSettingsValue<int>(AppSettingKey);

            // Assert
            // Assert.Fail("No exceptions were thrown.");
        }
        #endregion
    }
}