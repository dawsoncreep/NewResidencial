
using DataLayer;
using SecureGateTypes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class EventProcessor
    {
        private readonly EventRepository eventRepository;
        private readonly NotificationProcessor notificationProcessor;
        private readonly LocationProcessor locationProcessor;
        public EventProcessor()
        {
            eventRepository = new EventRepository();
            notificationProcessor = new NotificationProcessor();
            locationProcessor = new LocationProcessor();
        }

        public EventType[] GetEventTypes()
        {
            EventType[] eventTypes = eventRepository.GetEventTypes();
            return eventTypes;
        }

        public bool SolicitarAcceso(Bitmap rostro, Bitmap placaT, Bitmap placaD, Bitmap credencial, Location location, 
            string nombre, string Apellidos, EventType evento)
        {
            bool enEspera = false;            
            notificationProcessor.SetNotification(location);
            return enEspera;
        }
    }
}
