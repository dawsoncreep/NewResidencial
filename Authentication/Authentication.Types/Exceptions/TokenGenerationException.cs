// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TokenGenerationException.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the TokenGenerationException type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Authentication.Types.Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>
    /// The token generation exception.
    /// </summary>
    [Serializable]
    public class TokenGenerationException : BusinessLayerException
    {
        /// <summary>
        /// The custom message exception.
        /// </summary>
        private const string CustomMessageException = "No se pudo generar un nuevo JWT para el usuario actual, intente mas tarde.";

        /// <inheritdoc />>
        public TokenGenerationException() : base(CustomMessageException)
        {
        }

        /// <inheritdoc />>
        public TokenGenerationException(string message) : base(message)
        {
        }

        /// <inheritdoc />>
        public TokenGenerationException(IEnumerable<string> errors) : base(CustomMessageException, errors)
        {
        }

        /// <inheritdoc />>
        public TokenGenerationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <inheritdoc />
        public TokenGenerationException(Exception innerException) : base(CustomMessageException, innerException)
        {
        }

        /// <inheritdoc />
        protected TokenGenerationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}