// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CollectionModelDescription.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the CollectionModelDescription type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Authentication.Api.Areas.HelpPage.ModelDescriptions
{
    /// <summary>
    /// The collection model description.
    /// </summary>
    public class CollectionModelDescription : ModelDescription
    {
        /// <summary>
        /// Gets or sets the element description.
        /// </summary>
        public ModelDescription ElementDescription { get; set; }
    }
}