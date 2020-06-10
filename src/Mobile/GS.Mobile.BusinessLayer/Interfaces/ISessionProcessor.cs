// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ISessionProcessor.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the ISessionProcessor type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GS.Mobile.BusinessLayer.Interfaces
{
    /// <summary>
    /// The SessionProcessor interface.
    /// </summary>
    public interface ISessionProcessor
    {
        /// <summary>
        /// Validates current session against roles.
        /// </summary>
        /// <param name="roles">
        /// The roles.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        bool ValidateCurrentSession(string roles);
    }
}