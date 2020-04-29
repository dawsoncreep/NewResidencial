// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserFacadeTests.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the UserFacadeTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Authentication.UnitTests.ForBusinessLayer.Facades
{
    using System;
    using System.Threading.Tasks;

    using Authentication.BusinessLayer.Facade;
    using Authentication.BusinessLayer.Interfaces.Processor;
    using Authentication.TestingTools;
    using Authentication.Types.Exceptions;
    using Authentication.Types.Models;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    /// <summary>
    /// The user facade tests.
    /// </summary>
    [TestClass]
    [TestCategory("Unit Tests")]
    public class UserFacadeTests
    {
        #region Fields

        /// <summary>
        /// The JWT secret key.
        /// </summary>
        private const string SecretKey = "0d549739-4532-42cf-b3ce-0077008241fe";

        /// <summary>
        /// The JWT issuer.
        /// </summary>
        private const string IssuerKey = "3bd96eff-9a3e-40fc-97df-92484b51fa89";

        /// <summary>
        /// The audience key.
        /// </summary>
        private const string AudienceKey = "eafdac93-3432-406c-89ef-eb8ce63b9daa";

        /// <summary>
        /// Sample of a valid JWT.
        /// </summary>
        private string validToken;

        /// <summary>
        /// The login request.
        /// </summary>
        private LoginRequest loginRequest;

        /// <summary>
        /// The user under test.
        /// For these unit testing the information about <see cref="User"/> does not care.
        /// </summary>
        private User userUnderTest;

        /// <summary>
        /// The facade under test.
        /// </summary>
        private UserFacade facadeUnderTest;

        /// <summary>
        /// <see cref="IUserProcessor"/> mock object.
        /// </summary>
        private Mock<IUserProcessor> mockIUserProcessor;

        /// <summary>
        /// <see cref="ITokenProcessor"/> mock object.
        /// </summary>
        private Mock<ITokenProcessor> mockITokenProcessor;
        #endregion

        #region Tests Life Cycle

        /// <summary>
        /// This method is used to configure the environment before each test.
        /// </summary>
        [TestInitialize]
        public void RunBeforeEachTest()
        {
            this.loginRequest = new LoginRequest { UserName = "email@contoso.com", Password = "S3cr3tP455w0rd" };
            this.validToken = TestingTokenTool.GenerateToken(this.loginRequest.UserName, SecretKey, IssuerKey, AudienceKey);
            this.userUnderTest = null;

            // Mock objects
            this.mockIUserProcessor = new Mock<IUserProcessor>();
            this.mockITokenProcessor = new Mock<ITokenProcessor>();
        }

        /// <summary>
        /// This method is used to clean the environment after each test.
        /// </summary>
        [TestCleanup]
        public void RunAfterEachTest()
        {
            this.loginRequest = null;
            this.validToken = string.Empty;
            this.userUnderTest = null;

            // Mock objects
            this.mockIUserProcessor = null;
            this.mockITokenProcessor = null;
        }
        #endregion

        #region Test Methods

        /// <summary>
        /// This method should successfully validate <see cref="LoginRequest"/> object.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [TestMethod]
        public async Task AuthenticateShouldValidateUserCredentials()
        {
            // Arrange 
            //  Valid user sample
            this.userUnderTest = new User { Id = 1, UserName = this.loginRequest.UserName, Password = this.loginRequest.Password };
            
            this.mockIUserProcessor.Setup(method => method.GetUserByUserName(this.loginRequest.UserName)).ReturnsAsync(this.userUnderTest);
            this.mockITokenProcessor.Setup(method => method.GenerateToken(this.userUnderTest)).ReturnsAsync(this.validToken);

            this.facadeUnderTest = new UserFacade(this.mockIUserProcessor.Object, this.mockITokenProcessor.Object);

            // Act
            var result = await this.facadeUnderTest.Authenticate(this.loginRequest);

            // Assert
            this.mockIUserProcessor.Verify(method => method.GetUserByUserName(It.IsAny<string>()), Times.Once);
            Assert.IsFalse(string.IsNullOrEmpty(result));
            Assert.IsTrue(TestingTokenTool.IsTokenValid(result, SecretKey, IssuerKey, AudienceKey));
            Assert.AreEqual(this.validToken, result);
        }

        /// <summary>
        /// This method should validate an incorrect user name into <see cref="loginRequest"/> object.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [TestMethod]
        [ExpectedException(typeof(TypeValidationException))]
        public async Task AuthenticateShouldFailValidatingUserName()
        {
            // Arrange 
            this.loginRequest.UserName = "badUserName";
            this.facadeUnderTest = new UserFacade(this.mockIUserProcessor.Object, this.mockITokenProcessor.Object);

            // Act
            await this.facadeUnderTest.Authenticate(this.loginRequest);

            // Assert
            // Assert.Fail("No exception has been thrown.");
        }

        /// <summary>
        /// This method should validate an incorrect password name into <see cref="loginRequest"/> object.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [TestMethod]
        [ExpectedException(typeof(TypeValidationException))]
        public async Task AuthenticateShouldFailValidatingUserPassword()
        {
            // Arrange 
            this.loginRequest.Password = "12345";
            this.facadeUnderTest = new UserFacade(this.mockIUserProcessor.Object, this.mockITokenProcessor.Object);

            // Act
            await this.facadeUnderTest.Authenticate(this.loginRequest);

            // Assert
            // Assert.Fail("No exception has been thrown.");
        }

        /// <summary>
        /// This method should validate an incorrect password name into <see cref="loginRequest"/> object.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [TestMethod]
        [ExpectedException(typeof(InvalidUserAccessException))]
        public async Task AuthenticateShouldFailValidatingUserAccess()
        {
            // Arrange 
            //  Bad user sample
            this.userUnderTest = new User { Id = 1, UserName = this.loginRequest.UserName, Password = "DifferentPassword" };

            this.mockIUserProcessor.Setup(method => method.GetUserByUserName(this.loginRequest.UserName)).ReturnsAsync(this.userUnderTest);
            this.facadeUnderTest = new UserFacade(this.mockIUserProcessor.Object, this.mockITokenProcessor.Object);

            try
            {
                // Act
                await this.facadeUnderTest.Authenticate(this.loginRequest);
            }
            catch (Exception)
            {
                this.mockIUserProcessor.Verify(method => method.GetUserByUserName(It.IsAny<string>()), Times.Once);
                throw;
            }

            // Assert
            // Assert.Fail("No exception has been thrown.");
        }

        /// <summary>
        /// This method should fail when for some reason the system cannot generate a new JWT for the user.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [TestMethod]
        [ExpectedException(typeof(TokenGenerationException))]
        public async Task AuthenticateShouldFailGeneratingToken()
        {
            // Arrange 
            //  Valid user sample
            this.userUnderTest = new User { Id = 1, UserName = this.loginRequest.UserName, Password = this.loginRequest.Password };

            this.mockIUserProcessor.Setup(method => method.GetUserByUserName(this.loginRequest.UserName)).ReturnsAsync(this.userUnderTest);
            this.mockITokenProcessor.Setup(method => method.GenerateToken(It.IsAny<User>())).ThrowsAsync(new TokenGenerationException());

            this.facadeUnderTest = new UserFacade(this.mockIUserProcessor.Object, this.mockITokenProcessor.Object);

            // Act
            try
            {
                await this.facadeUnderTest.Authenticate(this.loginRequest);
            }
            catch (Exception)
            {
                // Assert
                this.mockIUserProcessor.Verify(method => method.GetUserByUserName(It.IsAny<string>()), Times.Once);
                this.mockITokenProcessor.Verify(method => method.GenerateToken(It.IsAny<User>()), Times.Once);
                throw;
            }

            // Assert
            // Assert.Fail("No exception has been thrown.");
        }
        #endregion
    }
}