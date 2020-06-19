// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MessageType.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   The message type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GS.Mobile.Types.Messages
{
    using System.ComponentModel;

    /// <summary>
    /// The message type.
    /// </summary>
    public enum MessageType
    {
        /// <summary>
        /// The error message type.
        /// </summary>
        [Description("Error")]
        Error = 1,

        /// <summary>
        /// The warning message type.
        /// </summary>
        [Description("Alerta")]
        Warning,

        /// <summary>
        /// The information message type.
        /// </summary>
        [Description("Información")]
        Information
    }
}