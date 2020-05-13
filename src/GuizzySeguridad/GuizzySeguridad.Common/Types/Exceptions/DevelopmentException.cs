// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DevelopmentException.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the DevelopmentException type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GuizzySeguridad.Common.Types.Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <inheritdoc />
    /// <summary>
    /// The development exception.
    /// </summary>
    [Serializable]
    public class DevelopmentException : BusinessLayerException
    {
        /// <summary>
        /// The custom message exception.
        /// </summary>
        private const string CustomMessageException = "Developer error is coming. My bad!!!!!.";

        /// <inheritdoc />>
        public DevelopmentException() : base(CustomMessageException)
        {
        }

        /// <inheritdoc />>
        public DevelopmentException(string message) : base(message)
        {
        }

        /// <inheritdoc />>
        public DevelopmentException(IEnumerable<string> errors) : base(CustomMessageException, errors)
        {
        }

        /// <inheritdoc />>
        public DevelopmentException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <inheritdoc />
        public DevelopmentException(Exception innerException) : base(CustomMessageException, innerException)
        {
        }

        /// <inheritdoc />
        protected DevelopmentException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}