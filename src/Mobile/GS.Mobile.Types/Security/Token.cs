// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Token.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the Token type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GS.Mobile.Types.Security
{
    /// <summary>
    /// The access token.
    /// </summary>
    public class Token
    {
        /// <summary>
        /// Gets or sets the single id.
        /// </summary>
        public int SingleId { get; set; }

        /// <summary>
        /// Gets or sets the unique name.
        /// </summary>
        public string UniqueName { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the role.
        /// </summary>
        public string Role { get; set; }
    }
}