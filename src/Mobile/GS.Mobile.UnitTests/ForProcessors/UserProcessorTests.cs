// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserProcessorTests.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the UserProcessorTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GS.Mobile.UnitTests.ForProcessors
{
    using System;
    using System.Threading.Tasks;

    using GS.Mobile.BusinessLayer.Interfaces;
    using GS.Mobile.BusinessLayer.Processors;
    using GS.Mobile.DataLayer.Services.Authentication;
    using GS.Mobile.Types.Exceptions;
    using GS.Mobile.Types.Security;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    /// <summary>
    /// The user processor tests.
    /// </summary>
    [TestClass]
    public class UserProcessorTests
    {
        /// <summary>
        /// The processor under test.
        /// </summary>
        private IUserProcessor processorUt;

        /// <summary>
        /// <see cref="IAuthenticationService"/> mock object.
        /// </summary>
        private Mock<IAuthenticationService> mockIAuthenticationService;

        #region Tests Life Cycle

        /// <summary>
        /// This method is used to configure the environment before each test.
        /// </summary>
        [TestInitialize]
        public void RunBeforeEachTest()
        {
            this.processorUt = null;

            // Mock definition
            this.mockIAuthenticationService = new Mock<IAuthenticationService>();
        }

        /// <summary>
        /// This method is used to clean the environment after each test.
        /// </summary>
        [TestCleanup]
        public void RunAfterEachTest()
        {
            this.processorUt = null;

            // Mock cleanup
            this.mockIAuthenticationService = null;
        }

        #endregion

        /// <summary>
        /// This test should successfully login a user into system.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [TestMethod]
        public async Task LoginShouldSucceed()
        {
            // Arrange
            const string UserName = "jaime.castorena@psi.condominio.com";
            const string Password = "Password";
            const string Token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJwcmltYXJ5c2lkIjoiMiIsInVuaXF1ZV9uYW1lIjoiSmFpbWUiLCJlbWFpbCI6ImphaW1lLmNhc3RvcmVuYUBwc2kuY29uZG9taW5pby5jb20iLCJyb2xlIjoiQWRtaW5pc3RyYWRvciIsIm5iZiI6MTU5MTkwNzAwMywiZXhwIjoxNTkxOTE0MjAzLCJpYXQiOjE1OTE5MDcwMDMsImlzcyI6Ijk1Nzg4MGJlLTdkNmQtNGY4YS1hMzQ1LTdiOWViNzc4ZDVkZCIsImF1ZCI6IjNjMTYyNTVlLTJiYmQtNGE0OC04MjJmLWNmYThmZWEzMWNkOSJ9.IZhNOZ00DtyjuXifXPyeU6D2xnt0SXzcM-g_TP2OnwY";

            this.mockIAuthenticationService.Setup(method => method.Login(It.IsAny<LoginRequest>())).ReturnsAsync(Token);
            this.processorUt = new UserProcessor(this.mockIAuthenticationService.Object);

            // Act
            var actual = await this.processorUt.Login(UserName, Password);

            // Assert
            this.mockIAuthenticationService.Verify(method => method.Login(It.IsAny<LoginRequest>()), Times.Once);
            Assert.AreEqual(Token, actual);
        }

        /// <summary>
        /// This tests should thrown a <see cref="ServiceCallException"/> when connection to services fails.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [TestMethod]
        [ExpectedException(typeof(ServiceCallException))]
        public async Task LoginShouldFail()
        {
            // Arrange
            const string UserName = "jaime.castorena@psi.condominio.com";
            const string Password = "Password";

            this.mockIAuthenticationService.Setup(method => method.Login(It.IsAny<LoginRequest>())).ThrowsAsync(new Exception("Network Exception."));
            this.processorUt = new UserProcessor(this.mockIAuthenticationService.Object);

            try
            {
                // Act
                await this.processorUt.Login(UserName, Password);
            }
            catch (Exception)
            {
                // Assert
                this.mockIAuthenticationService.Verify(method => method.Login(It.IsAny<LoginRequest>()), Times.Once);
                throw;
            }
        }
    }
}