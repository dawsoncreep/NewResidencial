// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TokenRepositoryTests.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the TokenRepositoryTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GS.Mobile.UnitTests.ForRepositories
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using GS.Mobile.DataLayer.Context;
    using GS.Mobile.DataLayer.Entities;
    using GS.Mobile.DataLayer.Repository.Token;

    using KellermanSoftware.CompareNetObjects;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// The token repository tests.
    /// </summary>
    [TestClass]
    public class TokenRepositoryTests
    {
        /// <summary>
        /// The repository under test.
        /// </summary>
        private ITokenRepository repositoryUt;

        /// <summary>
        /// The application database context.
        /// </summary>
        private ApplicationContext context;

        /// <summary>
        /// The compare logic.
        /// </summary>
        private CompareLogic compareLogic;

        /// <summary>
        /// The test data.
        /// </summary>
        private List<SToken> testData;

        #region Tests Life Cycle

        /// <summary>
        /// This method is used to configure the environment before each test.
        /// </summary>
        [TestInitialize]
        public void RunBeforeEachTest()
        {
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase("UnitTestingDataBase")
                .Options;
            this.context = new ApplicationContext(options);

            // Object initialization
            this.repositoryUt = null;
            this.compareLogic = new CompareLogic();
            this.testData = null;
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
            await this.CleanTokenData();
            this.context.Dispose();
            this.context = null;

            // Object cleanup
            this.repositoryUt = null;
            this.compareLogic = null;
            this.testData = null;
        }
        #endregion

        /// <summary>
        /// This tests should retrieve all items inside local storage successfully.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [TestMethod]
        public async Task GetAllByPageAsyncShouldSucceed()
        {
            // Arrange
            this.testData = new List<SToken> { new SToken { Id = Guid.NewGuid(), Data = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c" } };
            await this.context.Token.AddRangeAsync(this.testData);
            await this.context.SaveChangesAsync();

            this.repositoryUt = new TokenRepository(this.context);

            // Act
            var actual = await this.repositoryUt.GetAllByPageAsync();
            var result = this.compareLogic.Compare(this.testData, actual);

            // Assert
            Assert.IsTrue(result.AreEqual);
        }

        /// <summary>
        /// This tests should add a new entity to the local storage successfully.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [TestMethod]
        public async Task AddAsyncShouldSucceed()
        {
            // Arrange
            var entity = new SToken { Id = Guid.NewGuid(), Data = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c" };
            this.repositoryUt = new TokenRepository(this.context);

            // Act
            await this.repositoryUt.AddAsync(entity);
            var result = await this.context.Token.ToListAsync();

            // Assert
            Assert.IsTrue(result.Count == 1, $"result.Count = {result.Count}");
        }

        /// <summary>
        /// This tests should remove all entities from local storage successfully.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [TestMethod]
        public async Task RemoveAllShouldSucceed()
        {
            // Arrange
            this.testData = new List<SToken> { new SToken { Id = Guid.NewGuid(), Data = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c" } };
            await this.context.Token.AddRangeAsync(this.testData);
            await this.context.SaveChangesAsync();

            this.repositoryUt = new TokenRepository(this.context);

            // Act
            await this.repositoryUt.RemoveAll();
            var result = await this.context.Token.ToListAsync();

            // Assert
            Assert.IsTrue(result.Count == 0, $"result.Count = {result.Count}");
        }

        #region Private Methods

        /// <summary>
        /// Cleans all data for 'Token' entity.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        private async Task CleanTokenData()
        {
            var data = await this.context.Token.ToListAsync();
            this.context.RemoveRange(data);
            await this.context.SaveChangesAsync();
        }
        #endregion
    }
}