// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MenuViewModelTests.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the MenuViewModelTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GS.Mobile.UnitTests.ForViewModels
{
    using System;
    using System.Collections.Generic;

    using GS.Mobile.BusinessLayer.Interfaces;
    using GS.Mobile.Share.Messages;
    using GS.Mobile.Share.Routing;
    using GS.Mobile.Types.Menu;
    using GS.Mobile.ViewModels.Menu;
    using GS.Mobile.Views.Main;
    using GS.Mobile.Views.Users;

    using KellermanSoftware.CompareNetObjects;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    /// <summary>
    /// The menu view model tests.
    /// </summary>
    [TestClass]
    public class MenuViewModelTests
    {
        /// <summary>
        /// The view model under test.
        /// </summary>
        private IMenuViewModel menuViewModel;

        /// <summary>
        /// All pages in menu list.
        /// </summary>
        private List<MenuPageItem> menuList;

        /// <summary>
        /// The compare logic.
        /// </summary>
        private CompareLogic compareLogic;

        /// <summary>
        /// <see cref="ISessionProcessor"/> mock object.
        /// </summary>
        private Mock<ISessionProcessor> mockISessionProcessor;
        
        /// <summary>
        /// <see cref="IRoutingService"/> mock object.
        /// </summary>
        private Mock<IRoutingService> mockIRoutingService;

        /// <summary>
        /// <see cref="IMessageService"/> mock object.
        /// </summary>
        private Mock<IMessageService> mockIMessageService;

        #region Tests Life Cycle

        /// <summary>
        /// This method is used to configure the environment before each test.
        /// </summary>
        [TestInitialize]
        public void RunBeforeEachTest()
        {
            // Object initialization
            this.menuViewModel = null;
            this.compareLogic = new CompareLogic();
            this.menuList = new List<MenuPageItem>
                                {
                                    new MenuPageItem { Id = 1, PageName = "Home", ImageSource = "ic_action_home", PageType = typeof(DashboardPage) },
                                    new MenuPageItem { Id = 2, PageName = "Usuarios", ImageSource = "ic_action_group.png", PageType = typeof(UserListPage) }
                                };

            // Mock definition
            this.mockIRoutingService = new Mock<IRoutingService>();
            this.mockIMessageService = new Mock<IMessageService>();
            this.mockISessionProcessor = new Mock<ISessionProcessor>();
        }

        /// <summary>
        /// This method is used to clean the environment after each test.
        /// </summary>
        [TestCleanup]
        public void RunAfterEachTest()
        {
            // Object cleanup
            this.menuViewModel = null;
            this.compareLogic = null;

            // Mock cleanup
            this.mockISessionProcessor = null;
            this.mockIRoutingService = null;
            this.mockIMessageService = null;
        }
        #endregion

        #region Constructor

        /// <summary>
        /// The on start should create the menu successfully.
        /// </summary>
        [TestMethod]
        public void ConstructorShouldInitializeTheMenuList()
        {
            // Arrange

            // Act
            this.menuViewModel = new MenuViewModel(this.mockIRoutingService.Object, this.mockIMessageService.Object, this.mockISessionProcessor.Object);

            // Assert
            Assert.IsNotNull(this.menuViewModel.MenuItemList);
        }
        #endregion

        #region OnLoad()

        /// <summary>
        /// This tests should validate the menu list.
        /// </summary>
        [TestMethod]
        public void OnLoadShouldInitializeTheMenuListSuccessfully()
        {
            // Arrange
            this.menuViewModel = new MenuViewModel(this.mockIRoutingService.Object, this.mockIMessageService.Object, this.mockISessionProcessor.Object);

            // Act
            var commandUt = this.menuViewModel.OnLoadCommand;
            commandUt.Execute(null);
            var result = this.compareLogic.Compare(this.menuList, this.menuViewModel.MenuItemList);

            // Assert
            Assert.IsNotNull(this.menuViewModel.MenuItemList);
            Assert.IsTrue(result.AreEqual, "Menu list is different.");
        }
        #endregion

        #region NavigateCommand()

        /// <summary>
        /// This test should navigate to home page successfully.
        /// </summary>
        [TestMethod]
        public void NavigateCommandShouldNotNavigateWhenNoSelectionIsDone()
        {
            // Arrange
            this.menuViewModel = new MenuViewModel(this.mockIRoutingService.Object, this.mockIMessageService.Object, this.mockISessionProcessor.Object);

            // Act
            var commandUt = this.menuViewModel.NavigateCommand;
            commandUt.Execute(null);

            // Assert
            this.mockIRoutingService.Verify(method => method.PushAsync(It.IsAny<Type>()), Times.Never);
        }

        /// <summary>
        /// This test should navigate to home page successfully.
        /// </summary>
        [TestMethod]
        public void NavigateCommandShouldNavigateToHomeSuccessfully()
        {
            // Arrange
            this.menuViewModel = new MenuViewModel(this.mockIRoutingService.Object, this.mockIMessageService.Object, this.mockISessionProcessor.Object);
            this.menuViewModel.SelectedMenuItem = this.menuList[0];

            // Act
            var commandUt = this.menuViewModel.NavigateCommand;
            commandUt.Execute(null);

            // Assert
            this.mockIRoutingService.Verify(method => method.PopToRootAsync(), Times.Once);
        }

        /// <summary>
        /// This test should navigate to any page successfully.
        /// </summary>
        [TestMethod]
        public void NavigateCommandShouldNavigateToAnyPageSuccessfully()
        {
            // Arrange
            this.menuViewModel = new MenuViewModel(this.mockIRoutingService.Object, this.mockIMessageService.Object, this.mockISessionProcessor.Object);
            var index = new Random().Next(1, this.menuList.Count - 1);
            this.menuViewModel.SelectedMenuItem = this.menuList[index];

            // Act
            var commandUt = this.menuViewModel.NavigateCommand;
            commandUt.Execute(null);

            // Assert
            this.mockIRoutingService.Verify(method => method.PushAsync(It.IsAny<Type>()), Times.Once);
        }
        #endregion
    }
}