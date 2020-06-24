// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LocationProcessorTest.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the LocationProcessorTest type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Authentication.UnitTests.ForBusinessLayer.Processors
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using GS.Api.BusinessLayer.Processors;
    using GS.Api.DataLayer.Interfaces;
    using GS.Api.Types.Models;
    using GS.Api.Types.Models.Persistence;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    /// <summary>
    /// The location processor test.
    /// </summary>
    [TestClass]
    [TestCategory("Unit Tests")]
    public class LocationProcessorTest
    {
        /// <summary>
        /// <see cref="ILocationRepository"/> mock object.
        /// </summary>
        private Mock<ILocationRepository> mockILocationRepository;


        #region Tests Life Cycle
        /// <summary>
        /// This method is used to configure the environment before each test.
        /// </summary>
        [TestInitialize]
        public void RunBeforeEachTest()
        {
            this.mockILocationRepository = new Mock<ILocationRepository>();
        }

        /// <summary>
        /// This method is used to clean the environment after each test.
        /// </summary>
        [TestCleanup]
        public void RunAfterEachTest()
        {
            this.mockILocationRepository = null;
        }

        #endregion

        /// <summary>
        /// Este metodo prueba caso de negocio HU-001 el cual indica que un usuario
        /// puede obtrener todas las ubicaciones que el creo.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [TestMethod]
        public async Task GetUserLocationsShouldSucceed()
        {
            // Arrange
            const int UserId = 1;
            var expectedData = new List<SLocation> { new SLocation { Id = 1 } };
            var expected = new List<Location> { new Location { Id = 1, Nombre = "Ubicacion1" } };

            this.mockILocationRepository.Setup(method => method.FindAsync(item => item.Id == UserId)).ReturnsAsync(expectedData);

            var processorUt = new LocationProcessor(this.mockILocationRepository.Object);

            // Act
            var actual = await processorUt.GetUserLocations(UserId);

            // Assert
            this.mockILocationRepository.Verify(method => method.FindAsync(item => item.Id == UserId), Times.Once);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Este metedo prueba 
        /// </summary>
        /// 
        [TestMethod]
        public async Task GetLocationByIdShouldSucced()
        {
            //Arrange 
            const int locationId = 1;
            var expected = new Location
            {
                Id = 1,
                Nombre = "Circuito Canarias 114",
                IdTipoUbicacion = 1,
                Activo = true
            };
            var proccesorUt = new LocationProcessor(this.mockILocationRepository.Object);
            //Act
            var actual = await proccesorUt.GetLocationById(locationId);

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}