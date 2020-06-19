// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TokenProcessorTests.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the TokenProcessorTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GS.Mobile.UnitTests.ForProcessors
{
    using System.Threading.Tasks;

    using GS.Mobile.BusinessLayer.Interfaces;
    using GS.Mobile.BusinessLayer.Processors;
    using GS.Mobile.Types.Security;

    using KellermanSoftware.CompareNetObjects;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// The token processor tests.
    /// </summary>
    [TestClass]
    public class TokenProcessorTests
    {
        /// <summary>
        /// The token processor under test.
        /// </summary>
        private ITokenProcessor tokenProcessor;

        /// <summary>
        /// The compare logic.
        /// </summary>
        private CompareLogic compareLogic;

        #region Tests Life Cycle

        /// <summary>
        /// This method is used to configure the environment before each test.
        /// </summary>
        [TestInitialize]
        public void RunBeforeEachTest()
        {
            this.tokenProcessor = null;

            // Object Initialize
            this.compareLogic = new CompareLogic();
        }

        /// <summary>
        /// This method is used to clean the environment after each test.
        /// </summary>
        [TestCleanup]
        public void RunAfterEachTest()
        {
            this.tokenProcessor = null;

            // Object Cleanup
            this.compareLogic = null;
        }
        #endregion

        #region DecodeTokenString()

        /// <summary>
        /// This tests should decode successfully a JWT payload and return a valid <see cref="Token"/> object.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [TestMethod]
        public async Task DecodeTokenStringShouldSucceed()
        {
            // Arrange
            const string Token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJwcmltYXJ5c2lkIjoiMiIsInVuaXF1ZV9uYW1lIjoiSmFpbWUiLCJlbWFpbCI6ImphaW1lLmNhc3RvcmVuYUBwc2kuY29uZG9taW5pby5jb20iLCJyb2xlIjoiQWRtaW5pc3RyYWRvciIsIm5iZiI6MTU5MTkwNzAwMywiZXhwIjoxNTkxOTE0MjAzLCJpYXQiOjE1OTE5MDcwMDMsImlzcyI6Ijk1Nzg4MGJlLTdkNmQtNGY4YS1hMzQ1LTdiOWViNzc4ZDVkZCIsImF1ZCI6IjNjMTYyNTVlLTJiYmQtNGE0OC04MjJmLWNmYThmZWEzMWNkOSJ9.IZhNOZ00DtyjuXifXPyeU6D2xnt0SXzcM-g_TP2OnwY";
            var expected = new Token { SingleId = 2, UniqueName = "Jaime", Email = "jaime.castorena@psi.condominio.com", Role = "Administrador" };
            this.tokenProcessor = new TokenProcessor();

            // Act
            var actual = await this.tokenProcessor.DecodeTokenString(Token);
            var result = this.compareLogic.Compare(expected, actual);

            // Assert
            Assert.IsTrue(result.AreEqual);
        }

        /// <summary>
        /// This tests should fail decoding a JWT payload and return null.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [TestMethod]
        public async Task DecodeTokenStringShouldFailWhenEmpty()
        {
            // Arrange
            const string Token = "iruw3p4u3k3lj2r098r2ykncba,sdkjbasd";
            this.tokenProcessor = new TokenProcessor();

            // Act
            var actual = await this.tokenProcessor.DecodeTokenString(Token);

            // Assert
            Assert.IsNull(actual);
        }

        /// <summary>
        /// This tests should fail decoding a JWT payload and return null.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [TestMethod]
        public async Task DecodeTokenStringShouldFailWhenBadToken()
        {
            // Arrange
            this.tokenProcessor = new TokenProcessor();

            // Act
            var actual = await this.tokenProcessor.DecodeTokenString(string.Empty);

            // Assert
            Assert.IsNull(actual);
        }

        /// <summary>
        /// This method should fail decoding a JWT payload when a different layout is used.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [TestMethod]
        public async Task DecodeTokenStringShouldFailWhenDifferentTokenLayout()
        {
            // Arrange
            // See https://jwt.io/ for payload structure.
            const string Token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c";

            this.tokenProcessor = new TokenProcessor();

            // Act
            var actual = await this.tokenProcessor.DecodeTokenString(Token);

            // Assert
            Assert.IsNull(actual);
        }

        #endregion

        #region ValidateTokenString()

        /// <summary>
        /// This tests should validate a JWT successfully.
        /// </summary>
        [TestMethod]
        public void ValidateTokenStringShouldSucceed()
        {
            // Arrange
            const string Token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJwcmltYXJ5c2lkIjoiMSIsInVuaXF1ZV9uYW1lIjoiR29vZFVzZXJOYW1lIiwiZW1haWwiOiJnb29kdXNlckBlbWFpbC5jb20iLCJyb2xlIjoiQWRtaW5pc3RyYWRvciIsIm5iZiI6MTU5MjU0MTU2MywiZXhwIjoxNjY0NTQxNTYzLCJpYXQiOjE1OTI1NDE1NjMsImlzcyI6IjNiZDk2ZWZmLTlhM2UtNDBmYy05N2RmLTkyNDg0YjUxZmE4OSIsImF1ZCI6ImVhZmRhYzkzLTM0MzItNDA2Yy04OWVmLWViOGNlNjNiOWRhYSJ9.Xg52kzRAGsRpdxQrmWI8M07J6NjmUmXWZYs8mqY9gaI";
            this.tokenProcessor = new TokenProcessor();

            // Act
            var actual = this.tokenProcessor.ValidateTokenString(Token);

            // Assert
            Assert.IsTrue(actual, "Generate a new token with expiration time bigger than 1 year.");
        }

        /// <summary>
        /// This tests should validate a JWT successfully.
        /// </summary>
        [TestMethod]
        public void ValidateTokenStringShouldFailOnTokenStructure()
        {
            // Arrange
            const string Token = "eyJhbGciOiJIUzIY";
            this.tokenProcessor = new TokenProcessor();

            // Act
            var actual = this.tokenProcessor.ValidateTokenString(Token);

            // Assert
            Assert.IsFalse(actual);
        }

        /// <summary>
        /// This tests should validate token expiration time.
        /// </summary>
        [TestMethod]
        public void ValidateTokenStringShouldFailOnExpirationTime()
        {
            // Arrange
            const string Token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJwcmltYXJ5c2lkIjoiMiIsInVuaXF1ZV9uYW1lIjoiSmFpbWUiLCJlbWFpbCI6ImphaW1lLmNhc3RvcmVuYUBwc2kuY29uZG9taW5pby5jb20iLCJyb2xlIjoiQWRtaW5pc3RyYWRvciIsIm5iZiI6MTU5MTkwNzAwMywiZXhwIjoxNTkxOTE0MjAzLCJpYXQiOjE1OTE5MDcwMDMsImlzcyI6Ijk1Nzg4MGJlLTdkNmQtNGY4YS1hMzQ1LTdiOWViNzc4ZDVkZCIsImF1ZCI6IjNjMTYyNTVlLTJiYmQtNGE0OC04MjJmLWNmYThmZWEzMWNkOSJ9.IZhNOZ00DtyjuXifXPyeU6D2xnt0SXzcM-g_TP2OnwY";
            this.tokenProcessor = new TokenProcessor();

            // Act
            var actual = this.tokenProcessor.ValidateTokenString(Token);

            // Assert
            Assert.IsFalse(actual, "Date has not expired or is not being validating.");
        }

        #endregion
    }
}