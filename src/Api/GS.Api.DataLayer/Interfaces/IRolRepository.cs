// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRolRepository.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the IRolRepository type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GS.Api.DataLayer.Interfaces
{
    using System.Threading.Tasks;

    using GS.Api.Types.Models;

    /// <summary>
    /// The RolRepository interface.
    /// </summary>
    public interface IRolRepository
    {
        /// <summary>
        /// Gets all user authorization data.
        /// </summary>
        /// <param name="userId">
        /// The user id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<Authorization[]> GetAuthorizationData(int userId);
    }
}