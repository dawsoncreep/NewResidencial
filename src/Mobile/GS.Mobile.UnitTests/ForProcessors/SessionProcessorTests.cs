// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SessionProcessorTests.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the SessionProcessorTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GS.Mobile.UnitTests.ForProcessors
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using GS.Mobile.BusinessLayer.Interfaces;
    using GS.Mobile.BusinessLayer.Processors;
    using GS.Mobile.DataLayer.Entities;
    using GS.Mobile.DataLayer.Repository.Token;
    using GS.Mobile.Types.Exceptions;
    using GS.Mobile.Types.Security;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    /// <summary>
    /// The session processor tests.
    /// </summary>
    [TestClass]
    public class SessionProcessorTests
    {
        /// <summary>
        /// The session processor under test.
        /// </summary>
        private ISessionProcessor sessionProcessor;

        /// <summary>
        /// <see cref="ITokenRepository"/> mock object.
        /// </summary>
        private Mock<ITokenRepository> mockITokenRepository;

        /// <summary>
        /// <see cref="ITokenProcessor"/> mock object.
        /// </summary>
        private Mock<ITokenProcessor> mockITokenProcessor;

        #region Tests Life Cycle

        /// <summary>
        /// This method is used to configure the environment before each test.
        /// </summary>
        [TestInitialize]
        public void RunBeforeEachTest()
        {
            this.sessionProcessor = null;

            // Mock definition
            this.mockITokenRepository = new Mock<ITokenRepository>();
            this.mockITokenProcessor = new Mock<ITokenProcessor>();
        }

        /// <summary>
        /// This method is used to clean the environment after each test.
        /// </summary>
        [TestCleanup]
        public void RunAfterEachTest()
        {
            this.sessionProcessor = null;

            // Mock cleanup
            this.mockITokenRepository = null;
            this.mockITokenProcessor = null;
        }
        #endregion

        #region GetAccessToken()

        /// <summary>
        /// This tests should return 'the token' when a valid token is found.
        /// No roles are implied.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [TestMethod]
        public async Task GetAccessTokenShouldSucceed()
        {
            // Arrange
            const string Expected = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJwcmltYXJ5c2lkIjoiMiIsInVuaXF1ZV9uYW1lIjoiSmFpbWUiLCJlbWFpbCI6ImphaW1lLmNhc3RvcmVuYUBwc2kuY29uZG9taW5pby5jb20iLCJyb2xlIjoiQWRtaW5pc3RyYWRvciIsIm5iZiI6MTU5MTkwNzAwMywiZXhwIjoxNTkxOTE0MjAzLCJpYXQiOjE1OTE5MDcwMDMsImlzcyI6Ijk1Nzg4MGJlLTdkNmQtNGY4YS1hMzQ1LTdiOWViNzc4ZDVkZCIsImF1ZCI6IjNjMTYyNTVlLTJiYmQtNGE0OC04MjJmLWNmYThmZWEzMWNkOSJ9.IZhNOZ00DtyjuXifXPyeU6D2xnt0SXzcM-g_TP2OnwY";
            var localData = new List<SToken> { new SToken { Id = Guid.NewGuid(), Data = Expected } };

            this.mockITokenRepository.Setup(method => method.GetAllByPageAsync(It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync(localData);
            this.sessionProcessor = new SessionProcessor(this.mockITokenProcessor.Object, this.mockITokenRepository.Object);

            // Act
            var actual = await this.sessionProcessor.GetAccessToken();

            // Assert
            this.mockITokenRepository.Verify(method => method.GetAllByPageAsync(It.IsAny<int>(), It.IsAny<int>()), Times.Once);
            Assert.IsNotNull(actual);
            Assert.AreEqual(Expected, actual);
        }

        /// <summary>
        /// This tests should return null when no tokens were found.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [TestMethod]
        public async Task GetAccessTokenShouldReturnEmpty()
        {
            // Arrange
            this.mockITokenRepository.Setup(method => method.GetAllByPageAsync(It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync(new List<SToken>());
            this.sessionProcessor = new SessionProcessor(this.mockITokenProcessor.Object, this.mockITokenRepository.Object);

            // Act
            var actual = await this.sessionProcessor.GetAccessToken();

            // Assert
            this.mockITokenRepository.Verify(method => method.GetAllByPageAsync(It.IsAny<int>(), It.IsAny<int>()), Times.Once);
            Assert.IsTrue(string.IsNullOrEmpty(actual));
        }

        /// <summary>
        /// This tests should return null when multiple tokens were found.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [TestMethod]
        public async Task GetAccessTokenShouldCleanAllMultipleTokens()
        {
            // Arrange
            const string Expected = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJwcmltYXJ5c2lkIjoiMiIsInVuaXF1ZV9uYW1lIjoiSmFpbWUiLCJlbWFpbCI6ImphaW1lLmNhc3RvcmVuYUBwc2kuY29uZG9taW5pby5jb20iLCJyb2xlIjoiQWRtaW5pc3RyYWRvciIsIm5iZiI6MTU5MTkwNzAwMywiZXhwIjoxNTkxOTE0MjAzLCJpYXQiOjE1OTE5MDcwMDMsImlzcyI6Ijk1Nzg4MGJlLTdkNmQtNGY4YS1hMzQ1LTdiOWViNzc4ZDVkZCIsImF1ZCI6IjNjMTYyNTVlLTJiYmQtNGE0OC04MjJmLWNmYThmZWEzMWNkOSJ9.IZhNOZ00DtyjuXifXPyeU6D2xnt0SXzcM-g_TP2OnwY";
            var localData = new List<SToken> { new SToken { Id = Guid.NewGuid(), Data = Expected }, new SToken { Id = Guid.NewGuid(), Data = Expected } };

            this.mockITokenRepository.Setup(method => method.GetAllByPageAsync(It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync(localData);
            this.sessionProcessor = new SessionProcessor(this.mockITokenProcessor.Object, this.mockITokenRepository.Object);

            // Act
            var actual = await this.sessionProcessor.GetAccessToken();

            // Assert
            this.mockITokenRepository.Verify(method => method.GetAllByPageAsync(It.IsAny<int>(), It.IsAny<int>()), Times.Once);
            this.mockITokenRepository.Verify(method => method.RemoveAll(), Times.Once);
            Assert.IsTrue(string.IsNullOrEmpty(actual));
        }

        /// <summary>
        /// This tests should simulate an error on data access layer and return an invalid token.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [TestMethod]
        public async Task GetAccessTokenShouldFailGettingDataFromLocalStorage()
        {
            // Arrange
            this.mockITokenRepository.Setup(method => method.GetAllByPageAsync(It.IsAny<int>(), It.IsAny<int>())).ThrowsAsync(new Exception("Data access exception"));
            this.sessionProcessor = new SessionProcessor(this.mockITokenProcessor.Object, this.mockITokenRepository.Object);

            // Act
            var actual = await this.sessionProcessor.GetAccessToken();

            // Assert
            Assert.IsTrue(string.IsNullOrEmpty(actual));
        }

        #endregion

        #region ValidateSessionWithRoles()

        /// <summary>
        /// This test should successfully validates a session with allowed roles.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [TestMethod]
        public async Task ValidateSessionWithRolesShouldSucceed()
        {
            // Arrange
            const string AllowedRoles = "CEO,Administrador";

            const string ExpectedToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJwcmltYXJ5c2lkIjoiMiIsInVuaXF1ZV9uYW1lIjoiSmFpbWUiLCJlbWFpbCI6ImphaW1lLmNhc3RvcmVuYUBwc2kuY29uZG9taW5pby5jb20iLCJyb2xlIjoiQWRtaW5pc3RyYWRvciIsIm5iZiI6MTU5MTkwNzAwMywiZXhwIjoxNTkxOTE0MjAzLCJpYXQiOjE1OTE5MDcwMDMsImlzcyI6Ijk1Nzg4MGJlLTdkNmQtNGY4YS1hMzQ1LTdiOWViNzc4ZDVkZCIsImF1ZCI6IjNjMTYyNTVlLTJiYmQtNGE0OC04MjJmLWNmYThmZWEzMWNkOSJ9.IZhNOZ00DtyjuXifXPyeU6D2xnt0SXzcM-g_TP2OnwY";
            var expectedTokenData = new Token { SingleId = 2, UniqueName = "Jaime", Email = "jaime.castorena@psi.condominio.com", Role = "Administrador" };

            var localData = new List<SToken> { new SToken { Id = Guid.NewGuid(), Data = ExpectedToken } };

            this.mockITokenProcessor.Setup(method => method.DecodeTokenString(ExpectedToken)).ReturnsAsync(expectedTokenData);
            this.mockITokenRepository.Setup(method => method.GetAllByPageAsync(It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync(localData);

            this.sessionProcessor = new SessionProcessor(this.mockITokenProcessor.Object, this.mockITokenRepository.Object);

            // Act
            var actual = await this.sessionProcessor.ValidateSessionWithRoles(AllowedRoles);

            // Assert
            this.mockITokenRepository.Verify(method => method.GetAllByPageAsync(It.IsAny<int>(), It.IsAny<int>()), Times.Once);
            this.mockITokenProcessor.Verify(method => method.DecodeTokenString(ExpectedToken), Times.Once);
            Assert.IsTrue(actual);
        }

        /// <summary>
        /// This test should fail validating a session with allowed roles.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [TestMethod]
        public async Task ValidateSessionWithRolesShouldFail()
        {
            // Arrange
            const string AllowedRoles = "Representante,Habitante";

            const string ExpectedToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJwcmltYXJ5c2lkIjoiMiIsInVuaXF1ZV9uYW1lIjoiSmFpbWUiLCJlbWFpbCI6ImphaW1lLmNhc3RvcmVuYUBwc2kuY29uZG9taW5pby5jb20iLCJyb2xlIjoiQWRtaW5pc3RyYWRvciIsIm5iZiI6MTU5MTkwNzAwMywiZXhwIjoxNTkxOTE0MjAzLCJpYXQiOjE1OTE5MDcwMDMsImlzcyI6Ijk1Nzg4MGJlLTdkNmQtNGY4YS1hMzQ1LTdiOWViNzc4ZDVkZCIsImF1ZCI6IjNjMTYyNTVlLTJiYmQtNGE0OC04MjJmLWNmYThmZWEzMWNkOSJ9.IZhNOZ00DtyjuXifXPyeU6D2xnt0SXzcM-g_TP2OnwY";
            var expectedTokenData = new Token { SingleId = 2, UniqueName = "Jaime", Email = "jaime.castorena@psi.condominio.com", Role = "Administrador" };

            var localData = new List<SToken> { new SToken { Id = Guid.NewGuid(), Data = ExpectedToken } };

            this.mockITokenProcessor.Setup(method => method.DecodeTokenString(ExpectedToken)).ReturnsAsync(expectedTokenData);
            this.mockITokenRepository.Setup(method => method.GetAllByPageAsync(It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync(localData);

            this.sessionProcessor = new SessionProcessor(this.mockITokenProcessor.Object, this.mockITokenRepository.Object);

            // Act
            var actual = await this.sessionProcessor.ValidateSessionWithRoles(AllowedRoles);

            // Assert
            this.mockITokenRepository.Verify(method => method.GetAllByPageAsync(It.IsAny<int>(), It.IsAny<int>()), Times.Once);
            this.mockITokenProcessor.Verify(method => method.DecodeTokenString(ExpectedToken), Times.Once);
            Assert.IsFalse(actual);
        }

        /// <summary>
        /// This test should fail validating a session due some invalid token string.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [TestMethod]
        public async Task ValidateSessionWithRolesShouldFailWhenException()
        {
            // Arrange
            const string AllowedRoles = "Representante,Habitante";

            const string ExpectedToken = "eyJhbGc";

            var localData = new List<SToken> { new SToken { Id = Guid.NewGuid(), Data = ExpectedToken } };

            this.mockITokenProcessor.Setup(method => method.DecodeTokenString(ExpectedToken)).ReturnsAsync(default(Token));
            this.mockITokenRepository.Setup(method => method.GetAllByPageAsync(It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync(localData);

            this.sessionProcessor = new SessionProcessor(this.mockITokenProcessor.Object, this.mockITokenRepository.Object);

            // Act
            var actual = await this.sessionProcessor.ValidateSessionWithRoles(AllowedRoles);

            // Assert
            this.mockITokenRepository.Verify(method => method.GetAllByPageAsync(It.IsAny<int>(), It.IsAny<int>()), Times.Once);
            this.mockITokenProcessor.Verify(method => method.DecodeTokenString(ExpectedToken), Times.Once);
            Assert.IsFalse(actual);
        }
        #endregion

        #region SaveToken()

        /// <summary>
        /// This test should save a new JWT into local storage.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [TestMethod]
        public async Task SaveTokenShouldSucceed()
        {
            // Arrange
            const string Token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJwcmltYXJ5c2lkIjoiMiIsInVuaXF1ZV9uYW1lIjoiSmFpbWUiLCJlbWFpbCI6ImphaW1lLmNhc3RvcmVuYUBwc2kuY29uZG9taW5pby5jb20iLCJyb2xlIjoiQWRtaW5pc3RyYWRvciIsIm5iZiI6MTU5MTkwNzAwMywiZXhwIjoxNTkxOTE0MjAzLCJpYXQiOjE1OTE5MDcwMDMsImlzcyI6Ijk1Nzg4MGJlLTdkNmQtNGY4YS1hMzQ1LTdiOWViNzc4ZDVkZCIsImF1ZCI6IjNjMTYyNTVlLTJiYmQtNGE0OC04MjJmLWNmYThmZWEzMWNkOSJ9.IZhNOZ00DtyjuXifXPyeU6D2xnt0SXzcM-g_TP2OnwY";

            this.mockITokenProcessor.Setup(method => method.ValidateTokenString(Token)).Returns(true);
            this.sessionProcessor = new SessionProcessor(this.mockITokenProcessor.Object, this.mockITokenRepository.Object);

            // Act
            await this.sessionProcessor.SaveToken(Token);

            // Assert
            this.mockITokenProcessor.Verify(method => method.ValidateTokenString(Token), Times.Once);
            this.mockITokenRepository.Verify(method => method.AddAsync(It.IsAny<SToken>()), Times.Once);
        }

        /// <summary>
        /// This test should fail saving a new JWT into local storage due and throw an exception an invalid token.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [TestMethod]
        [ExpectedException(typeof(InvalidTokenValidationException))]
        public async Task SaveTokenShouldFailWhenInvalidToken()
        {
            // Arrange
            const string Token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJwcmltYXJ5c2lkIjoiMiIsInVuaXF1ZV9uYW1lIjoiSmFpbWUiLCJlbWFpbCI6ImphaW1lLmNhc3RvcmVuYUBwc2kuY29uZG9taW5pby5jb20iLCJyb2xlIjoiQWRtaW5pc3RyYWRvciIsIm5iZiI6MTU5MTkwNzAwMywiZXhwIjoxNTkxOTE0MjAzLCJpYXQiOjE1OTE5MDcwMDMsImlzcyI6Ijk1Nzg4MGJlLTdkNmQtNGY4YS1hMzQ1LTdiOWViNzc4ZDVkZCIsImF1ZCI6IjNjMTYyNTVlLTJiYmQtNGE0OC04MjJmLWNmYThmZWEzMWNkOSJ9.IZhNOZ00DtyjuXifXPyeU6D2xnt0SXzcM-g_TP2OnwY";

            this.mockITokenProcessor.Setup(method => method.ValidateTokenString(Token)).Returns(false);
            this.sessionProcessor = new SessionProcessor(this.mockITokenProcessor.Object, this.mockITokenRepository.Object);

            // Act
            try
            {
                await this.sessionProcessor.SaveToken(Token);
            }
            catch (Exception)
            {
                // Assert
                this.mockITokenProcessor.Verify(method => method.ValidateTokenString(Token), Times.Once);
                this.mockITokenRepository.Verify(method => method.AddAsync(It.IsAny<SToken>()), Times.Never);
                throw;
            }
        }

        /// <summary>
        /// This test should fail saving a new JWT into local storage due some random exception.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [TestMethod]
        [ExpectedException(typeof(InvalidTokenValidationException))]
        public async Task SaveTokenShouldFailDueDataLayerException()
        {
            // Arrange
            const string Token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJwcmltYXJ5c2lkIjoiMiIsInVuaXF1ZV9uYW1lIjoiSmFpbWUiLCJlbWFpbCI6ImphaW1lLmNhc3RvcmVuYUBwc2kuY29uZG9taW5pby5jb20iLCJyb2xlIjoiQWRtaW5pc3RyYWRvciIsIm5iZiI6MTU5MTkwNzAwMywiZXhwIjoxNTkxOTE0MjAzLCJpYXQiOjE1OTE5MDcwMDMsImlzcyI6Ijk1Nzg4MGJlLTdkNmQtNGY4YS1hMzQ1LTdiOWViNzc4ZDVkZCIsImF1ZCI6IjNjMTYyNTVlLTJiYmQtNGE0OC04MjJmLWNmYThmZWEzMWNkOSJ9.IZhNOZ00DtyjuXifXPyeU6D2xnt0SXzcM-g_TP2OnwY";

            this.mockITokenProcessor.Setup(method => method.ValidateTokenString(Token)).Returns(true);
            this.mockITokenRepository.Setup(method => method.AddAsync(It.IsAny<SToken>())).ThrowsAsync(new Exception("Some data layer exception"));
            this.sessionProcessor = new SessionProcessor(this.mockITokenProcessor.Object, this.mockITokenRepository.Object);

            // Act
            try
            {
                await this.sessionProcessor.SaveToken(Token);
            }
            catch (Exception)
            {
                // Assert
                this.mockITokenProcessor.Verify(method => method.ValidateTokenString(Token), Times.Once);
                this.mockITokenRepository.Verify(method => method.AddAsync(It.IsAny<SToken>()), Times.Once);
                throw;
            }
        }
        #endregion
    }
}