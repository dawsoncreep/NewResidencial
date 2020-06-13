// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServiceCallException.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the ServiceCallException type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GS.Mobile.Types.Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <inheritdoc />
    /// <summary>
    /// The service timeout exception.
    /// </summary>
    [Serializable]
    public class ServiceCallException : BusinessRuleException
    {
        /// <summary>
        /// The custom message exception.
        /// </summary>
        private const string CustomMessageException = "Existe un problema en la conexión con lo servicios, por favor intente de nuevo en unos minutos.";

        /// <inheritdoc />>
        public ServiceCallException() : base(CustomMessageException)
        {
        }

        /// <inheritdoc />>
        public ServiceCallException(string message) : base(message)
        {
        }

        /// <inheritdoc />>
        public ServiceCallException(IEnumerable<string> errors) : base(CustomMessageException, errors)
        {
        }

        /// <inheritdoc />>
        public ServiceCallException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <inheritdoc />
        public ServiceCallException(Exception innerException) : base(CustomMessageException, innerException)
        {
        }

        /// <inheritdoc />
        protected ServiceCallException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}