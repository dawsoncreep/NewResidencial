// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserNotAllowedException.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the UserNotAllowedException type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GS.Mobile.Types.Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>
    /// The user not allowed exception.
    /// </summary>
    [Serializable]
    public class UserNotAllowedException : BusinessRuleException
    {
        /// <summary>
        /// The custom message exception.
        /// </summary>
        private const string CustomMessageException = "No tiene los permisos necesarios para ejecutar esta acción.";

        /// <inheritdoc />>
        public UserNotAllowedException() : base(CustomMessageException)
        {
        }

        /// <inheritdoc />>
        public UserNotAllowedException(string message) : base(message)
        {
        }

        /// <inheritdoc />>
        public UserNotAllowedException(IEnumerable<string> errors) : base(CustomMessageException, errors)
        {
        }

        /// <inheritdoc />>
        public UserNotAllowedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <inheritdoc />
        public UserNotAllowedException(Exception innerException) : base(CustomMessageException, innerException)
        {
        }

        /// <inheritdoc />
        protected UserNotAllowedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}