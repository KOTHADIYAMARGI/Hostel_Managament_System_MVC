using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hostel_Managament_System_MVC.Models
{
    public class login
    {
        public int USERTYPE { get; set; }
        [Required]
        public int STUDENTID { get; set; }
        [Required]
        [RegularExpression(@"^(?:(?:\+|0{0,2})91(\s[\-]\s)?|[0]?)?[6789]\d{9}$", ErrorMessage = "Invalid Contactno (Format :7410258963)")]
        public string Email { get; set; }
        [Required]
        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$ %^&*-]).{5,8}$", ErrorMessage = "Invalid password format (Format :Exam@12)")]
        public string Password { get; set; }
    }
}