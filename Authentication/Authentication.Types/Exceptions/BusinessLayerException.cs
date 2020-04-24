// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BusinessLayerException.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the BusinessLayerException type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Authentication.Types.Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using System.Security.Permissions;

    /// <inheritdoc />
    /// <summary>
    /// Represent a custom exception in the application.
    /// </summary>
    [Serializable]
    public abstract class BusinessLayerException : Exception
    {
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:BpsService.Types.Exceptions.BusinessLayerException" /> class.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        protected BusinessLayerException(string message) : base(message)
        {
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:BpsService.Types.Exceptions.BusinessLayerException" /> class.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <param name="errors">
        /// The errors.
        /// </param>
        protected BusinessLayerException(string message, IEnumerable<string> errors) : base(message)
        {
            this.CustomErrors = errors;
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:BpsService.Types.Exceptions.BusinessLayerException" /> class.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <param name="innerException">
        /// The inner exception.
        /// </param>
        protected BusinessLayerException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:BpsService.Types.Exceptions.BusinessLayerException" /> class.
        /// </summary>
        /// <param name="info">
        /// The info.
        /// </param>
        /// <param name="context">
        /// The context.
        /// </param>
        protected BusinessLayerException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            this.CustomErrors = (IEnumerable<string>)info.GetValue(nameof(this.CustomErrors), typeof(IEnumerable<string>));
        }

        /// <summary>
        /// Gets the custom errors.
        /// </summary>
        public IEnumerable<string> CustomErrors { get; }

        /// <inheritdoc />
        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new ArgumentNullException(nameof(info), "parameter cannot be null");
            }

            info.AddValue(nameof(this.CustomErrors), this.CustomErrors, typeof(IEnumerable<string>));

            base.GetObjectData(info, context);
        }
    }
}