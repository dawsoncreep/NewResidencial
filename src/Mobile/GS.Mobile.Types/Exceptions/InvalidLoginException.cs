// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InvalidLoginException.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   The invalid login exception.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GS.Mobile.Types.Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>
    /// The invalid login exception.
    /// </summary>
    [Serializable]
    public class InvalidLoginException : BusinessRuleException
    {
        /// <summary>
        /// The custom message exception.
        /// </summary>
        private const string CustomMessageException = "Nombre de usuario y/o contraseña son incorrectos.";

        /// <inheritdoc />>
        public InvalidLoginException() : base(CustomMessageException)
        {
        }

        /// <inheritdoc />>
        public InvalidLoginException(string message) : base(message)
        {
        }

        /// <inheritdoc />>
        public InvalidLoginException(IEnumerable<string> errors) : base(CustomMessageException, errors)
        {
        }

        /// <inheritdoc />>
        public InvalidLoginException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <inheritdoc />
        public InvalidLoginException(Exception innerException) : base(CustomMessageException, innerException)
        {
        }

        /// <inheritdoc />
        protected InvalidLoginException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}