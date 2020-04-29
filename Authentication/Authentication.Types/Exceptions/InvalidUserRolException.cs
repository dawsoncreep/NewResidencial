// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InvalidUserRolException.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the InvalidUserRolException type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Authentication.Types.Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>
    /// The invalid user rol exception.
    /// </summary>
    [Serializable]
    public class InvalidUserRolException : BusinessLayerException
    {
        /// <summary>
        /// The custom message exception.
        /// </summary>
        private const string CustomMessageException = "La información de roles o permisos no es válida.";

        /// <inheritdoc />>
        public InvalidUserRolException() : base(CustomMessageException)
        {
        }

        /// <inheritdoc />>
        public InvalidUserRolException(string message) : base(message)
        {
        }

        /// <inheritdoc />>
        public InvalidUserRolException(IEnumerable<string> errors) : base(CustomMessageException, errors)
        {
        }

        /// <inheritdoc />>
        public InvalidUserRolException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <inheritdoc />
        public InvalidUserRolException(Exception innerException) : base(CustomMessageException, innerException)
        {
        }

        /// <inheritdoc />
        protected InvalidUserRolException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}