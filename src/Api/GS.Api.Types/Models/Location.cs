// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Location.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the Location type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GS.Api.Types.Models
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// The location.
    /// </summary>
    public class Location : BaseType
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [Required]
        public string Name { get; set; }
    }
}