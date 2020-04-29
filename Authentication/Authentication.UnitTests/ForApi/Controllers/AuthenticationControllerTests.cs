// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AuthenticationControllerTests.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the AuthenticationControllerTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Authentication.UnitTests.ForApi.Controllers
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Web.Http;
    using System.Web.Http.Results;

    using Authentication.Api.Controllers;
    using Authentication.BusinessLayer.Interfaces.Facade;
    using Authentication.OperationalManagement.Interfaces;
    using Authentication.TestingTools;
    using Authentication.Types.Exceptions;
    using Authentication.Types.Models;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    /// <summary>
    /// The authentication controller.
    /// </summary>
    [TestClass]
    [TestCategory("Unit Tests")]
    public class AuthenticationControllerTests
    {
        #region Fields

        /// <summary>
        /// The json web token under test.
        /// </summary>
        private string token;

        /// <summary>
        /// <see cref="IUserFacade"/> mock object.
        /// </summary>
        private Mock<IUserFacade> mockIUserFacade;

        /// <summary>
        /// <see cref="IApplicationLogger"/> mock object.
        /// </summary>
        private Mock<IApplicationLogger> mockIApplicationLogger;

        /// <summary>
        /// The login request.
        /// </summary>
        private LoginRequest loginRequest;

        /// <summary>
        /// The authentication controller under test.
        /// </summary>
        private AuthenticationController authenticationController;
        #endregion

        #region Tests Life Cycle

        /// <summary>
        /// This method is used to configure the environment before each test.
        /// </summary>
        [TestInitialize]
        public void RunBeforeEachTest()
        {
            this.token = string.Empty;
            this.authenticationController = null;
            this.loginRequest = new LoginRequest { UserName = "email@contoso.com", Password = "S3cr3tP455w0rd" };

            // Mock objects
            this.mockIUserFacade = new Mock<IUserFacade>();
            this.mockIApplicationLogger = new Mock<IApplicationLogger>();
        }

        /// <summary>
        /// This method is used to clean the environment after each test.
        /// </summary>
        [TestCleanup]
        public void RunAfterEachTest()
        {
            this.token = string.Empty;
            this.authenticationController = null;
            this.loginRequest = null;

            // Mock objects
            this.mockIUserFacade = null;
            this.mockIApplicationLogger = null;
        }
        #endregion

        #region Test Methods

        /// <summary>
        ///  This method should:
        ///    1) Simulate an HTTP POST request and send a <see cref="LoginRequest"/> object to '~/Authentication/Authenticate'
        ///    2) Pre-validate the <see cref="LoginRequest"/> object.
        ///    3) Successfully verify if user is stored in database.
        ///    4) Get user's roles
        ///    5) Return a valid JWT.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [TestMethod]
        public async Task AuthenticateShouldSucceed()
        {
            // Arrange
            var expectedToken = TestingTokenTool.GenerateToken(this.loginRequest.UserName, TestingTokenTool.SecretKey, TestingTokenTool.IssuerKey, TestingTokenTool.AudienceKey);
            this.mockIUserFacade.Setup(method => method.Authenticate(this.loginRequest)).ReturnsAsync(expectedToken);
            this.authenticationController = new AuthenticationController(this.mockIApplicationLogger.Object, this.mockIUserFacade.Object)
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            // Act
            var response = await this.authenticationController.Authenticate(this.loginRequest);
            if (response is OkNegotiatedContentResult<string> responseData)
            {
                this.token = responseData.Content;
            }

            // Assert
            this.mockIUserFacade.Verify(method => method.Authenticate(It.IsNotNull<LoginRequest>()), Times.AtLeastOnce);
            this.mockIUserFacade.Verify(method => method.Authenticate(It.IsAny<LoginRequest>()), Times.Once);
            Assert.IsNotNull(response);
            Assert.IsTrue(TestingTokenTool.IsTokenValid(this.token));
        }

        /// <summary>
        /// This method should simulate an error when the user has entered wrong userName.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [TestMethod]
        public async Task AuthenticateShouldFailPreValidatingUserName()
        {
            // Arrange
            var expectedMessage = new TypeValidationException().Message;
            var actualMessage = string.Empty;
            this.loginRequest.UserName = "badUserName";

            this.mockIUserFacade.Setup(method => method.Authenticate(this.loginRequest)).ThrowsAsync(new TypeValidationException());
            this.authenticationController = new AuthenticationController(this.mockIApplicationLogger.Object, this.mockIUserFacade.Object)
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            // Act
            var response = await this.authenticationController.Authenticate(this.loginRequest);
            if (response is BadRequestErrorMessageResult responseData)
            {
                actualMessage = responseData.Message;
            }

            // Assert
            this.mockIUserFacade.Verify(method => method.Authenticate(It.IsNotNull<LoginRequest>()), Times.AtLeastOnce);
            this.mockIApplicationLogger.Verify(method => method.Log(It.IsAny<Exception>(), It.IsAny<object>()), Times.Once);
            Assert.IsNotNull(response);
            Assert.IsInstanceOfType(response, typeof(BadRequestErrorMessageResult));
            Assert.AreEqual(expectedMessage, actualMessage);
        }

        /// <summary>
        /// This method should simulate an error when the user has entered wrong password.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [TestMethod]
        public async Task AuthenticateShouldFailPreValidatingPassword()
        {
            // Arrange
            var expectedMessage = new TypeValidationException().Message;
            var actualMessage = string.Empty;
            this.loginRequest.Password = "12345";

            this.mockIUserFacade.Setup(method => method.Authenticate(this.loginRequest)).ThrowsAsync(new TypeValidationException());
            this.authenticationController = new AuthenticationController(this.mockIApplicationLogger.Object, this.mockIUserFacade.Object)
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            // Act
            var response = await this.authenticationController.Authenticate(this.loginRequest);
            if (response is BadRequestErrorMessageResult responseData)
            {
                actualMessage = responseData.Message;
            }

            // Assert
            this.mockIUserFacade.Verify(method => method.Authenticate(It.IsNotNull<LoginRequest>()), Times.AtLeastOnce);
            this.mockIApplicationLogger.Verify(method => method.Log(It.IsAny<Exception>(), It.IsAny<object>()), Times.Once);
            Assert.IsNotNull(response);
            Assert.IsInstanceOfType(response, typeof(BadRequestErrorMessageResult));
            Assert.AreEqual(expectedMessage, actualMessage);
        }

        /// <summary>
        /// This method should simulate invalid user access.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [TestMethod]
        public async Task AuthenticateShouldFailValidatingAccess()
        {
            // Arrange
            var expectedMessage = new InvalidUserAccessException().Message;
            var actualMessage = string.Empty;

            this.mockIUserFacade.Setup(method => method.Authenticate(this.loginRequest)).ThrowsAsync(new InvalidUserAccessException());
            this.authenticationController = new AuthenticationController(this.mockIApplicationLogger.Object, this.mockIUserFacade.Object)
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            // Act
            var response = await this.authenticationController.Authenticate(this.loginRequest);
            if (response is BadRequestErrorMessageResult responseData)
            {
                actualMessage = responseData.Message;
            }

            // Assert
            this.mockIUserFacade.Verify(method => method.Authenticate(It.IsNotNull<LoginRequest>()), Times.AtLeastOnce);
            this.mockIApplicationLogger.Verify(method => method.Log(It.IsAny<Exception>(), It.IsAny<object>()), Times.Once);
            Assert.IsNotNull(response);
            Assert.IsInstanceOfType(response, typeof(BadRequestErrorMessageResult));
            Assert.AreEqual(expectedMessage, actualMessage);
        }

        /// <summary>
        /// This method should simulate invalid token generation error.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [TestMethod]
        public async Task AuthenticateShouldFailGenerationJwT()
        {
            // Arrange
            var expectedMessage = new TokenGenerationException().Message;
            var actualMessage = string.Empty;

            this.mockIUserFacade.Setup(method => method.Authenticate(this.loginRequest)).ThrowsAsync(new TokenGenerationException());
            this.authenticationController = new AuthenticationController(this.mockIApplicationLogger.Object, this.mockIUserFacade.Object)
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            // Act
            var response = await this.authenticationController.Authenticate(this.loginRequest);
            if (response is BadRequestErrorMessageResult responseData)
            {
                actualMessage = responseData.Message;
            }

            // Assert
            this.mockIUserFacade.Verify(method => method.Authenticate(It.IsNotNull<LoginRequest>()), Times.AtLeastOnce);
            this.mockIApplicationLogger.Verify(method => method.Log(It.IsAny<Exception>(), It.IsAny<object>()), Times.Once);
            Assert.IsNotNull(response);
            Assert.IsInstanceOfType(response, typeof(BadRequestErrorMessageResult));
            Assert.AreEqual(expectedMessage, actualMessage);
        }

        /// <summary>
        /// This method should simulate an unknown and unexpected error.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [TestMethod]
        public async Task AuthenticateShouldFailUnexpectedly()
        {
            // Arrange
            this.mockIUserFacade.Setup(method => method.Authenticate(this.loginRequest)).ThrowsAsync(new Exception());
            this.authenticationController = new AuthenticationController(this.mockIApplicationLogger.Object, this.mockIUserFacade.Object)
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            // Act
            var response = await this.authenticationController.Authenticate(this.loginRequest);
            var responseData = response as ExceptionResult;

            // Assert
            this.mockIUserFacade.Verify(method => method.Authenticate(It.IsNotNull<LoginRequest>()), Times.AtLeastOnce);
            this.mockIApplicationLogger.Verify(method => method.Log(It.IsAny<Exception>(), It.IsAny<object>()), Times.Once);
            Assert.IsNotNull(response);
            Assert.IsInstanceOfType(response, typeof(ExceptionResult));
            Assert.IsNotNull(responseData);
            Assert.IsInstanceOfType(responseData.Exception, typeof(Exception));
        }
        #endregion
    }
}