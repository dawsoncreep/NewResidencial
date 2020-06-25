// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NullConfigurationValueException.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the NullConfigurationValueException type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GS.Mobile.Types.Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>
    /// The null configuration value exception.
    /// </summary>
    [Serializable]
    public class NullConfigurationValueException : BusinessRuleException
    {
        /// <summary>
        /// The custom message exception.
        /// </summary>
        private const string CustomMessageException = "El dato extraido del archivo de configuración no puede ser nulo o vacío.";

        /// <inheritdoc />>
        public NullConfigurationValueException() : base(CustomMessageException)
        {
        }

        /// <inheritdoc />>
        public NullConfigurationValueException(string message) : base(message)
        {
        }

        /// <inheritdoc />>
        public NullConfigurationValueException(IEnumerable<string> errors) : base(CustomMessageException, errors)
        {
        }

        /// <inheritdoc />>
        public NullConfigurationValueException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <inheritdoc />
        public NullConfigurationValueException(Exception innerException) : base(CustomMessageException, innerException)
        {
        }

        /// <inheritdoc />
        protected NullConfigurationValueException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}