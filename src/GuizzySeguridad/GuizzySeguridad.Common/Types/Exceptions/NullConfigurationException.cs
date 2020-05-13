// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NullConfigurationException.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the NullConfigurationException type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GuizzySeguridad.Common.Types.Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <inheritdoc />
    /// <summary>
    /// The null configuration value exception.
    /// </summary>
    [Serializable]
    public class NullConfigurationException : BusinessLayerException
    {
        /// <summary>
        /// The custom message exception.
        /// </summary>
        private const string CustomMessageException = "La llave buscada en el archivo de configuración no puede ser nula o vacía.";

        /// <inheritdoc />>
        public NullConfigurationException() : base(CustomMessageException)
        {
        }

        /// <inheritdoc />>
        public NullConfigurationException(string message) : base(message)
        {
        }

        /// <inheritdoc />>
        public NullConfigurationException(IEnumerable<string> errors) : base(CustomMessageException, errors)
        {
        }

        /// <inheritdoc />>
        public NullConfigurationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <inheritdoc />
        public NullConfigurationException(Exception innerException) : base(CustomMessageException, innerException)
        {
        }

        /// <inheritdoc />
        protected NullConfigurationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}