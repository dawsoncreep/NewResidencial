// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SessionProcessorTests.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the SessionProcessorTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GS.Mobile.UnitTests.ForProcessors
{
    using GS.Mobile.BusinessLayer.Interfaces;
    using GS.Mobile.BusinessLayer.Processors;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// The session processor tests.
    /// </summary>
    [TestClass]
    public class SessionProcessorTests
    {
        /// <summary>
        /// The session processor under test.
        /// </summary>
        private ISessionProcessor sessionProcessor;

        #region Tests Life Cycle

        /// <summary>
        /// This method is used to configure the environment before each test.
        /// </summary>
        [TestInitialize]
        public void RunBeforeEachTest()
        {
            this.sessionProcessor = null;
        }

        /// <summary>
        /// This method is used to clean the environment after each test.
        /// </summary>
        [TestCleanup]
        public void RunAfterEachTest()
        {
            this.sessionProcessor = null;
        }
        #endregion

        /// <summary>
        /// This tests should return true when a valid token is found.
        /// No roles are implied.
        /// </summary>
        [TestMethod]
        public void ValidateCurrentSessionShouldSucceedNoRoles()
        {
            // Arrange
            this.sessionProcessor = new SessionProcessor();

            // Act
            var actual = this.sessionProcessor.ValidateCurrentSession(string.Empty);

            // Assert
            Assert.IsTrue(actual);
        }

        /// <summary>
        /// This tests should return true when an invalid token or no token is found.
        /// No roles are implied.
        /// </summary>
        [TestMethod]
        public void ValidateCurrentSessionShouldFailNoRoles()
        {
            // Arrange
            this.sessionProcessor = new SessionProcessor();

            // Act
            var actual = this.sessionProcessor.ValidateCurrentSession(string.Empty);

            // Assert
            Assert.IsFalse(actual);
        }
    }
}