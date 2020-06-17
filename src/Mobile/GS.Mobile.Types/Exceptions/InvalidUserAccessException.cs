// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InvalidUserAccessException.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   The invalid user access exception.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GS.Mobile.Types.Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>
    /// The invalid user access exception.
    /// </summary>
    [Serializable]
    public class InvalidUserAccessException : BusinessRuleException
    {
        /// <summary>
        /// The custom message exception.
        /// </summary>
        private const string CustomMessageException = "Nombre de usuario y/o contraseña son incorrectos.";

        /// <inheritdoc />>
        public InvalidUserAccessException() : base(CustomMessageException)
        {
        }

        /// <inheritdoc />>
        public InvalidUserAccessException(string message) : base(message)
        {
        }

        /// <inheritdoc />>
        public InvalidUserAccessException(IEnumerable<string> errors) : base(CustomMessageException, errors)
        {
        }

        /// <inheritdoc />>
        public InvalidUserAccessException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <inheritdoc />
        public InvalidUserAccessException(Exception innerException) : base(CustomMessageException, innerException)
        {
        }

        /// <inheritdoc />
        protected InvalidUserAccessException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}