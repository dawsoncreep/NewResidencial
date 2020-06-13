// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HomeViewModelTests.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the HomeViewModelTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GS.Mobile.UnitTests.ForViewModels
{
    using System.Linq;

    using GS.Mobile.BusinessLayer.Interfaces;
    using GS.Mobile.Tools.Routing;
    using GS.Mobile.ViewModels.Attributes;
    using GS.Mobile.ViewModels.Home;
    using GS.Mobile.Views.Login;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    /// <summary>
    /// The home view model tests.
    /// </summary>
    [TestClass]
    public class HomeViewModelTests
    {
        /// <summary>
        /// The home view model.
        /// </summary>
        private IHomeViewModel homeViewModel;

        /// <summary>
        /// <see cref="ISessionProcessor"/> mock object.
        /// </summary>
        private Mock<ISessionProcessor> mockISessionProcessor;

        /// <summary>
        /// <see cref="IRoutingService"/> mock object.
        /// </summary>
        private Mock<IRoutingService> mockIRoutingService;

        #region Tests Life Cycle

        /// <summary>
        /// This method is used to configure the environment before each test.
        /// </summary>
        [TestInitialize]
        public void RunBeforeEachTest()
        {
            this.mockISessionProcessor = new Mock<ISessionProcessor>();
            this.mockIRoutingService = new Mock<IRoutingService>();
        }

        /// <summary>
        /// This method is used to clean the environment after each test.
        /// </summary>
        [TestCleanup]
        public void RunAfterEachTest()
        {
            this.mockISessionProcessor = null;
            this.mockIRoutingService = null;
        }
        #endregion

        /// <summary>
        /// This tests should validate the successful creation of the <see cref="homeViewModel"/>.
        /// </summary>
        [TestMethod]
        public void HomeViewModelShouldBeCreated()
        {
            // Arrange
            var actual = new HomeViewModel(this.mockIRoutingService.Object, this.mockISessionProcessor.Object);

            // Act
            this.homeViewModel = actual;

            // Assert
            Assert.IsNotNull(this.homeViewModel);
            Assert.IsInstanceOfType(this.homeViewModel, typeof(IHomeViewModel));
        }

        /// <summary>
        /// This tests should validate custom attributes.
        /// </summary>
        [TestMethod]
        public void HomeViewModelShouldHaveAuthorizationAttributeWidthNoRoles()
        {
            // Arrange
            this.homeViewModel = new HomeViewModel(this.mockIRoutingService.Object, this.mockISessionProcessor.Object);

            // Act
            var attribute = this.homeViewModel.GetType().CustomAttributes.FirstOrDefault();

            // Assert
            Assert.IsNotNull(attribute);
            Assert.IsTrue(attribute.AttributeType.Name == typeof(Authorization).Name);
            Assert.IsTrue(attribute.ConstructorArguments.Count == 0);
        }

        /// <summary>
        /// This tests should redirect to login viewmodel when an invalid user token is found.
        /// </summary>
        [TestMethod]
        public void HomeViewModelShouldNavigateToLoginViewModelWhenInvalidUserToken()
        {
            // Arrange
            this.mockISessionProcessor.Setup(method => method.GetAccessToken()).ReturnsAsync(string.Empty);

            // Act
            this.homeViewModel = new HomeViewModel(this.mockIRoutingService.Object, this.mockISessionProcessor.Object);
            
            // Assert
            this.mockISessionProcessor.Verify(method => method.GetAccessToken(), Times.Once);
            this.mockIRoutingService.Verify(method => method.PushAsync<LoginPage>(), Times.Once);
        }
    }
}