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
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public partial class Student
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Student()
        {
            this.FEES = new HashSet<FEE>();
            this.ROOM_MAPPING = new HashSet<ROOM_MAPPING>();
            this.PARENTS = new HashSet<PARENT>();
        }

        public int STUDENTID { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "The {0} value cannot exceed {1} characters. ")]
        [DataType(DataType.Text)]
        [RegularExpression("^([a-zA-Z]+[a-zA-Z])$", ErrorMessage = "Invalid First Name, Only Enter Alphabet Letter")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "The {0} value cannot exceed {1} characters. ")]
        [DataType(DataType.Text)]
        [RegularExpression("^([a-zA-Z]+[a-zA-Z])$", ErrorMessage = "Invalid Father Name, Only Enter Alphabet Letter")]
        public string FatherName { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "The {0} value cannot exceed {1} characters. ")]
        [DataType(DataType.Text)]
        [RegularExpression("^([a-zA-Z]+[a-zA-Z])$", ErrorMessage = "Invalid Last Name,  Only Enter Alphabet Letter")]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> DOB { get; set; }
        [Required]
        public string CurrentAddress { get; set; }
        [Required]
        public string PermanentAddress { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^([a-zA-Z0-9_\.]+@[a-z\.]+\.[com,in,co].{0,3})$", ErrorMessage = "Invalid Email ID,Format : example@gmail.com")]

        public string Email { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^(?:(?:\+|0{0,2})91(\s[\-]\s)?|[0]?)?[6789]\d{9}$", ErrorMessage = "Invalid Contact no, Only Enter Number")]
        public string Contactno { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^(?:(?:\+|0{0,2})91(\s[\-]\s)?|[0]?)?[6789]\d{9}$", ErrorMessage = "Invalid  Parent Contact no, Only Enter Number ")]

        public string Parent_Contactno { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$ %^&*-]).{8,}$", ErrorMessage = "Password Should be 8 characters long ,At list 1 uppercase char, 1 lowercase char , 1 number , 1 Special Char(#?!@$ %^&*-).")]
        public string Password { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FEE> FEES { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ROOM_MAPPING> ROOM_MAPPING { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PARENT> PARENTS { get; set; }

        
    }
}
