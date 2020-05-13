// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RoleRepositoryTests.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the RoleRepositoryTests type.
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
    /// The role repository tests.
    /// </summary>
    [TestClass]
    [TestCategory("Unit Tests")]
    public class RoleRepositoryTests
    {
        #region Fields

        /// <summary>
        /// The user test data.
        /// </summary>
        private List<SUser> userTestData;

        /// <summary>
        /// The role test data.
        /// </summary>
        private List<SRol> roleTestData;

        /// <summary>
        /// The permissions test data.
        /// </summary>
        private List<SPermission> permissionsTestData;

        /// <summary>
        /// The user role test data.
        /// </summary>
        private List<SUserRole> userRolTestData;

        /// <summary>
        /// The role permissions test data.
        /// </summary>
        private List<SRolePermission> rolPermissionsTestData;

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
            this.roleTestData = JsonConvert.DeserializeObject<List<SRol>>("[{\"IdRol\":\"1\",\"Nombre\":\"Administrador\",\"Activo\":\"True\"},{\"IdRol\":\"2\",\"Nombre\":\"Condomino\",\"Activo\":\"True\"},{\"IdRol\":\"3\",\"Nombre\":\"Visitante\",\"Activo\":\"True\"},{\"IdRol\":\"4\",\"Nombre\":\"Proveedor\",\"Activo\":\"False\"}]");
            this.permissionsTestData = JsonConvert.DeserializeObject<List<SPermission>>("[{\"IdPermiso\":\"1\",\"Nombre\":\"MENU 1\",\"Activo\":\"True\"},{\"IdPermiso\":\"2\",\"Nombre\":\"MENU 2\",\"Activo\":\"False\"},{\"IdPermiso\":\"3\",\"Nombre\":\"MENU 3\",\"Activo\":\"True\"}]");
            this.userRolTestData = JsonConvert.DeserializeObject<List<SUserRole>>("[{\"IdUsuario\":\"1\",\"IdRol\":\"1\",\"Activo\":\"True\"}]");
            this.rolPermissionsTestData = JsonConvert.DeserializeObject<List<SRolePermission>>("[{\"IdRol\":\"1\",\"IdPermiso\":\"1\",\"Activo\":\"True\"},{\"IdRol\":\"1\",\"IdPermiso\":\"2\",\"Activo\":\"False\"},{\"IdRol\":\"1\",\"IdPermiso\":\"3\",\"Activo\":\"True\"}]");

            this.compareLogic = new CompareLogic();

            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase("RolUnitTestingDataBase")
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
            this.roleTestData = null;
            this.permissionsTestData = null;
            this.userRolTestData = null;
            this.rolPermissionsTestData = null;

            this.compareLogic = null;

            await this.BanishDataBase();
            this.applicationContext.Dispose();
            this.applicationContext = null;
        }
        #endregion

        #region Test Methods

        /// <summary>
        /// This tests should get user authorization data successfully.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [TestMethod]
        public async Task GetAuthorizationDataShouldSucceed()
        {
            // Arrange
            const int UserId = 1;
            var objectUt = new RoleRepository(this.applicationContext);
            var expected = new[] { new Authorization { Role = "Administrador", Permission = new[] { "MENU 1", "MENU 3" } } };

            // At
            var actual = await objectUt.GetAuthorizationData(UserId);
            var result = this.compareLogic.Compare(expected, actual);

            // Assert
            Assert.IsTrue(result.AreEqual);
        }

        /// <summary>
        /// This tests should fail when no role/permission has been activated.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [TestMethod]
        [ExpectedException(typeof(InvalidUserRolException))]
        public async Task GetAuthorizationDataShouldFail()
        {
            // Arrange
            const int UserId = 3;
            var objectUt = new RoleRepository(this.applicationContext);

            // At
            await objectUt.GetAuthorizationData(UserId);

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
            await this.applicationContext.Rol.AddRangeAsync(this.roleTestData);
            await this.applicationContext.Permission.AddRangeAsync(this.permissionsTestData);
            await this.applicationContext.UserRol.AddRangeAsync(this.userRolTestData);
            await this.applicationContext.RolPermission.AddRangeAsync(this.rolPermissionsTestData);

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
            var data1 = await this.applicationContext.User.ToListAsync();
            this.applicationContext.User.RemoveRange(data1);
            var data2 = await this.applicationContext.Rol.ToListAsync();
            this.applicationContext.Rol.RemoveRange(data2);
            var data3 = await this.applicationContext.Permission.ToListAsync();
            this.applicationContext.Permission.RemoveRange(data3);
            var data4 = await this.applicationContext.UserRol.ToListAsync();
            this.applicationContext.UserRol.RemoveRange(data4);
            var data5 = await this.applicationContext.RolPermission.ToListAsync();
            this.applicationContext.RolPermission.RemoveRange(data5);

            await this.applicationContext.SaveChangesAsync();
        }
        #endregion
    }
}