using Hostel_Managament_System_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace Hostel_Managament_System_MVC.Controllers
{
    public class LoginController : Controller
    {
        private readonly hostelprojectEntities db = new hostelprojectEntities();
        // GET: Login
        public ActionResult Loginn()
        {
            Session["FirstName"] = "l";
            ViewBag.USERTYPESID = new SelectList(db.USERTYPES, "USERTYPESID", "USERTYPESNAME");
            //user

            return View();
        }


        [HttpPost]
        public ActionResult Loginn(LogintypeViewModel logintypeViewModel)
        {
            try
            {
 
                Session["Typesss"] = Convert.ToInt32(logintypeViewModel.USERTYPESID);
                if (logintypeViewModel.USERTYPESID == 1)
                {
                    var user = db.Students.Where(m => m.Email == logintypeViewModel.Email && m.Password == logintypeViewModel.Password).FirstOrDefault();

                    if (user != null)
                    {

                        var s = db.PARENTS.Where(x => x.STUDENTID == user.STUDENTID).FirstOrDefault();
                        Session["pmail"] = s.Email;
                        Session["UserID"] = user.STUDENTID;
                        Session["FirstName"] = user.FirstName;
                        Session["Fathername"] = user.FatherName;
                        Session["lastname"] = user.LastName;
                        Session["DOB"] = user.DOB;
                        Session["CurrentAddress"] = user.CurrentAddress;
                        Session["PermanentAddress"] = user.PermanentAddress;
                        Session["Email"] = user.Email;
                        Session["Contactno"] = user.Contactno;
                        Session["Parent_Contactno"] = user.Parent_Contactno;
                        Session["Password"] = user.Password;
                        //TempData["error"] = "Login Successfully"; 

                        return RedirectToAction("Student_Entry", "EntryStudent");
                    }
                    else
                    {
                        ModelState.Clear();
                        TempData["error"] = "Invalid Email or Password";
                        return RedirectToAction("Loginn", "Login");
                    }

                }
                else if (logintypeViewModel.USERTYPESID == 2)
                {
                    var Adminn = db.Admins.Where(m => m.Email == logintypeViewModel.Email && m.Password == logintypeViewModel.Password).FirstOrDefault();

                    if (Adminn != null)
                    {

                        Session["AdminID"] = Adminn.AdminID;
                        Session["FirstName"] = Adminn.FirstName;
                        Session["Email"] = Adminn.Email;
                        Session["Password"] = Adminn.Password;
                        //TempData["error"] = "Login Successfully";
                        return RedirectToAction("Index", "AdminPage");
                    }
                    else
                    {
                        ModelState.Clear();
                        TempData["error"] = "Invalid Email or Password";
                        return RedirectToAction("Loginn", "Login");
                    }


                }
                else if (logintypeViewModel.USERTYPESID == 3)
                {
                    var PARENTSs = db.PARENTS.Where(m => m.Email == logintypeViewModel.Email && m.Password == logintypeViewModel.Password).FirstOrDefault();

                    if (PARENTSs != null)
                    {

                        Session["PARENTSID"] = PARENTSs.PARENTSID;
                        Session["FirstName"] = PARENTSs.FirstName;
                        Session["LastName"] = PARENTSs.LastName;
                        Session["Address"] = PARENTSs.Address;
                        Session["Email"] = PARENTSs.Email;
                        Session["Contactno"] = PARENTSs.Contactno;
                        Session["STUDENTID"] = PARENTSs.STUDENTID;
                        Session["Password"] = PARENTSs.Password;

                        //TempData["error"] = "Login Successfully";
                        return RedirectToAction("StudentAdttendance", "PARENTs");
                    }
                    else
                    {
                        ModelState.Clear();
                        TempData["error"] = "Invalid Email or Password";
                        return RedirectToAction("Loginn", "Login");
                    }
                }
                else
                {
                    ModelState.Clear();
                    TempData["error"] = "Invalid Email or Password";
                    return RedirectToAction("Loginn", "Login");
                }
            }
            catch (Exception)
            {
                TempData["error"] = "Something Wrong Please try again";
                return RedirectToAction("Loginn", "Login");
            }
        }



    }
}