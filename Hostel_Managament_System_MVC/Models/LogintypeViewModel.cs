using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hostel_Managament_System_MVC.Models
{
    public class LogintypeViewModel
    {
        [Required]
        public int USERTYPESID { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^([a-zA-Z0-9_\.]+@[a-z\.]+\.[com,in,co].{0,3})$", ErrorMessage = "Invalid Email ID,(Format : example@gmail.com)")]
        public string Email { get; set; }
        [Required]
        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$ %^&*-]).{8,}$", ErrorMessage = "Password Should be 8 characters long ,At list 1 uppercase char, 1 lowercase char , 1 number , 1 Special Char(#?!@$ %^&*-).")]
        public string Password { get; set; }
    }
}