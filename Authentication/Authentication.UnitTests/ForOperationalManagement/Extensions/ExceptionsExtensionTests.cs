// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExceptionsExtensionTests.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the ExceptionsExtentionTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Authentication.UnitTests.ForOperationalManagement.Extensions
{
    using System;

    using Authentication.OperationalManagement.Extensions;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// The exceptions extension tests.
    /// </summary>
    [TestClass]
    [TestCategory("Unit Tests")]
    public class ExceptionsExtensionTests
    {
        #region Test Methods
        /// <summary>
        /// This method should get a human readable text for a non asynchronous exception.
        /// </summary>
        [TestMethod]
        public void WalkExceptionTestShouldSucceed()
        {
            // Arrange 
            var innerException1 = new Exception("Inner Exception one rised.");
            var innerException2 = new Exception("Inner Exception two rised.", innerException1);
            var exception = new Exception("Exception rised.", innerException2);

            try
            {
                // This creates the stack trace.
                throw exception;
            }
            catch (Exception e)
            {
                exception = e; 
            }

            // Act
            var message = exception.Handle();

            // Assert
            Assert.IsNotNull(message);
        }

        /// <summary>
        /// This method should get a human readable text for a non asynchronous exception.
        /// </summary>
        [TestMethod]
        public void WalkAggregateExceptionTestShouldSucceed()
        {
            // Arrange 
            var exceptionArray = new[]
                                     {
                                         new Exception("This exception was thrown in JOB 1"),
                                         new Exception("This exception was thrown in JOB 2", new Exception("This is an inner exception for JOB 2")),
                                         new Exception("This exception was thrown in JOB 3"),
                                         new Exception("This exception was thrown in JOB 4", new Exception("This is an inner exception for JOB 4", new Exception("This is the main problem for JOB 4")))
                                     };

            var aggregateException = new AggregateException(exceptionArray);

            try
            {
                throw aggregateException;
            }
            catch (AggregateException e)
            {
                aggregateException = e;
            }

            // Act
            var message = aggregateException.Handle();

            // Assert
            Assert.IsNotNull(message);
        }
        #endregion
    }
}