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
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web.Http.Results;

    using Authentication.Api.Controllers;
    using Authentication.Api.IoC;
    using Authentication.DataLayer.Repositories;
    using Authentication.OperationalManagement.Interfaces;
    using Authentication.TestingTools;
    using Authentication.Types.Models;
    using Authentication.Types.Models.Persistence;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Newtonsoft.Json;

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
            this.PopulateDatabase();
        }

        /// <summary>
        /// This method is used to clean the environment after each test.
        /// </summary>
        [TestCleanup]
        public void RunAfterEachTest()
        {
            // Data cleanup
            this.CleanupDatabase();

            // Object cleanup
            this.loginRequest = null;
            this.dependencyResolver.Dispose();
            this.dependencyResolver = null;
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
            var token = string.Empty;
            this.loginRequest = new LoginRequest { UserName = "xavier.hernandez@contoso.com", Password = "S5cr3tP455w0rd3" };
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
            Assert.IsTrue(TestingTokenTool.IsTokenValid(token, TestingTokenTool.SecretKey, TestingTokenTool.IssuerKey, TestingTokenTool.AudienceKey));
        }
        #endregion

        #region Private Methods

        /// <summary>
        /// Populates database with some random data.
        /// </summary>
        private void PopulateDatabase()
        {
            var testData = JsonConvert.DeserializeObject<List<SUser>>("[{\"idUsuario\":\"0\",\"nombre\":\"Carlos\",\"apellido\":\"Fernandez\",\"correo\":\"carlos.fernandez@contoso.com\",\"celular\":\"5500000001\",\"usuario\":\"usuario01\",\"contraseña\":\"S5cr3tP455w0rd1\",\"activo\":\"true\"},{\"idUsuario\":\"0\",\"nombre\":\"Susana\",\"apellido\":\"Distancia\",\"correo\":\"susana.distancia@contoso.com\",\"celular\":\"5500000002\",\"usuario\":\"usuario02\",\"contraseña\":\"S5cr3tP455w0rd2\",\"activo\":\"false\"},{\"idUsuario\":\"0\",\"nombre\":\"Xavier\",\"apellido\":\"Hernandez\",\"correo\":\"xavier.hernandez@contoso.com\",\"celular\":\"5500000003\",\"usuario\":\"usuario03\",\"contraseña\":\"S5cr3tP455w0rd3\",\"activo\":\"true\"}]");

            using (var context = new ApplicationContext(this.dependencyResolver.Resolve<IDataManager>()))
            {
                context.User.AddRange(testData);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Cleans the database up.
        /// </summary>
        private void CleanupDatabase()
        {
            using (var context = new ApplicationContext(this.dependencyResolver.Resolve<IDataManager>()))
            {
                var data = context.User.ToList();
                context.User.RemoveRange(data);
                context.SaveChanges();
            }
        }

        #endregion
    }
}