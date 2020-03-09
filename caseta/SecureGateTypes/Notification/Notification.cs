using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureGateTypes
{
    public class Notification
    {
        public int Id { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public AspNetUser CreatedBy { get; set; }
        public DateTime UpdateAt { get; set; }
        public AspNetUser UpdateBy { get; set; }
        public DateTime DeletedAt { get; set; }
        public AspNetUser DeletedBy { get; set; }
        public int LocationUserNotification { get; set; }
        public string Message { get; set; }
        public bool Authorization { get; set; }
        public DateTime AwnserDate { get; set; }
        public AspNetUser ApplicationUserID { get; set; }
        public int ExternalBinnaclePhotoID { get; set; }
    }
}
