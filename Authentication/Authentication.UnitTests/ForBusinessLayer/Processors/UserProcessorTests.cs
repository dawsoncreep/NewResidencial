﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserProcessorTests.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the UserProcessorTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Authentication.UnitTests.ForBusinessLayer.Processors
{
    using System;
    using System.Threading.Tasks;

    using Authentication.BusinessLayer.Processors;
    using Authentication.DataLayer.Interfaces;
    using Authentication.Types.Exceptions;
    using Authentication.Types.Models;

    using KellermanSoftware.CompareNetObjects;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    /// <summary>
    /// The user processor tests.
    /// </summary>
    [TestClass]
    [TestCategory("Unit Tests")]
    public class UserProcessorTests
    {
        #region Fields

        /// <summary>
        /// Compare logic.
        /// </summary>
        private CompareLogic compareLogic;

        /// <summary>
        /// <see cref="IUserRepository"/> mock object.
        /// </summary>
        private Mock<IUserRepository> mockIUserRepository;
        #endregion

        #region Tests Life Cycle
        /// <summary>
        /// This method is used to configure the environment before each test.
        /// </summary>
        [TestInitialize]
        public void RunBeforeEachTest()
        {
            this.compareLogic = new CompareLogic();

            // Mock objects
            this.mockIUserRepository = new Mock<IUserRepository>();
        }

        /// <summary>
        /// This method is used to clean the environment after each test.
        /// </summary>
        [TestCleanup]
        public void RunAfterEachTest()
        {
            this.compareLogic = null;

            // Mock objects
            this.mockIUserRepository = null;
        }
        #endregion

        #region Test Methods

        /// <summary>
        /// This tests should successfully retrieve user information given the username key.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [TestMethod]
        public async Task GetUserByUserNameShouldSucceed()
        {
            // Arrange
            const string UserName = "GoodUserName";
            var expected = new User
            {
                Id = 1,
                UserName = "GoodUserName"
            };

            this.mockIUserRepository.Setup(method => method.FindByUserName(UserName)).ReturnsAsync(expected);

            var objectUt = new UserProcessor(this.mockIUserRepository.Object);

            // Act
            var actual = await objectUt.GetUserByUserName(UserName);
            var result = this.compareLogic.Compare(expected, actual);

            // Assert
            this.mockIUserRepository.Verify(method => method.FindByUserName(It.IsAny<string>()), Times.Once);
            Assert.IsTrue(result.AreEqual);
        }

        /// <summary>
        /// This tests should throw <see cref="InvalidUserAccessException"/> when user is not found.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [TestMethod]
        [ExpectedException(typeof(InvalidUserAccessException))]
        public async Task GetUserByUserNameShouldFailWhenUserIsNotFound()
        {
            // Arrange
            const string UserName = "BadUserName";

            this.mockIUserRepository.Setup(method => method.FindByUserName(UserName)).Throws(new InvalidUserAccessException());

            var objectUt = new UserProcessor(this.mockIUserRepository.Object);

            // Act
            try
            {
                await objectUt.GetUserByUserName(UserName);
            }
            catch (Exception)
            {
                // Assert
                this.mockIUserRepository.Verify(method => method.FindByUserName(It.IsAny<string>()), Times.Once);
                throw;
            }

            // Assert
            // Assert.Fail("No exception were thrown.");
        }
        #endregion
    }
}