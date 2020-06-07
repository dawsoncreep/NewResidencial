// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserRepositoryTests.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the UserRepositoryTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Authentication.UnitTests.ForDataLayer.Repository
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using GS.Api.DataLayer.Repositories;
    using GS.Api.Types.Exceptions;
    using GS.Api.Types.Models;
    using GS.Api.Types.Models.Persistence;

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
            this.userTestData = JsonConvert.DeserializeObject<List<SUser>>("[{\"Id\":1,\"Nombres\":\"Guizzy\",\"Apellidos\":\"Seguridad\",\"Correo\":\"superadmin@guizzyseguridad.com\",\"Telefono\":\"NULL\",\"Celular\":5215560000000,\"Alias\":\"SuperAdmin\",\"Contraseña\":\"Password\",\"Activo\":0},{\"Id\":2,\"Nombres\":\"Jaime\",\"Apellidos\":\"Castorena Tlatecali\",\"Correo\":\"jaime.castorena@psi.condominio.com\",\"Telefono\":\"NULL\",\"Celular\":5214490000000,\"Alias\":\"Jaime.Castorena\",\"Contraseña\":\"Password\",\"Activo\":1},{\"Id\":3,\"Nombres\":\"Carlos\",\"Apellidos\":\"Avalos García\",\"Correo\":\"carlos.avalos@yahoo.com\",\"Telefono\":\"NULL\",\"Celular\":5214770000000,\"Alias\":\"Carlos.Avalos\",\"Contraseña\":\"Password\",\"Activo\":1},{\"Id\":4,\"Nombres\":\"German\",\"Apellidos\":\"Avalos García\",\"Correo\":\"german.avalos@hotmail.com\",\"Telefono\":\"NULL\",\"Celular\":5214780000000,\"Alias\":\"German.Avalos\",\"Contraseña\":\"Password\",\"Activo\":1},{\"Id\":5,\"Nombres\":\"Xavier\",\"Apellidos\":\"Hernández Reyes\",\"Correo\":\"xavier.hernandez@gmail.com\",\"Telefono\":\"NULL\",\"Celular\":5215550000000,\"Alias\":\"Xavier.Hernandez\",\"Contraseña\":\"Password\",\"Activo\":1},{\"Id\":6,\"Nombres\":\"Jose\",\"Apellidos\":\"Sanchez Martínez\",\"Correo\":\"jose.sanchez@hotmail.com\",\"Telefono\":\"NULL\",\"Celular\":5215580000000,\"Alias\":\"Jose.Sanchez\",\"Contraseña\":\"Password\",\"Activo\":1},{\"Id\":7,\"Nombres\":\"Oscar\",\"Apellidos\":\"Hernández Villegas\",\"Correo\":\"oscar.villegas@outlook.com\",\"Telefono\":\"NULL\",\"Celular\":5215510000000,\"Alias\":\"Oscar.Villegas\",\"Contraseña\":\"Password\",\"Activo\":1}]");

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
            const string UserName = "jaime.castorena@psi.condominio.com";
            var expected = new User
            {
                Id = 2,
                Name = "Jaime",
                LastName = "Castorena Tlatecali",
                Email = "jaime.castorena@psi.condominio.com",
                NickName = "Jaime.Castorena",
                Password = "Password"
            };
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