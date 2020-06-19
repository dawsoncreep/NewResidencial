// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserResponse.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   The user response.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GS.Mobile.Types.Messages
{
    using System.ComponentModel;

    /// <summary>
    /// The user response.
    /// </summary>
    public enum UserResponse
    {
        /// <summary>
        /// Affirmative user response.
        /// </summary>
        [Description("Si")]
        Yes = 1,

        /// <summary>
        /// Negative user response.
        /// </summary>
        [Description("No")]
        No,

        /// <summary>
        /// Defualt user response.
        /// </summary>
        [Description("Entendido")]
        Ok
    }
}