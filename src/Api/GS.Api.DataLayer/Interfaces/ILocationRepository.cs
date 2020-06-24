// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ILocationRepository.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the ILocationRepository type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GS.Api.DataLayer.Interfaces
{
    using GS.Api.Types.Models;
    using GS.Api.Types.Models.Persistence;
    using System.Threading.Tasks;

    /// <summary>
    /// The LocationRepository interface.
    /// </summary>
    public interface ILocationRepository : IRepository<SLocation>
    {
        Task<Location> FindById(int id);
    }
}