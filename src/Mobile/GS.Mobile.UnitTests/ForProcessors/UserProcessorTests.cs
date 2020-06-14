// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserProcessorTests.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the UserProcessorTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GS.Mobile.UnitTests.ForProcessors
{
    using GS.Mobile.BusinessLayer.Interfaces;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// The user processor tests.
    /// </summary>
    [TestClass]
    public class UserProcessorTests
    {
        /// <summary>
        /// The processor under test.
        /// </summary>
        private IUserProcessor processorUt;

        #region Tests Life Cycle

        /// <summary>
        /// This method is used to configure the environment before each test.
        /// </summary>
        [TestInitialize]
        public void RunBeforeEachTest()
        {
            this.processorUt = null;
        }

        /// <summary>
        /// This method is used to clean the environment after each test.
        /// </summary>
        [TestCleanup]
        public void RunAfterEachTest()
        {
            this.processorUt = null;
        }
        #endregion  
    }
}