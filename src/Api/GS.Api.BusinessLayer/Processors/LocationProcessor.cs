// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LocationProcessor.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the LocationProcessor type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GS.Api.BusinessLayer.Processors
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Transactions;

    using GS.Api.DataLayer.Interfaces;
    using GS.Api.Types.Exceptions;
    using GS.Api.Types.Models;

    /// <summary>
    /// The location processor.
    /// </summary>
    public class LocationProcessor
    {
        /// <summary>
        /// The location repository.
        /// </summary>
        private ILocationRepository locationRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="LocationProcessor"/> class.
        /// </summary>
        /// <param name="locationRepository">
        /// The location repository.
        /// </param>
        public LocationProcessor(ILocationRepository locationRepository)
        {
            this.locationRepository = locationRepository;
        }

        /// <summary>
        /// The get user locations.
        /// </summary>
        /// <param name="userId">
        /// The user id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public async Task<IEnumerable<Location>> GetUserLocations(int userId)
        {
            try
            {
                if (userId == 0)
                {
                    return null;
                }

                var x = await this.locationRepository.FindAsync(item => item.Id == userId);
                return new List<Location> { new Location { Id = 1, Nombre = "Circuito Canarias 114" } };
            }
            catch (Exception exception)
            {
                throw new DevelopmentException(exception);
            }
        }

        public async Task<Location> GetLocationById(int locationId)
        {
            var location = await this.locationRepository.FindById(locationId);
            return await Task.FromResult(location);

        }
    }
}