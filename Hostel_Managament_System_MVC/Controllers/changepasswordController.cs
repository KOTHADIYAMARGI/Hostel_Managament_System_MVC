using Hostel_Managament_System_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hostel_Managament_System_MVC.Controllers
{
    public class changepasswordController : Controller
    {
        private hostelprojectEntities db = new hostelprojectEntities();
        // GET: changepassword
        public ActionResult ChangePassword()
        {
            

                return View();
        }


        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordViewModel login)
        {
            var details = db.Students.Where(x => x.Password == login.Password).FirstOrDefault();
            if (details!=null)
            {
                var abc = db.Students.FirstOrDefault(x => x.Email == login.Email);
                if (abc!=null)
                {
                    abc.Password = login.NewPassword;
                    db.SaveChanges();
                    ViewBag.Message = "Record Inserted Successfully!";
                }
                else
                {
                    ViewBag.Message = "Password not Updated!";
                }
            }
            else
            {
                ViewBag.Message = "Your CurrentPassword is wrong, Please reset again!";
            }

            return View(login);
           
        }

    }
}