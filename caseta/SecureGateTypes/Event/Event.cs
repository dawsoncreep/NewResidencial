using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureGateTypes
{
    public class Event
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public AspNetUser CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public AspNetUser UpdatedBy { get; set; }
        public int BinnacleID { get; set; }
        public int EventLocation_Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public EventType EventTypeId { get; set; }
        public Location LocationId { get; set; }
    }
}
