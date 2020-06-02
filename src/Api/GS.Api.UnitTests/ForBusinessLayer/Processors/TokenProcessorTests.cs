// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TokenProcessorTests.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the TokenProcessorTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Authentication.UnitTests.ForBusinessLayer.Processors
{
    using System.Threading.Tasks;

    using Authentication.TestingTools;

    using GS.Api.BusinessLayer.Processors;
    using GS.Api.OperationalManagement.Interfaces;
    using GS.Api.Types.Exceptions;
    using GS.Api.Types.Models;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    /// <summary>
    /// The token processor tests.
    /// </summary>
    [TestClass]
    [TestCategory("Unit Tests")]
    public class TokenProcessorTests
    {
        #region Fields

        /// <summary>
        /// The configuration file secret key.
        /// </summary>
        private const string SecretKey = "JWT_SECRET_KEY";

        /// <summary>
        /// The configuration file audience key.
        /// </summary>
        private const string AudienceKey = "JWT_AUDIENCE_TOKEN";

        /// <summary>
        /// The configuration file issuer key.
        /// </summary>
        private const string IssuerKey = "JWT_ISSUER_TOKEN";

        /// <summary>
        /// The configuration file expire time key.
        /// </summary>
        private const string ExpireKey = "JWT_EXPIRE_MINUTES";

        /// <summary>
        /// <see cref="IDataManager"/> mock object.
        /// </summary>
        private Mock<IDataManager> mockIDataManager;

        /// <summary>
        /// The token processor under test.
        /// </summary>
        private TokenProcessor tokenProcessor;
        #endregion

         #region Tests Life Cycle
        /// <summary>
        /// This method is used to configure the environment before each test.
        /// </summary>
        [TestInitialize]
        public void RunBeforeEachTest()
        {
            this.tokenProcessor = null;

            // Mock objects
            this.mockIDataManager = new Mock<IDataManager>();
        }

        /// <summary>
        /// This method is used to clean the environment after each test.
        /// </summary>
        [TestCleanup]
        public void RunAfterEachTest()
        {
            this.tokenProcessor = null;

            // Mock objects
            this.mockIDataManager = null;
        }
        #endregion

        #region Test Methods

        /// <summary>
        /// This method should successfully generate a JWT.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [TestMethod]
        public async Task GenerateTokenShouldSucceed()
        {
            // Arrange
            var user = new User { Id = 1, UserName = "email@contoso.com", Password = "S3cr3tP455w0rd" };

            this.mockIDataManager.Setup(method => method.GetSettingsValue(SecretKey)).Returns(TestingTokenTool.SecretKey);
            this.mockIDataManager.Setup(method => method.GetSettingsValue(AudienceKey)).Returns(TestingTokenTool.AudienceKey);
            this.mockIDataManager.Setup(method => method.GetSettingsValue(IssuerKey)).Returns(TestingTokenTool.IssuerKey);
            this.mockIDataManager.Setup(method => method.GetSettingsValue(ExpireKey)).Returns(TestingTokenTool.ExpireTimeKey);

            this.tokenProcessor = new TokenProcessor(this.mockIDataManager.Object);

            // Act
            var token = await this.tokenProcessor.GenerateToken(user);

            // Assert
            this.mockIDataManager.Verify(method => method.GetSettingsValue(It.IsAny<string>()), Times.Exactly(4));
            Assert.IsTrue(TestingTokenTool.IsTokenValid(token));
        }

        /// <summary>
        /// This method should fail generating a JWT when necessary data is not present.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [TestMethod]
        [ExpectedException(typeof(TokenGenerationException))]
        public async Task GenerateTokenShouldFail()
        {
            // Arrange
            var user = new User { Id = 1, UserName = "email@contoso.com", Password = "S3cr3tP455w0rd" };
            this.mockIDataManager.Setup(method => method.GetSettingsValue(SecretKey)).Returns(TestingTokenTool.SecretKey);
            this.mockIDataManager.Setup(method => method.GetSettingsValue(AudienceKey)).Returns(TestingTokenTool.AudienceKey);
            this.mockIDataManager.Setup(method => method.GetSettingsValue(IssuerKey)).Throws(new TokenGenerationException());
            this.mockIDataManager.Setup(method => method.GetSettingsValue(ExpireKey)).Returns(TestingTokenTool.ExpireTimeKey);

            this.tokenProcessor = new TokenProcessor(this.mockIDataManager.Object);

            // Act
            await this.tokenProcessor.GenerateToken(user);

            // Assert
            // Assert.Fail("No exception was thrown");
        }
        #endregion
    }
}