using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using SecureGateTypes;

namespace DataLayer
{
    public class LocationRepository
    {
        public LocationRepository()
        {
        }

        public SecureGateTypes.Location[] GetLocations()
        {
            SecureGateTypes.Location[] locations;
            using (var context = new SecureGateEntities())
            {
                locations = context.Locations.Select(s => new SecureGateTypes.Location() {
                    ID = s.Id,
                    Descripcion = s.Description,
                    Nombre = s.Name,
                    NumeroExterno = s.OutNumber,
                    NumeroInterno = s.InNumber,
                    Calle = s.Street
                }).ToArray();
            }
            return locations;
        }

        public Location GetLocation(int idUbicacion)
        {
            Location location;
            using (var context = new SecureGateEntities())
            {
                location = context.Locations.Select(x => new Location() {
                    ID = x.Id,
                    Calle = x.Street,
                    Descripcion = x.Description,
                    Nombre = x.Name,
                    NumeroExterno = x.OutNumber,
                    NumeroInterno = x.InNumber
                }).Single(s => s.ID == idUbicacion);
            }
            return location;
        }

        public string[] GetLocationsString()
        {
            IEnumerable<Location> locations;
            string[] locationString;
            using (var context = new SecureGateEntities())
            {
                locations = context.Locations.Select(s => new SecureGateTypes.Location()
                {
                    ID = s.Id,
                    Descripcion = s.Description,
                    Nombre = s.Name,
                    NumeroExterno = s.OutNumber,
                    NumeroInterno = s.InNumber,
                    Calle = s.Street
                });
                int i = 0;
                locationString = new string[locations.Count()];
                foreach (var item in locations)
                {
                    locationString[i] = item.LocationStr;
                }
            }
            return locationString;
        }

        public IEnumerable<LocationUser> GetLocationUsersByLocation(Location location)
        {
            using (var context = new SecureGateEntities())
            {
                var LocationUsers = context.LocationUsers.Where(w => w.Location_Id == location.ID).Select(s => new LocationUser()
                {
                    ApplicationUserId = new AspNetUser { Id = s.ApplicationUser_Id },
                    Id = s.Id,
                    LocationID = new Location { ID = (int)s.Location_Id }
                }).ToList();
                return LocationUsers; 
            }
        }

    }
}
