// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BusinessLayerExceptionTests.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the BusinessLayerExceptionTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Authentication.UnitTests.ForTypes.Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.Serialization.Formatters.Binary;

    using GS.Api.Types.Exceptions;

    using KellermanSoftware.CompareNetObjects;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// The business layer exception tests.
    /// </summary>
    [TestClass]
    [TestCategory("Unit Tests")]
    public class BusinessLayerExceptionTests
    {
        #region Fields

        /// <summary>
        /// <see cref="BusinessLayerException"/> expected message.
        /// </summary>
        private string expectedMessage;

        /// <summary>
        /// List of <see cref="BusinessLayerException"/> to be tested.
        /// </summary>
        private List<Type> exceptionDefinitions;
        #endregion
        
        #region Tests Life Cycle

        /// <summary>
        /// This method is used to configure the environment before each test.
        /// </summary>
        [TestInitialize]
        public void RunBeforeEachTest()
        {
            this.expectedMessage = string.Empty;
            this.exceptionDefinitions = Assembly.GetAssembly(typeof(BusinessLayerException))
                .GetTypes()
                .Where(item => item.IsClass && !item.IsAbstract && item.Namespace == "Authentication.Types.Exceptions")
                .ToList();
        }

        /// <summary>
        /// This method is used to clean the environment after each test.
        /// </summary>
        [TestCleanup]
        public void RunAfterEachTest()
        {
            this.expectedMessage = string.Empty;
            this.exceptionDefinitions = null;
        }
        #endregion
        
        #region Test Methods
        /// <summary>
        /// This method should validate if default message is correct to expected.
        /// </summary>
        [TestMethod]
        public void BusinessLayerExceptionShouldValidateDefaultMessage()
        {
            foreach (var definition in this.exceptionDefinitions)
            {
                // Arrange
                
                // Act
                var exception = Activator.CreateInstance(definition) as Exception;
                Assert.IsNotNull(exception);
                this.expectedMessage = exception.Message;

                // Assert
                Assert.AreEqual(this.expectedMessage, exception.Message);
                Assert.IsInstanceOfType(exception, typeof(BusinessLayerException));
            }
        }

        /// <summary>
        /// This method should validate if default message is correct and inner exceptions is valid.
        /// </summary>
        [TestMethod]
        public void TypeValidationExceptionShouldValidateDefaultMessageAndInnerException()
        {
            foreach (var definition in this.exceptionDefinitions)
            {
                // Arrange
                var innerException = new Exception("This is a test exception");

                // Act
                var exception = Activator.CreateInstance(definition, innerException) as Exception;
                Assert.IsNotNull(exception);
                this.expectedMessage = exception.Message;

                // Assert
                Assert.AreEqual(this.expectedMessage, exception.Message);
                Assert.IsInstanceOfType(exception, typeof(BusinessLayerException));
                Assert.IsNotNull(exception.InnerException);
            }
        }

        /// <summary>
        /// This method should validate is custom message being passed is correct.
        /// </summary>
        [TestMethod]
        public void BusinessLayerExceptionShouldValidateCustomMessage()
        {
            foreach (var definition in this.exceptionDefinitions)
            {
                // Arrange
                this.expectedMessage = "Testing message for TypeValidationException.";
                
                // Act
                var exception = Activator.CreateInstance(definition, this.expectedMessage) as Exception;
                Assert.IsNotNull(exception);

                // Assert
                Assert.AreEqual(this.expectedMessage, exception.Message);
                Assert.IsInstanceOfType(exception, typeof(BusinessLayerException));
            }
        }

        /// <summary>
        /// This method should validate is custom message being passed is correct and inner exceptions is valid.
        /// </summary>
        [TestMethod]
        public void BusinessLayerExceptionShouldValidateCustomMessageAndInnerException()
        {
            foreach (var definition in this.exceptionDefinitions)
            {
                // Arrange
                var innerException = new Exception("This is a test exception");
                this.expectedMessage = "Testing message for TypeValidationException.";
                
                // Act
                var exception = Activator.CreateInstance(definition, this.expectedMessage, innerException) as Exception;
                Assert.IsNotNull(exception);

                // Assert
                Assert.AreEqual(this.expectedMessage, exception.Message);
                Assert.IsInstanceOfType(exception, typeof(BusinessLayerException));
                Assert.IsNotNull(exception.InnerException);
            }
        }

        /// <summary>
        /// This method should serialized and deserialized a <see cref="TypeValidationException"/> correctly.
        /// </summary>
        [TestMethod]
        public void TypeValidationExceptionShouldSerializedAndDeserializedSuccessfully()
        {
            // Arrange     
            var errors = new List<string> { "Test validation error 1", "Test validation error 2", "Test validation error 3" };

            var comparer = new CompareLogic();

            // Serialization simple example
            var formatter = new BinaryFormatter();

            foreach (var definition in this.exceptionDefinitions)
            {
                // Act
                var buffer = new byte[4096];
                var ms1 = new MemoryStream(buffer);
                var ms2 = new MemoryStream(buffer);

                var exception = Activator.CreateInstance(definition, errors) as Exception;
                Assert.IsNotNull(exception);
                formatter.Serialize(ms1, exception);

                var actualException = (BusinessLayerException)formatter.Deserialize(ms2);
                var result = comparer.Compare(actualException.CustomErrors, errors);

                // Assert
                Assert.AreEqual(exception.Message, actualException.Message);
                Assert.IsTrue(result.AreEqual);
                Assert.IsInstanceOfType(exception, typeof(BusinessLayerException));
            }
        }
        #endregion
    }
}