// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataManagerTests.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the DataManagerTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GuizzySeguridad.Common.UnitTests.Common.ForOperationalManagement.Common
{
    using System.Collections.Specialized;
    using System.Configuration;

    using GuizzySeguridad.Common.OperationalManagement.Abstractions.Interfaces;
    using GuizzySeguridad.Common.OperationalManagement.Generals;
    using GuizzySeguridad.Common.Types.Exceptions;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    /// <summary>
    /// The application data manager test.
    /// </summary>
    [TestClass]
    [TestCategory("Unit Tests")]
    public class DataManagerTests
    {
        #region Fields

        /// <summary>
        /// Dummy 'AppSettings' for testing.
        /// </summary>
        private NameValueCollection testAppSettings;

        /// <summary>
        /// Dummy 'ConnectionStrings' for testing.
        /// </summary>
        private ConnectionStringSettingsCollection testConnectionsSettings;

        /// <summary>
        /// <see cref="IConfigurationManager"/> mock object.
        /// </summary>
        private Mock<IConfigurationManager> mockIConfigurationManager;
        #endregion

        #region Tests Life Cycle

        /// <summary>
        /// This method is used to configure the environment before each test.
        /// </summary>
        [TestInitialize]
        public void RunBeforeEachTest()
        {
            // Fields
            this.testAppSettings = new NameValueCollection
                                       {
                                           { "TestingKey1", "TestingValue" },
                                           { "TestingKey2", string.Empty }
                                       };
            this.testConnectionsSettings = new ConnectionStringSettingsCollection
                                               {
                                                   new ConnectionStringSettings("SqlServer.Default", "Data Source=(localdb)\\MSSQLLocalDB;Database=Bps;Integrated Security=SSPI;")
                                               };

            // Mocks
            this.mockIConfigurationManager = new Mock<IConfigurationManager>();
            this.mockIConfigurationManager.Setup(property => property.AppSettings).Returns(this.testAppSettings);
            this.mockIConfigurationManager.Setup(property => property.ConnectionStrings).Returns(this.testConnectionsSettings);
        }

        /// <summary>
        /// This method is used to clean the environment after each test.
        /// </summary>
        [TestCleanup]
        public void RunAfterEachTest()
        {
            // Fields
            this.testAppSettings = null;

            // Mocks
            this.mockIConfigurationManager = null;
        }
        #endregion

        #region Test Methods

        /// <summary>
        /// This method should successfully return a value from configuration file.
        /// </summary>
        [TestMethod]
        public void GetAppSettingsValueShouldSucceed()
        {
            // Arrange
            const string AppSettingKey = "TestingKey1";
            const string ExpectedValue = "TestingValue";
            var objectUt = new DataManager(this.mockIConfigurationManager.Object);

            // Act
            var actualValue = objectUt.GetSettingsValue(AppSettingKey);

            // Assert
            Assert.AreEqual(ExpectedValue, actualValue);
        }

        /// <summary>
        /// This method should successfully return a value from configuration file.
        /// </summary>
        [TestMethod]
        public void GetSettingsValueShouldSucceed()
        {
            // Arrange
            const string AppSettingKey = "TestingKey1";
            const string ExpectedValue = "TestingValue";
            var objectUt = new DataManager(this.mockIConfigurationManager.Object);

            // Act
            var actualValue = objectUt.GetSettingsValue(AppSettingKey);

            // Assert
            Assert.AreEqual(ExpectedValue, actualValue);
        }

        /// <summary>
        /// This method should thrown <see cref="NullConfigurationException"/> when given key is not present inside configuration file. 
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(NullConfigurationException))]
        public void GetSettingsValueShouldThrownNullConfigurationExceptionWhenKeyIsEmpty()
        {
            // Arrange 
            var appSettingKey = string.Empty;
            var objectUt = new DataManager(this.mockIConfigurationManager.Object);

            // Act
            objectUt.GetSettingsValue(appSettingKey);

            // Assert
            // Assert.Fail("No exceptions were thrown.");
        }

        /// <summary>
        /// This method should thrown <see cref="NullConfigurationException"/> when given key is not present inside configuration file. 
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(NullConfigurationException))]
        public void GetSettingsValueShouldThrownNullConfigurationExceptionWhenKeyIsNotPresent()
        {
            // Arrange 
            const string AppSettingKey = "UnknownKey";
            var objectUt = new DataManager(this.mockIConfigurationManager.Object);

            // Act
            objectUt.GetSettingsValue(AppSettingKey);

            // Assert
            // Assert.Fail("No exceptions were thrown.");
        }

        /// <summary>
        /// This method should thrown <see cref="NullConfigurationException"/> when given key is present inside configuration file but has no data. 
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(NullConfigurationException))]
        public void GetSettingsValueShouldThrownNullConfigurationExceptionWhenKeyIsNull()
        {
            // Arrange
            const string AppSettingKey = "TestingKey2";
            var objectUt = new DataManager(this.mockIConfigurationManager.Object);

            // Act
            objectUt.GetSettingsValue(AppSettingKey);

            // Assert
            // Assert.Fail("No exceptions were thrown.");
        }
        #endregion
    }
}