//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Hostel_Managament_System_MVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ROOM_MAPPING
    {
        public int ROOM_MAPPINGID { get; set; }
        public Nullable<int> ROOMID { get; set; }
        public Nullable<int> STUDENTID { get; set; }
    
        public virtual ROOM ROOM { get; set; }
        public virtual Student Student { get; set; }
    }
}
