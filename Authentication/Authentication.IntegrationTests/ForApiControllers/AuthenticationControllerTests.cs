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
    using System.Threading.Tasks;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// The authentication controller tests.
    /// </summary>
    [TestClass]
    [TestCategory("Integration Tests")]
    public class AuthenticationControllerTests
    {
        #region Fields
        #endregion

        #region Tests Life Cycle

        /// <summary>
        /// This method is used to configure the environment before each test.
        /// </summary>
        [TestInitialize]
        public void RunBeforeEachTest()
        {
        }

        /// <summary>
        /// This method is used to clean the environment after each test.
        /// </summary>
        [TestCleanup]
        public void RunAfterEachTest()
        {
        }
        #endregion


        #region Test Methods

        /// <summary>
        /// This method should:
        ///     1) Simulate an HTTP POST request to '~/Authentication/ValidateUser' and get HTTP code 200.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [TestMethod]
        public async Task ValidateUserShouldSucceed()
        {
            // TODO: Finish unit test first.
            await Task.CompletedTask;
        }

        #endregion
    }
}