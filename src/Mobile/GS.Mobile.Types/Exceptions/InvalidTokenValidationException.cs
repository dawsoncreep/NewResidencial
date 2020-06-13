// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InvalidTokenValidationException.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the InvalidTokenValidationException type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GS.Mobile.Types.Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>
    /// The invalid token validation exception.
    /// </summary>
    [Serializable]
    public class InvalidTokenValidationException : BusinessRuleException
    {
        /// <summary>
        /// The custom message exception.
        /// </summary>
        private const string CustomMessageException = "El JWT actual es inválido.";

        /// <inheritdoc />>
        public InvalidTokenValidationException() : base(CustomMessageException)
        {
        }

        /// <inheritdoc />>
        public InvalidTokenValidationException(string message) : base(message)
        {
        }

        /// <inheritdoc />>
        public InvalidTokenValidationException(IEnumerable<string> errors) : base(CustomMessageException, errors)
        {
        }

        /// <inheritdoc />>
        public InvalidTokenValidationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <inheritdoc />
        public InvalidTokenValidationException(Exception innerException) : base(CustomMessageException, innerException)
        {
        }

        /// <inheritdoc />
        protected InvalidTokenValidationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}