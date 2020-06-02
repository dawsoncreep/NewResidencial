// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Authorization.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the Authorization type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GS.Api.Types.Models
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// The authorization.
    /// </summary>
    public class Authorization : BaseType
    {
        /// <summary>
        /// Gets or sets the role.
        /// </summary>
        [Required]
        public string Role { get; set; }

        /// <summary>
        /// Gets or sets the rol permission list.
        /// </summary>
        [Required]
        public string[] Permission { get; set; }
    }
}