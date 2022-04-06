using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hostel_Managament_System_MVC.Models
{
    public class UserTypeLogin
    {
        public Student student { get; set; }
        public Admin admin { get; set; }
        public PARENT pARENT{ get; set; }

    }
}