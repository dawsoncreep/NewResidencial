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
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using GS.Api.Types.Models;
    using GS.Api.Types.Models.Persistence;

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

        Task<SRol> GetRolByName(string name);

        Task CreateUserRol(SUserRol userRol);

        Task<IEnumerable<SRol>> GetAllRols();
    }
}