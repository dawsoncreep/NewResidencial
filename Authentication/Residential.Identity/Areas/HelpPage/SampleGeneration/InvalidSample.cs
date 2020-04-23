// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InvalidSample.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   This represents an invalid sample on the help page. There's a display template named InvalidSample associated with this class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Residential.Identity.Areas.HelpPage.SampleGeneration
{
    using System;

    /// <summary>
    /// This represents an invalid sample on the help page. There's a display template named InvalidSample associated with this class.
    /// </summary>
    public class InvalidSample
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidSample"/> class.
        /// </summary>
        /// <param name="errorMessage">
        /// The error message.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when the input error message is null or empty.
        /// </exception>
        public InvalidSample(string errorMessage)
        {
            if (string.IsNullOrEmpty(errorMessage))
            {
                throw new ArgumentNullException(nameof(errorMessage));
            }

            this.ErrorMessage = errorMessage;
        }

        /// <summary>
        /// Gets the error message.
        /// </summary>
        public string ErrorMessage { get; }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            return obj is InvalidSample other && this.ErrorMessage == other.ErrorMessage;
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return this.ErrorMessage.GetHashCode();
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return this.ErrorMessage;
        }
    }
}