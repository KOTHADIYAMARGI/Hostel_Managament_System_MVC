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
    public class PARENTsController : Controller
    {
        private hostelprojectEntities db = new hostelprojectEntities();

        public ActionResult PerentStudetn()
        {
            int s = Convert.ToInt32(Session["STUDENTID"]);
            int p = Convert.ToInt32(Session["PARENTSID"]);

            var list = db.Students.Where(x => x.STUDENTID == s).ToList();

            return View(list);
        }
        public ActionResult StudentAdttendance()
        {
            try
            {
                int a = Convert.ToInt32(Session["STUDENTID"]);

                var list = db.StudentEntries.Where(x => x.STUDENTID == a).ToList();
                DateTime dtFrom = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                DateTime dtTo = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

                var g = list.Where(x => x.Date >= dtFrom && x.Date <= dtTo).ToList();
                //var ff = db.StudentEntries.Where(x => x.Date == d).ToList();
                return View(g);

            }
            catch (Exception)
            {
                TempData["error"] = "Something Wrong Please try again";
                return View();
            }
        }
        // GET: PARENTs
        public ActionResult Index()
        {
            var pARENTS = db.PARENTS.Include(p => p.Student);
            return View(pARENTS.ToList());
        }

        // GET: PARENTs/Details/5
        public ActionResult Details(int? id)
        {
           
            PARENT pARENT = db.PARENTS.Find(id);
            
            return View(pARENT);
        }

        // GET: PARENTs/Create
        public ActionResult Create()
        {
            ViewBag.STUDENTID = new SelectList(db.Students, "STUDENTID", "FirstName");
            return View();
        }


        //[HttpPost]
        //public ActionResult Create([Bind(Include = "PARENTSID,FirstName,LastName,Address,Email,Contactno,STUDENTID,Password")] PARENT pARENT)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.PARENTS.Add(pARENT);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.STUDENTID = new SelectList(db.Students, "STUDENTID", "FirstName", pARENT.STUDENTID);
        //    return View(pARENT);
        //}

        // GET: PARENTs/Edit/5
        public ActionResult Edit(int? id)
        {


            PARENT pARENT = db.PARENTS.Find(id);
            //Session["STUDENTID"] = pARENT.STUDENTID;

            ViewBag.STUDENTID = new SelectList(db.Students, "STUDENTID", "FirstName", pARENT.STUDENTID);
            return View(pARENT);
        }


        [HttpPost]

        public ActionResult Edit([Bind(Include = "PARENTSID,FirstName,LastName,Address,Email,Contactno,STUDENTID,Password")] PARENT pARENT)
        {
            bool e = true;
            e = db.PARENTS.Any(x => x.Email == pARENT.Email && x.PARENTSID != pARENT.PARENTSID);

            if (e == false)
            {

                var p = db.PARENTS.Any(x => x.Password == pARENT.Password);

                if (p)

                {

                    if (ModelState.IsValid)
                    {
                        db.Entry(pARENT).State = EntityState.Modified;
                        db.SaveChanges();
                        return RedirectToAction("pEdit", "PARENTs");
                    }
                    else
                    {
                        ModelState.Clear();
                        ViewBag.STUDENTID = new SelectList(db.Students, "STUDENTID", "FirstName", pARENT.STUDENTID);
                        return View(pARENT);
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

        // GET: PARENTs/Delete/5

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult ParentsRegistration()
        {
            //int id = Convert.ToInt32(Session["UserID"]);
            var row = db.Students.ToList().LastOrDefault();
            int id = row.STUDENTID;
            var p = db.Students.Where(x => x.STUDENTID == id).FirstOrDefault();

            if (p != null)
            {
                Session["FatherstName"] = p.FatherName;
                Session["FtName"] = p.FirstName;
                Session["LastttName"] = p.LastName;
                Session["id"] = p.STUDENTID;
                Session["no"] = p.Parent_Contactno;

                return View();
            }

            ViewBag.STUDENTID = new SelectList(db.Students, "STUDENTID", "FirstName");
            return View();
        }



        [HttpPost]

        public ActionResult ParentsRegistration([Bind(Include = "PARENTSID,FirstName,LastName,Address,Email,Contactno,STUDENTID,Password")] PARENT pARENT)
        {
            try
            {
                var exists = db.PARENTS.Any(x => x.Email == pARENT.Email);

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
                        db.PARENTS.Add(pARENT);
                        db.SaveChanges();
                        return RedirectToAction("Loginn", "Login");

                    }
                    ModelState.Clear();
                    ViewBag.STUDENTID = new SelectList(db.Students, "STUDENTID", "FirstName", pARENT.STUDENTID);
                    return View(pARENT);
                }

            }
            catch (Exception)
            {
                ModelState.Clear();
                TempData["error"] = "Something Wrong Please try again";
                return View();
            }


        }

        public ActionResult pEdit(PARENT pARENT)
        {
            try
            {
                //var user = Session["Email"].ToString();
                int id = Convert.ToInt32(Session["PARENTSID"]);
                //var user = Session["Email"].ToString();
                var p = db.PARENTS.Where(m => m.PARENTSID == id).ToList();
                return View(p);
            }
            catch (Exception)
            {
                TempData["error"] = "Something Wrong Please try again";
                return View();
            }
        }
    }


}

