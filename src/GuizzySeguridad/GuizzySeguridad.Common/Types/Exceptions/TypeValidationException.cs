// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TypeValidationException.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the TypeValidationException type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GuizzySeguridad.Common.Types.Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <inheritdoc />
    /// <summary>
    /// The type validation exception.
    /// </summary>
    [Serializable]
    public class TypeValidationException : BusinessLayerException
    {
        /// <summary>
        /// The custom message exception.
        /// </summary>
        private const string CustomMessageException = "Los datos no son válidos. Revise e intente de nuevo.";

        /// <inheritdoc />>
        public TypeValidationException() : base(CustomMessageException)
        {
        }

        /// <inheritdoc />>
        public TypeValidationException(string message) : base(message)
        {
        }

        /// <inheritdoc />>
        public TypeValidationException(IEnumerable<string> errors) : base(CustomMessageException, errors)
        {
        }

        /// <inheritdoc />>
        public TypeValidationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <inheritdoc />
        public TypeValidationException(Exception innerException) : base(CustomMessageException, innerException)
        {
        }

        /// <inheritdoc />
        protected TypeValidationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}