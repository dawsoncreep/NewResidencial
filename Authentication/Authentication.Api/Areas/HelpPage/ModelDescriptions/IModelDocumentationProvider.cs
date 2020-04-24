// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IModelDocumentationProvider.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the IModelDocumentationProvider type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Authentication.Api.Areas.HelpPage.ModelDescriptions
{
    using System;
    using System.Reflection;

    /// <summary>
    /// The ModelDocumentationProvider interface.
    /// </summary>
    public interface IModelDocumentationProvider
    {
        /// <summary>
        /// The get documentation.
        /// </summary>
        /// <param name="member">
        /// The member.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        string GetDocumentation(MemberInfo member);

        /// <summary>
        /// The get documentation.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        string GetDocumentation(Type type);
    }
}