// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRolRepository.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the IRolRepository type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GuizzySeguridad.Common.Server.Interfaces.Repository
{
    using System.Threading.Tasks;

    using GuizzySeguridad.Common.Types.Models;

    /// <summary>
    /// The RoleRepository interface.
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