// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserProcessorTests.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the UserProcessorTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GuizzySeguridad.Common.UnitTests.Common.Server.ForBusinessLayer.Processors
{
    using System;
    using System.Threading.Tasks;

    using GuizzySeguridad.Common.Server.BusinessLayer.Processors;
    using GuizzySeguridad.Common.Server.Interfaces.Repository;
    using GuizzySeguridad.Common.Types.Exceptions;
    using GuizzySeguridad.Common.Types.Models;

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

        /// <summary>
        /// <see cref="IRolRepository"/> mock object.
        /// </summary>
        private Mock<IRolRepository> mockIRolRepository;
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
            this.mockIRolRepository = new Mock<IRolRepository>();
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
            this.mockIRolRepository = null;
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
            const int UserId = 1;

            var expected = new User
            {
                Id = 1,
                UserName = "GoodUserName",
                Password = "GoodPassword",
                Authorizations = new[] { new Authorization { Role = "Administrador", Permission = new[] { "MODULO 1", "MENU 1", "MENU 2", "MENU 3" } } },
            };

            this.mockIUserRepository.Setup(method => method.FindByUserName(UserName)).ReturnsAsync(expected);
            this.mockIRolRepository.Setup(method => method.GetAuthorizationData(UserId)).ReturnsAsync(expected.Authorizations);

            var objectUt = new UserProcessor(this.mockIUserRepository.Object, this.mockIRolRepository.Object);

            // Act
            var actual = await objectUt.GetUserByUserName(UserName);
            var result = this.compareLogic.Compare(expected, actual);

            // Assert
            this.mockIUserRepository.Verify(method => method.FindByUserName(It.IsAny<string>()), Times.Once);
            this.mockIRolRepository.Verify(method => method.GetAuthorizationData(It.IsAny<int>()), Times.Once);
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

            var objectUt = new UserProcessor(this.mockIUserRepository.Object, this.mockIRolRepository.Object);

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

        /// <summary>
        /// This test should thrown <see cref="InvalidUserRolException"/> when some role/permission data is not valid or empty.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [TestMethod]
        [ExpectedException(typeof(InvalidUserRolException))]
        public async Task GetUserByUserNameShouldFailWhenRoleInformationIsWrong()
        {
            // Arrange
            const string UserName = "GoodUserName";
            const int UserId = 1;
            var expected = new User
            {
                Id = 1,
                UserName = "GoodUserName",
                Password = "GoodPassword",
            };

            this.mockIUserRepository.Setup(method => method.FindByUserName(UserName)).ReturnsAsync(expected);
            this.mockIRolRepository.Setup(method => method.GetAuthorizationData(UserId)).Throws(new InvalidUserRolException());

            var objectUt = new UserProcessor(this.mockIUserRepository.Object, this.mockIRolRepository.Object);

            // Act
            try
            {
                await objectUt.GetUserByUserName(UserName);
            }
            catch (Exception)
            {
                // Assert
                this.mockIUserRepository.Verify(method => method.FindByUserName(It.IsAny<string>()), Times.Once);
                this.mockIRolRepository.Verify(method => method.GetAuthorizationData(It.IsAny<int>()), Times.Once);
                throw;
            }

            // Assert
            // Assert.Fail("No exception were thrown.");
        }
        #endregion
    }
}