// --------------------------------------------------------------------------------------------------------------------
// <copyright file="User.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the User type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GuizzySeguridad.Common.Types.Models
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// The user.
    /// </summary>
    public class User : BaseType
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the user name.
        /// </summary>
        [Required]
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        [Required]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the user authorizations.
        /// </summary>
        [Required]
        public Authorization[] Authorizations { get; set; }
    }
}