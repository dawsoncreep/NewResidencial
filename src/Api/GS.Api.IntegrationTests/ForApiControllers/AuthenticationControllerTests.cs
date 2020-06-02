// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AuthenticationControllerTests.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the AuthenticationControllerTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Authentication.IntegrationTests.ForApiControllers
{
    using System.Threading.Tasks;
    using System.Web.Http.Results;

    using Authentication.Api.Controllers;
    using Authentication.Api.IoC;
    using Authentication.TestingTools;

    using GS.Api.OperationalManagement.Interfaces;
    using GS.Api.Types.Models;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// The authentication controller tests.
    /// </summary>
    [TestClass]
    [TestCategory("Integration Tests")]
    public class AuthenticationControllerTests
    {
        #region Fields

        /// <summary>
        /// The dependency resolver.
        /// </summary>
        private IDependencyInjectionResolver dependencyResolver;

        /// <summary>
        /// The login request.
        /// </summary>
        private LoginRequest loginRequest;

        /// <summary>
        /// The authentication controller under test.
        /// </summary>
        private AuthenticationController authenticationController;

        /// <summary>
        /// The data manager.
        /// </summary>
        private IDataManager dataManager;
        #endregion

        #region Tests Life Cycle

        /// <summary>
        /// This method is used to configure the environment before each test.
        /// </summary>
        [TestInitialize]
        public void RunBeforeEachTest()
        {
            // Object initialize
            this.loginRequest = null;
            this.dependencyResolver = new DependencyInjectionResolver();

            // Object manipulation
            this.dependencyResolver.Initialize();

            // Data initialization
            this.dataManager = this.dependencyResolver.Resolve<IDataManager>();
        }

        /// <summary>
        /// This method is used to clean the environment after each test.
        /// </summary>
        [TestCleanup]
        public void RunAfterEachTest()
        {
            // Object cleanup
            this.loginRequest = null;
            this.dependencyResolver.Dispose();
            this.dependencyResolver = null;
            this.dataManager = null;
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
            var secretKey = this.dataManager.GetSettingsValue("JWT_SECRET_KEY");
            var audienceKey = this.dataManager.GetSettingsValue("JWT_AUDIENCE_TOKEN");
            var issuerKey = this.dataManager.GetSettingsValue("JWT_ISSUER_TOKEN");

            var token = string.Empty;
            this.loginRequest = new LoginRequest { UserName = "xavier.hernandez@contoso.com", Password = "S5cr3tP455w0rd" };
            this.authenticationController = this.dependencyResolver.Resolve<AuthenticationController>();

            // Act
            var response = await this.authenticationController.Authenticate(this.loginRequest);
            if (response is OkNegotiatedContentResult<string> responseData)
            {
                token = responseData.Content;
            }

            // Assert
            Assert.IsNotNull(response);
            Assert.IsInstanceOfType(response, typeof(OkNegotiatedContentResult<string>));
            Assert.IsTrue(TestingTokenTool.IsTokenValid(token, secretKey, issuerKey, audienceKey));
        }
        #endregion
    }
}