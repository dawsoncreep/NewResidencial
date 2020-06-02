// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LoginRequest.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the LoginRequest type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GS.Api.Types.Models
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// The login request.
    /// </summary>
    public class LoginRequest : BaseType
    {
        /// <summary>
        /// Gets or sets the user name.
        /// </summary>
        [Required]
        [EmailAddress(ErrorMessage = "Username is not a valid email address.")]
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        [Required]
        [StringLength(maximumLength: 24, MinimumLength = 8, ErrorMessage = "Password does not meet defined limits.")]
        public string Password { get; set; }
    }
}