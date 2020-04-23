// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ModelNameAttribute.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Use this attribute to change the name of the <see cref="ModelDescription" /> generated for a type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Residential.Identity.Areas.HelpPage.ModelDescriptions
{
    using System;

    /// <summary>
    /// Use this attribute to change the name of the <see cref="ModelDescription"/> generated for a type.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum, Inherited = false)]
    public sealed class ModelNameAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ModelNameAttribute"/> class.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        public ModelNameAttribute(string name)
        {
            this.Name = name;
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        public string Name { get; }
    }
}