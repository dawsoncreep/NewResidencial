// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EnumValueDescription.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the EnumValueDescription type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Authentication.Api.Areas.HelpPage.ModelDescriptions
{
    /// <summary>
    /// The enum value description.
    /// </summary>
    public class EnumValueDescription
    {
        /// <summary>
        /// Gets or sets the documentation.
        /// </summary>
        public string Documentation { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        public string Value { get; set; }
    }
}