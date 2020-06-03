using DataLayer;
using SecureGateTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class NotificationProcessor
    {
        private readonly NotificationRepository notificationRepository;
        private readonly LocationRepository locationRepository;
        public NotificationProcessor()
        {
            notificationRepository = new NotificationRepository();
            locationRepository = new LocationRepository();
        }

        internal bool SetNotification(Location location)
        {
            try
            {
                var locationUsers = locationRepository.GetLocationUsersByLocation(location);
                notificationRepository.SetNotification(locationUsers,"mensaje");
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }            
        }
    }
}
