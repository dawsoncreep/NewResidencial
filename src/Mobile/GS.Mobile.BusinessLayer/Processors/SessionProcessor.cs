// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SessionProcessor.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the SessionProcessor type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GS.Mobile.BusinessLayer.Processors
{
    using GS.Mobile.BusinessLayer.Interfaces;

    /// <summary>
    /// The session processor.
    /// </summary>
    public class SessionProcessor : ISessionProcessor
    {
        /// <inheritdoc />
        public bool ValidateCurrentSession(string roles)
        {
            var session = false;
            return session;
        }
    }
}