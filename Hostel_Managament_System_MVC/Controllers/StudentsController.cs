using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Hostel_Managament_System_MVC.Models;

namespace Hostel_Managament_System_MVC.Controllers
{
    public class StudentsController : Controller
    {
        private hostelprojectEntities db = new hostelprojectEntities();

        // GET: Students
        public ActionResult Index()
        {
            return View(db.Students.ToList());
        }

        // GET: Students/Details/5
        public ActionResult Details(int? id)
        {

            Student student = db.Students.Find(id);

            return View(student);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]

        public ActionResult Create([Bind(Include = "STUDENTID,FirstName,FatherName,LastName,DOB,CurrentAddress,PermanentAddress,Email,Contactno,Parent_Contactno,Password")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(student);
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int? id)
        {


            Student student = db.Students.Find(id);
            Session["date"] = student.DOB.Value.ToShortDateString();
            Session["pwd"] = student.Password;

            return View(student);
        }


        [HttpPost]
        public ActionResult Edit(Student student)
        {
            bool e = true;
            e = db.Students.Any(x => x.Email == student.Email && x.STUDENTID != student.STUDENTID);

            if (e == false)
            {

                var p = db.Students.Any(x => x.Password == student.Password);

                if (p)

                {

                    if (ModelState.IsValid)
                    {
                        db.Entry(student).State = EntityState.Modified;
                        db.SaveChanges();
                        return RedirectToAction("StudentDetails", "Students");
                    }
                    else
                    {
                        ModelState.Clear();
                        return View(student);
                    }

                }
                else
                {
                    TempData["error"] = "Your Password is worng! ";

                    return View();
                }


            }
            else
            {
                return View();
            }


        }

     

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public ActionResult Registration()
        {
            return View();
        }



        [HttpPost]
     
        public ActionResult Registration([Bind(Include = "STUDENTID,FirstName,FatherName,LastName,DOB,CurrentAddress,PermanentAddress,Email,Contactno,Parent_Contactno,Password")] Student student)
        {
            try
            {
                var exists = db.Students.Any(x => x.Email == student.Email);

                if (exists)
                {
                    TempData["error"] = "You are Allready exists ";
                    //return RedirectToAction("Loginn", "Login");
                    return View();
                }
                else
                {
                    if (ModelState.IsValid)
                    {
                        Session["Fname"] = student.FatherName;


                        db.Students.Add(student);
                        db.SaveChanges();
                        //Session["Msg"] = "Registration succesfully";
                        return RedirectToAction("ParentsRegistration", "PARENTs");
                    }
                    else
                    {
                        ModelState.Clear();
                        return View(student);
                    }

                }

            }
            catch (Exception)
            {
                TempData["error"] = "Something Wrong Please try again";
                return View();
            }
        }


        public ActionResult StudentDetails()
        {
            try
            {
                int id = Convert.ToInt32(Session["UserID"]);
                var user = Session["Email"].ToString();
                var p = db.Students.Where(m => m.STUDENTID == id).ToList();
                return View(p);
            }
            catch (Exception)
            {
                TempData["error"] = "Something Wrong Please try again";
                return View();
            }
        }

        //public JsonResult IsUserEmailAvailable(String Email)
        //{
        //    //Dbmodel dbmodel = new Dbmodel();

        //    Student uSERDETAIL = new Student();

        //    using (var context = new hostelprojectEntities())
        //    {
        //        uSERDETAIL = context.Students.Where(a => a.Email.ToLower() == Email.ToLower()).FirstOrDefault();
        //    }
        //    bool status;
        //    if (uSERDETAIL != null)
        //    {
        //        status = false;
        //    }
        //    else
        //    {
        //        status = true;
        //    }
        //    return Json(status, JsonRequestBehavior.AllowGet);
        //}

    }
}
