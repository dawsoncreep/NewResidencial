// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LoginViewModelTests.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the LoginViewModelTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GS.Mobile.UnitTests.ForViewModels
{
    using System;
    using System.Linq;

    using GS.Mobile.BusinessLayer.Interfaces;
    using GS.Mobile.Share.Routing;
    using GS.Mobile.Types.Exceptions;
    using GS.Mobile.ViewModels.Attributes;
    using GS.Mobile.ViewModels.Login;
    using GS.Mobile.Views.Main;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    /// <summary>
    /// The login view model tests.
    /// </summary>
    [TestClass]
    public class LoginViewModelTests
    {
        /// <summary>
        /// The view model under test.
        /// </summary>
        private ILoginViewModel loginViewModel;

        /// <summary>
        /// <see cref="ISessionProcessor"/> mock object.
        /// </summary>
        private Mock<ISessionProcessor> mockISessionProcessor;

        /// <summary>
        /// <see cref="IUserProcessor"/> mock object.
        /// </summary>
        private Mock<IUserProcessor> mockIUserProcessor;

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
            this.mockIRoutingService = new Mock<IRoutingService>();
            this.mockISessionProcessor = new Mock<ISessionProcessor>();
            this.mockIUserProcessor = new Mock<IUserProcessor>();
        }

        /// <summary>
        /// This method is used to clean the environment after each test.
        /// </summary>
        [TestCleanup]
        public void RunAfterEachTest()
        {
            this.mockISessionProcessor = null;
            this.mockIRoutingService = null;
            this.mockIUserProcessor = null;
        }
        #endregion

        #region Creational

        /// <summary>
        /// This tests should validate the successful creation of the <see cref="LoginViewModel"/>.
        /// </summary>
        [TestMethod]
        public void LoginViewModelShouldBeCreated()
        {
            // Arrange
            var actual = new LoginViewModel(this.mockIRoutingService.Object, this.mockISessionProcessor.Object, this.mockIUserProcessor.Object);

            // Act
            this.loginViewModel = actual;

            // Assert
            Assert.IsNotNull(this.loginViewModel);
            Assert.IsInstanceOfType(this.loginViewModel, typeof(ILoginViewModel));
        }

        /// <summary>
        /// This tests should validate custom attributes.
        /// </summary>
        [TestMethod]
        public void LoginViewModelShouldHaveAuthorizationAttributeWidthNoRoles()
        {
            // Arrange
            this.loginViewModel = new LoginViewModel(this.mockIRoutingService.Object, this.mockISessionProcessor.Object, this.mockIUserProcessor.Object);

            // Act
            var attribute = this.loginViewModel.GetType().CustomAttributes.FirstOrDefault();

            // Assert
            Assert.IsNotNull(attribute);
            Assert.IsTrue(attribute.AttributeType.Name == typeof(AllowAnonymous).Name);
            Assert.IsTrue(attribute.ConstructorArguments.Count == 1);
        }
        #endregion

        #region LoginCommand()

        /// <summary>
        /// This test should successfully validate and login a user into system.
        /// </summary>
        [TestMethod]
        public void LoginCommandShouldSucceed()
        {
            // Arrange
            const string UserName = "jaime.castorena@psi.condominio.com";
            const string Password = "Password";
            const string Token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJwcmltYXJ5c2lkIjoiMiIsInVuaXF1ZV9uYW1lIjoiSmFpbWUiLCJlbWFpbCI6ImphaW1lLmNhc3RvcmVuYUBwc2kuY29uZG9taW5pby5jb20iLCJyb2xlIjoiQWRtaW5pc3RyYWRvciIsIm5iZiI6MTU5MTkwNzAwMywiZXhwIjoxNTkxOTE0MjAzLCJpYXQiOjE1OTE5MDcwMDMsImlzcyI6Ijk1Nzg4MGJlLTdkNmQtNGY4YS1hMzQ1LTdiOWViNzc4ZDVkZCIsImF1ZCI6IjNjMTYyNTVlLTJiYmQtNGE0OC04MjJmLWNmYThmZWEzMWNkOSJ9.IZhNOZ00DtyjuXifXPyeU6D2xnt0SXzcM-g_TP2OnwY";

            this.mockIUserProcessor.Setup(method => method.Login(UserName, Password)).ReturnsAsync(Token);

            this.loginViewModel = new LoginViewModel(this.mockIRoutingService.Object, this.mockISessionProcessor.Object, this.mockIUserProcessor.Object);
            this.loginViewModel.UserName = UserName;
            this.loginViewModel.Password = Password;

            // Act
            var commandUt = this.loginViewModel.LoginCommand;
            commandUt.Execute(null);

            // Assert
            this.mockIUserProcessor.Verify(method => method.Login(this.loginViewModel.UserName, this.loginViewModel.Password), Times.Once);
            this.mockISessionProcessor.Verify(method => method.SaveToken(It.IsAny<string>()), Times.Once);
            this.mockIRoutingService.Verify(method => method.SetMaster<MasterPage>(), Times.Once);
        }

        /// <summary>
        /// This tests should show thrown an error message when the username is invalid.
        /// </summary>
        [TestMethod]
        public void LoginCommandShouldValidateEmptyPassword()
        {
            // Arrange
            const string ExpectedError = "El nombre de usuario y/o la contrasena son incorrectos.";
            const string UserName = "jaime.castorena@psi.condominio.com";

            this.loginViewModel = new LoginViewModel(this.mockIRoutingService.Object, this.mockISessionProcessor.Object, this.mockIUserProcessor.Object);
            this.loginViewModel.UserName = UserName;

            // Act
            var commandUt = this.loginViewModel.LoginCommand;
            commandUt.Execute(null);

            // Assert
            Assert.AreEqual(ExpectedError, this.loginViewModel.ErrorMessage);
            this.mockIUserProcessor.Verify(method => method.Login(this.loginViewModel.UserName, this.loginViewModel.Password), Times.Never);
            this.mockISessionProcessor.Verify(method => method.SaveToken(It.IsAny<string>()), Times.Never);
            this.mockIRoutingService.Verify(method => method.SetMaster<MasterPage>(), Times.Never);
        }

        /// <summary>
        /// This tests should show thrown an error message when the username is invalid.
        /// </summary>
        [TestMethod]
        public void LoginCommandShouldValidateEmptyUserName()
        {
            // Arrange
            const string ExpectedError = "El nombre de usuario y/o la contrasena son incorrectos.";
            const string Password = "Password";

            this.loginViewModel = new LoginViewModel(this.mockIRoutingService.Object, this.mockISessionProcessor.Object, this.mockIUserProcessor.Object);
            this.loginViewModel.Password = Password;

            // Act
            var commandUt = this.loginViewModel.LoginCommand;
            commandUt.Execute(null);

            // Assert
            Assert.AreEqual(ExpectedError, this.loginViewModel.ErrorMessage);
            this.mockIUserProcessor.Verify(method => method.Login(this.loginViewModel.UserName, this.loginViewModel.Password), Times.Never);
            this.mockISessionProcessor.Verify(method => method.SaveToken(It.IsAny<string>()), Times.Never);
            this.mockIRoutingService.Verify(method => method.SetMaster<MasterPage>(), Times.Never);
        }

        /// <summary>
        /// This tests should simulate an error when login the user into system.
        /// </summary>
        [TestMethod]
        public void LoginCommandShouldFailOnLogin()
        {
            // Arrange
            const string UserName = "jaime.castorena@psi.condominio.com";
            const string Password = "Password";
            var exception = new ServiceCallException();

            this.mockIUserProcessor.Setup(method => method.Login(UserName, Password)).ThrowsAsync(new ServiceCallException());

            this.loginViewModel = new LoginViewModel(this.mockIRoutingService.Object, this.mockISessionProcessor.Object, this.mockIUserProcessor.Object);
            this.loginViewModel.UserName = UserName;
            this.loginViewModel.Password = Password;

            // Act
            var commandUt = this.loginViewModel.LoginCommand;
            commandUt.Execute(null);

            // Assert
            Assert.AreEqual(exception.Message, this.loginViewModel.ErrorMessage);
            this.mockIUserProcessor.Verify(method => method.Login(this.loginViewModel.UserName, this.loginViewModel.Password), Times.Once);
        }

        /// <summary>
        /// This tests should simulate an error when login the user into system.
        /// </summary>
        [TestMethod]
        public void LoginCommandShouldFailOnAnyException()
        {
            // Arrange
            const string UserName = "jaime.castorena@psi.condominio.com";
            const string Password = "Password";
            var exception = new Exception("Some unhandled exception.");

            this.mockIUserProcessor.Setup(method => method.Login(UserName, Password)).ThrowsAsync(exception);

            this.loginViewModel = new LoginViewModel(this.mockIRoutingService.Object, this.mockISessionProcessor.Object, this.mockIUserProcessor.Object);
            this.loginViewModel.UserName = UserName;
            this.loginViewModel.Password = Password;

            // Act
            var commandUt = this.loginViewModel.LoginCommand;
            commandUt.Execute(null);

            // Assert
            Assert.AreEqual(exception.Message, this.loginViewModel.ErrorMessage);
            this.mockIUserProcessor.Verify(method => method.Login(this.loginViewModel.UserName, this.loginViewModel.Password), Times.Once);
        }
        #endregion
    }
}