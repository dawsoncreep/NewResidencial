// --------------------------------------------------------------------------------------------------------------------
// <copyright file="User.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the User type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GS.Api.Types.Models
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
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the user name.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        [Required]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        [Required]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the nick name.
        /// </summary>
        [Required]
        public string NickName { get; set; }

        /// <summary>
        /// Gets or sets the user role.
        /// </summary>
        [Required]
        public string Role { get; set; }

        /// <summary>
        /// Gets or sets the user/role permissions.
        /// </summary>
        public string[] Permissions { get; set; }
    }
}