// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HelpPageSampleKey.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   This is used to identify the place where the sample should be applied.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Authentication.Api.Areas.HelpPage.SampleGeneration
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Net.Http.Headers;

    /// <summary>
    /// This is used to identify the place where the sample should be applied.
    /// </summary>
    public class HelpPageSampleKey
    {
        /// <summary>
        /// Creates a new <see cref="HelpPageSampleKey"/> based on media type.
        /// </summary>
        /// <param name="mediaType">The media type.</param>
        public HelpPageSampleKey(MediaTypeHeaderValue mediaType)
        {
            this.ActionName = string.Empty;
            this.ControllerName = string.Empty;
            this.MediaType = mediaType ?? throw new ArgumentNullException(nameof(mediaType));
            this.ParameterNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Creates a new <see cref="HelpPageSampleKey"/> based on media type and CLR type.
        /// </summary>
        /// <param name="mediaType">The media type.</param>
        /// <param name="type">The CLR type.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when input type object is null.
        /// </exception>
        public HelpPageSampleKey(MediaTypeHeaderValue mediaType, Type type) : this(mediaType)
        {
            this.ParameterType = type ?? throw new ArgumentNullException(nameof(type));
        }

        /// <summary>
        /// Creates a new <see cref="HelpPageSampleKey"/> based on <see cref="SampleDirection"/>, controller name, action name and parameter names.
        /// </summary>
        /// <param name="sampleDirection">The <see cref="SampleDirection"/>.</param>
        /// <param name="controllerName">Name of the controller.</param>
        /// <param name="actionName">Name of the action.</param>
        /// <param name="parameterNames">The parameter names.</param>
        public HelpPageSampleKey(SampleDirection sampleDirection, string controllerName, string actionName, IEnumerable<string> parameterNames)
        {
            if (!Enum.IsDefined(typeof(SampleDirection), sampleDirection))
            {
                throw new InvalidEnumArgumentException(nameof(sampleDirection), (int)sampleDirection, typeof(SampleDirection));
            }

            if (parameterNames == null)
            {
                throw new ArgumentNullException(nameof(parameterNames));
            }

            this.ControllerName = controllerName ?? throw new ArgumentNullException(nameof(controllerName));
            this.ActionName = actionName ?? throw new ArgumentNullException(nameof(actionName));
            this.ParameterNames = new HashSet<string>(parameterNames, StringComparer.OrdinalIgnoreCase);
            this.SampleDirection = sampleDirection;
        }

        /// <summary>
        /// Creates a new <see cref="HelpPageSampleKey"/> based on media type, <see cref="SampleDirection"/>, controller name, action name and parameter names.
        /// </summary>
        /// <param name="mediaType">The media type.</param>
        /// <param name="sampleDirection">The <see cref="SampleDirection"/>.</param>
        /// <param name="controllerName">Name of the controller.</param>
        /// <param name="actionName">Name of the action.</param>
        /// <param name="parameterNames">The parameter names.</param>
        public HelpPageSampleKey(MediaTypeHeaderValue mediaType, SampleDirection sampleDirection, string controllerName, string actionName, IEnumerable<string> parameterNames)
            : this(sampleDirection, controllerName, actionName, parameterNames)
        {
            this.MediaType = mediaType ?? throw new ArgumentNullException(nameof(mediaType));
        }

        /// <summary>
        /// Gets the name of the controller.
        /// </summary>
        /// <value>
        /// The name of the controller.
        /// </value>
        public string ControllerName { get; }

        /// <summary>
        /// Gets the name of the action.
        /// </summary>
        /// <value>
        /// The name of the action.
        /// </value>
        public string ActionName { get; }

        /// <summary>
        /// Gets the media type.
        /// </summary>
        /// <value>
        /// The media type.
        /// </value>
        public MediaTypeHeaderValue MediaType { get; }

        /// <summary>
        /// Gets the parameter names.
        /// </summary>
        public HashSet<string> ParameterNames { get; }

        /// <summary>
        /// Gets the parameter type.
        /// </summary>
        public Type ParameterType { get; }

        /// <summary>
        /// Gets the <see cref="SampleDirection"/>.
        /// </summary>
        public SampleDirection? SampleDirection { get; }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            if (!(obj is HelpPageSampleKey otherKey))
            {
                return false;
            }

            return string.Equals(this.ControllerName, otherKey.ControllerName, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(this.ActionName, otherKey.ActionName, StringComparison.OrdinalIgnoreCase) &&
                (this.MediaType == otherKey.MediaType || (this.MediaType != null && this.MediaType.Equals(otherKey.MediaType))) &&
                this.ParameterType == otherKey.ParameterType &&
                this.SampleDirection == otherKey.SampleDirection &&
                this.ParameterNames.SetEquals(otherKey.ParameterNames);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            var hashCode = this.ControllerName.ToUpperInvariant().GetHashCode() ^ this.ActionName.ToUpperInvariant().GetHashCode();
            if (this.MediaType != null)
            {
                hashCode ^= this.MediaType.GetHashCode();
            }

            if (this.SampleDirection != null)
            {
                hashCode ^= this.SampleDirection.GetHashCode();
            }

            if (this.ParameterType != null)
            {
                hashCode ^= this.ParameterType.GetHashCode();
            }

            foreach (var parameterName in this.ParameterNames)
            {
                hashCode ^= parameterName.ToUpperInvariant().GetHashCode();
            }

            return hashCode;
        }
    }
}
