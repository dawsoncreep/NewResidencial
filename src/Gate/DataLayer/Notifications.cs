//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class Notifications
    {
        public int Id { get; set; }
        public bool Deleted { get; set; }
        public Nullable<System.DateTime> CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> DeletedAt { get; set; }
        public string DeletedBy { get; set; }
        public Nullable<int> LocationUserNotification_Id { get; set; }
        public string Message { get; set; }
        public bool Authorization { get; set; }
        public Nullable<System.DateTime> AwnserDate { get; set; }
        public string ApplicationUser_Id { get; set; }
        public Nullable<int> ExternalBinnaclePhoto_Id { get; set; }
    
        public virtual AspNetUsers AspNetUsers { get; set; }
        public virtual AspNetUsers AspNetUsers1 { get; set; }
        public virtual AspNetUsers AspNetUsers2 { get; set; }
        public virtual LocationUserNotifications LocationUserNotifications { get; set; }
        public virtual AspNetUsers AspNetUsers3 { get; set; }
        public virtual ExternalBinnaclePhotoes ExternalBinnaclePhotoes { get; set; }
    }
}