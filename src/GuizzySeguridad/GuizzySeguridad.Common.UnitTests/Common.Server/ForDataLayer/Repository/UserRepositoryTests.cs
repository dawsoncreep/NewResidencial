// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserRepositoryTests.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the UserRepositoryTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GuizzySeguridad.Common.UnitTests.Common.Server.ForDataLayer.Repository
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using GuizzySeguridad.Common.Server.DataLayer.Repositories;
    using GuizzySeguridad.Common.Types.Exceptions;
    using GuizzySeguridad.Common.Types.Models;
    using GuizzySeguridad.Common.Types.Models.Persistence;

    using KellermanSoftware.CompareNetObjects;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Newtonsoft.Json;

    /// <summary>
    /// The user repository tests.
    /// </summary>
    [TestClass]
    [TestCategory("Unit Tests")]
    public class UserRepositoryTests
    {
        #region Fields

        /// <summary>
        /// The test data.
        /// </summary>
        private List<SUser> userTestData;

        /// <summary>
        /// The compare logic.
        /// </summary>
        private CompareLogic compareLogic;

        /// <summary>
        /// The application context.
        /// </summary>
        private ApplicationContext applicationContext;
        #endregion

        #region Tests Life Cycle
        /// <summary>
        /// This method is used to configure the environment before each test.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [TestInitialize]
        public async Task RunBeforeEachTest()
        {
            this.userTestData = JsonConvert.DeserializeObject<List<SUser>>("[{\"idUsuario\":\"1\",\"nombre\":\"Carlos\",\"apellido\":\"Fernandez\",\"correo\":\"carlos.fernandez@contoso.com\",\"celular\":\"5500000001\",\"usuario\":\"usuario01\",\"contraseña\":\"S5cr3tP455w0rd1\",\"activo\":\"true\"},{\"idUsuario\":\"2\",\"nombre\":\"Susana\",\"apellido\":\"Distancia\",\"correo\":\"susana.distancia@contoso.com\",\"celular\":\"5500000002\",\"usuario\":\"usuario02\",\"contraseña\":\"S5cr3tP455w0rd2\",\"activo\":\"false\"},{\"idUsuario\":\"3\",\"nombre\":\"Xavier\",\"apellido\":\"Hernandez\",\"correo\":\"xavier.hernandez@contoso.com\",\"celular\":\"5500000003\",\"usuario\":\"usuario03\",\"contraseña\":\"S5cr3tP455w0rd3\",\"activo\":\"true\"}]");

            this.compareLogic = new CompareLogic();

            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase("UserUnitTestingDataBase")
                .Options;
            this.applicationContext = new ApplicationContext(options);

            await this.PopulateDatabase();
        }

        /// <summary>
        /// This method is used to clean the environment after each test.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [TestCleanup]
        public async Task RunAfterEachTest()
        {
            this.userTestData = null;
            this.compareLogic = null;

            await this.BanishDataBase();
            this.applicationContext.Dispose();
            this.applicationContext = null;
        }
        #endregion

        #region Test Methods

        /// <summary>
        /// This method should successfully get an active user from data base.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [TestMethod]
        public async Task FindByUserNameShouldSucceed()
        {
            // Arrange
            const string UserName = "xavier.hernandez@contoso.com";
            var expected = new User { Id = 3, UserName = "xavier.hernandez@contoso.com", Password = "S5cr3tP455w0rd3" };
            var objectUt = new UserRepository(this.applicationContext);

            // Act
            var actual = await objectUt.FindByUserName(UserName);
            var result = this.compareLogic.Compare(expected, actual);

            // Assert
            Assert.IsTrue(result.AreEqual);
        }

        /// <summary>
        /// This method should fail getting an active user from data base.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [TestMethod]
        [ExpectedException(typeof(InvalidUserAccessException))]
        public async Task FindByUserNameShouldFailGettingActiveUser()
        {
            // Arrange
            const string UserName = "susana.distancia@contoso.com";
            var objectUt = new UserRepository(this.applicationContext);

            // Act
            await objectUt.FindByUserName(UserName);

            // Assert
            // Assert.Fail("No exception was thrown.");
        }

        /// <summary>
        /// This method should fail trying finding nonexistent user from data base.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [TestMethod]
        [ExpectedException(typeof(InvalidUserAccessException))]
        public async Task FindByUserNameShouldFailFindingUser()
        {
            // Arrange
            const string UserName = "unknownUser@contoso.com";
            var objectUt = new UserRepository(this.applicationContext);

            // Act
            await objectUt.FindByUserName(UserName);

            // Assert
            // Assert.Fail("No exception was thrown.");
        }
        #endregion

        #region Private Methods

        /// <summary>
        /// Populates database with testing data.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        private async Task PopulateDatabase()
        {
            await this.applicationContext.User.AddRangeAsync(this.userTestData);
            await this.applicationContext.SaveChangesAsync();
        }

        /// <summary>
        /// The banish data base.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        private async Task BanishDataBase()
        {
            var data = await this.applicationContext.User.ToListAsync();
            this.applicationContext.RemoveRange(data);
            await this.applicationContext.SaveChangesAsync();
        }
        #endregion
    }
}