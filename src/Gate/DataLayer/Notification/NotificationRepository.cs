using SecureGateTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class NotificationRepository
    {        

        public void SetNotification(IEnumerable<LocationUser> locUsers, string message)
        {
            using (var context = new SecureGateEntities())
            {
                Nullable<DateTime> date = DateTime.Now;
                var netrepo = new AspNetUserRepository();
                var localUser = netrepo.GetUser();
                foreach (var lu in locUsers)
                {
                    if (context.LocationUserNotifications.FirstOrDefault(f => f.ApplicationUser_Id == lu.ApplicationUserId.Id).Permision)
                    {
                        Notifications notification = new Notifications()
                        {
                            CreatedBy = localUser.Id,
                            CreatedAt = date,
                            LocationUserNotification_Id = lu.Id,
                            Message = message
                        };
                        context.Notifications.Add(notification);
                    }
                }
                context.SaveChanges();
            }
        }

        public bool ReceiveNotification(Location location)
        {
            bool recibe;
            using (var context = new SecureGateEntities())
            {
                recibe = context.LocationUserNotifications.Any(a => a.AspNetUsers.Locations.Any(x => x.Id == location.ID) && a.Permision == true);
            }
            return recibe;
        }
    }
}
