// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AuthenticationServiceTests.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the AuthenticationServiceTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GS.Mobile.UnitTests.ForServices
{
    using System;
    using System.Threading.Tasks;

    using GS.Mobile.DataLayer.Services;
    using GS.Mobile.DataLayer.Services.Authentication;
    using GS.Mobile.Types.Exceptions;
    using GS.Mobile.Types.Network;
    using GS.Mobile.Types.Security;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    /// <summary>
    /// The authentication service tests.
    /// </summary>
    [TestClass]
    public class AuthenticationServiceTests
    {
        /// <summary>
        /// The authentication service under test.
        /// </summary>
        private IAuthenticationService authenticationService;

        /// <summary>
        /// <see cref="IServiceManager"/> mock object.
        /// </summary>
        private Mock<IServiceManager> mockIServiceManager;

        #region Tests Life Cycle

        /// <summary>
        /// This method is used to configure the environment before each test.
        /// </summary>
        [TestInitialize]
        public void RunBeforeEachTest()
        {
            this.authenticationService = null;

            // Mock definition
            this.mockIServiceManager = new Mock<IServiceManager>();
        }

        /// <summary>
        /// This method is used to clean the environment after each test.
        /// </summary>
        [TestCleanup]
        public void RunAfterEachTest()
        {
            this.authenticationService = null;

            // Mock cleanup
            this.mockIServiceManager = null;
        }
        #endregion

        /// <summary>
        /// This tests should simulate a call to service '/api/Authentication/Login'
        /// and retrieve a valid JWT from the HTTP response.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [TestMethod]
        public async Task LoginShouldSucceed()
        {
            // Arrange
            const string Url = "http://localhost:64406/api/Authentication/Login";
            var loginRequest = new LoginRequest
            {
                UserName = "jaime.castorena@psi.condominio.com",
                Password = "Password"
            };
            var serviceResult = new ServiceCallResult<string>(200, "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJwcmltYXJ5c2lkIjoiMiIsInVuaXF1ZV9uYW1lIjoiSmFpbWUiLCJlbWFpbCI6ImphaW1lLmNhc3RvcmVuYUBwc2kuY29uZG9taW5pby5jb20iLCJyb2xlIjoiQWRtaW5pc3RyYWRvciIsIm5iZiI6MTU5MTkwNzAwMywiZXhwIjoxNTkxOTE0MjAzLCJpYXQiOjE1OTE5MDcwMDMsImlzcyI6Ijk1Nzg4MGJlLTdkNmQtNGY4YS1hMzQ1LTdiOWViNzc4ZDVkZCIsImF1ZCI6IjNjMTYyNTVlLTJiYmQtNGE0OC04MjJmLWNmYThmZWEzMWNkOSJ9.IZhNOZ00DtyjuXifXPyeU6D2xnt0SXzcM-g_TP2OnwY");

            this.mockIServiceManager.Setup(method => method.ExecutePost<string>(Url, loginRequest)).ReturnsAsync(serviceResult);
            this.authenticationService = new AuthenticationService(this.mockIServiceManager.Object);

            // Act
            var actual = await this.authenticationService.Login(loginRequest);

            // Assert
            this.mockIServiceManager.Verify(method => method.ExecutePost<string>(It.IsAny<string>(), It.IsAny<object>()), Times.Once);
            Assert.AreEqual(serviceResult.Result, actual);
        }

        /// <summary>
        /// This tests should simulate a call to service '/api/Authentication/Login'
        /// and retrieve an error message from HTTP response when user credentials are incorrect.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [TestMethod]
        [ExpectedException(typeof(InvalidUserAccessException))]
        public async Task LoginShouldFailWhenInvalidCredentials()
        {
            // Arrange
            const string Url = "http://localhost:64406/api/Authentication/Login";
            var loginRequest = new LoginRequest
            {
                UserName = "user.invalid@psi.condominio.com",
                Password = "BadPassword"
            };
            var serviceResult = new ServiceCallResult<string>(400, "Nombre de usuario y/o contraseña son incorrectos.");

            this.mockIServiceManager.Setup(method => method.ExecutePost<string>(Url, loginRequest)).ReturnsAsync(serviceResult);
            this.authenticationService = new AuthenticationService(this.mockIServiceManager.Object);

            try
            {
                // Act
                await this.authenticationService.Login(loginRequest);
            }
            catch (Exception)
            {
                // Assert
                this.mockIServiceManager.Verify(method => method.ExecutePost<string>(It.IsAny<string>(), It.IsAny<object>()), Times.Once);
                throw;
            }
        }

        /// <summary>
        /// This tests should simulate a call to service '/api/Authentication/Login'
        /// and retrieve an error message from HTTP response when the server fails.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [TestMethod]
        [ExpectedException(typeof(ServiceCallException))]
        public async Task LoginShouldFailWhenServerException()
        {
            // Arrange
            const string Url = "http://localhost:64406/api/Authentication/Login";
            var loginRequest = new LoginRequest
            {
                UserName = "user.invalid@psi.condominio.com",
                Password = "BadPassword"
            };
            var serviceResult = new ServiceCallResult<string>(500, "Some random exception message");

            this.mockIServiceManager.Setup(method => method.ExecutePost<string>(Url, loginRequest)).ReturnsAsync(serviceResult);
            this.authenticationService = new AuthenticationService(this.mockIServiceManager.Object);

            try
            {
                // Act
                await this.authenticationService.Login(loginRequest);
            }
            catch (Exception)
            {
                // Assert
                this.mockIServiceManager.Verify(method => method.ExecutePost<string>(It.IsAny<string>(), It.IsAny<object>()), Times.Once);
                throw;
            }
        }
    }
}