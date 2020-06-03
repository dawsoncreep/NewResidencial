using DataLayer;
using SecureGateTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class LocationProcessor
    {
        LocationRepository locationRepository;

        public LocationProcessor()
        {
            locationRepository = new LocationRepository();
        }

        public string[] GetLocationsString()
        {
            string[] locationString = locationRepository.GetLocationsString();
            return locationString;
        }

        public Location[] GetLocations()
        {
            Location[] locations = locationRepository.GetLocations();
            return locations;
        }

        internal Location GetLocation(int idUbicacion)
        {
            Location location = locationRepository.GetLocation(idUbicacion);
            return location;
        }

        internal IEnumerable<LocationUser> GetUserInLocation(Location location)
        {
            IEnumerable<LocationUser> locationUsers = locationRepository.GetLocationUsersByLocation(location);
            return locationUsers;
        }
    }
}
