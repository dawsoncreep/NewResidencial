// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParameterDescription.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the ParameterDescription type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Authentication.Api.Areas.HelpPage.ModelDescriptions
{
    using System.Collections.ObjectModel;

    /// <summary>
    /// The parameter description.
    /// </summary>
    public class ParameterDescription
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ParameterDescription"/> class.
        /// </summary>
        public ParameterDescription()
        {
            this.Annotations = new Collection<ParameterAnnotation>();
        }

        /// <summary>
        /// Gets the annotations.
        /// </summary>
        public Collection<ParameterAnnotation> Annotations { get; }

        /// <summary>
        /// Gets or sets the documentation.
        /// </summary>
        public string Documentation { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the type description.
        /// </summary>
        public ModelDescription TypeDescription { get; set; }
    }
}