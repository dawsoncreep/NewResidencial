using SecureGateTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class EventRepository
    {
        public EventRepository()
        {

        }

        public EventType[] GetEventTypes()
        {
            EventType[] tipos;
            using (var context = new SecureGateEntities())
            {
                tipos = context.EventTypes.Select(s => new EventType {Descripcion = s.Description, Id = s.Id,
                    LigadoAExterno = s.IsTiedToExternalUser }).ToArray();
            }
            return tipos;
        }

        public void CreateEventAccess(Event evento)
        {

        }
    }
}
