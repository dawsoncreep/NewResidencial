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
    using GS.Api.Types.Models.Persistence;

    /// <summary>
    /// The LocationRepository interface.
    /// </summary>
    public interface ILocationRepository : IRepository<SLocation>
    {
    }
}