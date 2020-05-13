// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LoginRequestTests.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the LoginRequestTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GuizzySeguridad.Common.UnitTests.Common.ForTypes.Models
{
    using System.Linq;

    using GuizzySeguridad.Common.Types.Exceptions;
    using GuizzySeguridad.Common.Types.Models;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// The login request tests.
    /// </summary>
    [TestClass]
    [TestCategory("Unit Tests")]
    public class LoginRequestTests
    {
        #region Test Methods

        /// <summary>
        /// This test should validate a <see cref="LoginRequest"/> successfully.
        /// </summary>
        [TestMethod]
        public void LoginRequestShouldSuccessfullyBeValidated()
        {
            // Arrange
            var objUt = new LoginRequest { UserName = "email@contoso.com", Password = "Aw350m3P455w0rd!!" };

            // Act
            objUt.Validate();

            // Assert
            // Assert.Fail("No exception has been thrown.");
        }

        /// <summary>
        /// This test should fail validating a <see cref="LoginRequest"/> Username.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(TypeValidationException))]
        public void LoginRequestShouldFailValidatingUserName()
        {
            // Arrange
            const int ExpectedErrors = 1;
            var objUt = new LoginRequest { UserName = "username", Password = "Aw350m3P455w0rd!!" };

            // Act
            try
            {
                objUt.Validate();
            }
            catch (TypeValidationException exception)
            {
                // Assert
                Assert.AreEqual(ExpectedErrors, exception.CustomErrors.Count());
                throw;
            }
        }

        /// <summary>
        /// This test should fail validating a <see cref="LoginRequest"/> Password.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(TypeValidationException))]
        public void LoginRequestShouldFailValidatingPassword()
        {
            // Arrange
            const int ExpectedErrors = 1;
            var objUt = new LoginRequest { UserName = "email@contoso.com", Password = "12345" };

            // Act
            try
            {
                objUt.Validate();
            }
            catch (TypeValidationException exception)
            {
                // Assert
                Assert.AreEqual(ExpectedErrors, exception.CustomErrors.Count());
                throw;
            }
        }

        /// <summary>
        /// This test should fail validating a <see cref="LoginRequest"/> object.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(TypeValidationException))]
        public void LoginRequestShouldFailValidatingCredentials()
        {
            // Arrange
            const int ExpectedErrors = 2;
            var objUt = new LoginRequest { UserName = "username", Password = "12345" };

            // Act
            try
            {
                objUt.Validate();
            }
            catch (TypeValidationException exception)
            {
                // Assert
                Assert.AreEqual(ExpectedErrors, exception.CustomErrors.Count());
                throw;
            }
        }
        #endregion
    }
}