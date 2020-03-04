using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureGateTypes
{
    public class LocationUserNotiofication
    {
        public int Id { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public AspNetUser CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public AspNetUser Updatedby { get; set; }
        public DateTime DeletedAt { get; set; }
        public AspNetUser DeletedBy { get; set; }
        public bool Permision { get; set; }
        public AspNetUser ApplicationUserID { get; set; }
    }
}
