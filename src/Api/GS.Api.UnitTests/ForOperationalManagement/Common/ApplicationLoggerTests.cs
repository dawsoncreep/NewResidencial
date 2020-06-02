// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ApplicationLoggerTests.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the ApplicationLoggerTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Authentication.UnitTests.ForOperationalManagement.Common
{
    using System;
    using System.Threading.Tasks;

    using GS.Api.OperationalManagement.Common;
    using GS.Api.OperationalManagement.Interfaces;
    using GS.Api.Types.Enums;
    using GS.Api.Types.Exceptions;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    /// <summary>
    /// The default logger tests.
    /// </summary>
    [TestClass]
    [TestCategory("Unit Tests")]
    public class ApplicationLoggerTests
    {
        #region Fields

        /// <summary>
        /// The log message.
        /// </summary>
        private string message;

        /// <summary>
        /// <see cref="ILogger"/> mock object.
        /// </summary>
        private Mock<ILogger> mockILogger;
        #endregion

        #region Tests Life Cycle

        /// <summary>
        /// This method is used to configure the environment before each test.
        /// </summary>
        [TestInitialize]
        public void RunBeforeEachTest()
        {
            this.mockILogger = new Mock<ILogger>();
            this.message = "This is a testing message";
        }

        /// <summary>
        /// This method is used to clean the environment after each test.
        /// </summary>
        [TestCleanup]
        public void RunAfterEachTest()
        {
            this.mockILogger = null;
            this.message = string.Empty;
        }
        #endregion

        #region Test Methods

        /// <summary>
        /// This test should successfully log an informational message.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [TestMethod]
        public async Task LogInformationMessageShouldSucceed()
        {
            // Arrange
            var objUt = new ApplicationLogger(this.mockILogger.Object);

            // Act
            await objUt.Log(LogType.Information, this.message);

            // Assert
            this.mockILogger.Verify(method => method.InfoAsync(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<object>()), Times.Once);
        }

        /// <summary>
        /// This test should successfully log a warning message.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [TestMethod]
        public async Task LogWarningMessageShouldSucceed()
        {
            // Arrange
            var objUt = new ApplicationLogger(this.mockILogger.Object);

            // Act
            await objUt.Log(LogType.Warning, this.message);

            // Assert
            this.mockILogger.Verify(method => method.WarningAsync(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<object>()), Times.Once);
        }

        /// <summary>
        /// This test should successfully log a warning message based on an exception.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [TestMethod]
        public async Task LogWarningExceptionShouldSucceed()
        {
            // Arrange
            var exception = new DevelopmentException();
            var objUt = new ApplicationLogger(this.mockILogger.Object);

            // Act
            await objUt.Log(exception);

            // Assert
            this.mockILogger.Verify(method => method.WarningAsync(It.IsAny<BusinessLayerException>(), It.IsAny<int>(), It.IsAny<object>()), Times.Once);
        }

        /// <summary>
        /// This test should successfully log an error message.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [TestMethod]
        public async Task LogErrorMessageShouldSucceed()
        {
            // Arrange
            var objUt = new ApplicationLogger(this.mockILogger.Object);

            // Act
            await objUt.Log(LogType.Error, this.message);

            // Assert
            this.mockILogger.Verify(method => method.ErrorAsync(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<object>()), Times.Once);
        }

        /// <summary>
        /// This test should successfully log an error message based on an exception.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [TestMethod]
        public async Task LogErrorExceptionShouldSucceed()
        {
            // Arrange
            var exception = new Exception("Some unknown error just happend.");
            var objUt = new ApplicationLogger(this.mockILogger.Object);

            // Act
            try
            {
                // This creates the stack trace.
                throw exception;
            }
            catch (Exception e)
            {
                exception = e; 
            }

            await objUt.Log(exception);

            // Assert
            this.mockILogger.Verify(method => method.ErrorAsync(It.IsAny<Exception>(), It.IsAny<int>(), It.IsAny<object>()), Times.Once);
        }
        #endregion
    }
}