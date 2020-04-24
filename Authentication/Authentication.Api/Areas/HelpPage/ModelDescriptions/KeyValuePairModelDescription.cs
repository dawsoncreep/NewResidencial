// --------------------------------------------------------------------------------------------------------------------
// <copyright file="KeyValuePairModelDescription.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the KeyValuePairModelDescription type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Authentication.Api.Areas.HelpPage.ModelDescriptions
{
    /// <summary>
    /// The key value pair model description.
    /// </summary>
    public class KeyValuePairModelDescription : ModelDescription
    {
        /// <summary>
        /// Gets or sets the key model description.
        /// </summary>
        public ModelDescription KeyModelDescription { get; set; }

        /// <summary>
        /// Gets or sets the value model description.
        /// </summary>
        public ModelDescription ValueModelDescription { get; set; }
    }
}