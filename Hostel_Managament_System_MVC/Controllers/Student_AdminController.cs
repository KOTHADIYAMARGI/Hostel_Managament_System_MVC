using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using Hostel_Managament_System_MVC.Models;
using PagedList;

namespace Hostel_Managament_System_MVC.Controllers
{
    public class Student_AdminController : Controller
    {
        private hostelprojectEntities db = new hostelprojectEntities();

        // GET: Student_Admin
        public ActionResult Index(string search)
        {
            var model = db.Students.Where(emp => emp.FirstName.StartsWith(search) || emp.FatherName.StartsWith(search) || emp.LastName.StartsWith(search) || emp.PermanentAddress.StartsWith(search) || emp.CurrentAddress.StartsWith(search) || emp.Email.StartsWith(search) || emp.Contactno.StartsWith(search) || emp.Parent_Contactno.StartsWith(search) || search == null).ToList();
            return View(model);
            //return View(db.Students.ToList());
        }

        // GET: Student_Admin/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Student_Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student_Admin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
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

        // GET: Student_Admin/Edit/5
        public ActionResult Edit(int? id)
        {
            
            Student student = db.Students.Find(id);
            Session["DOB"] = student.DOB.Value.ToShortDateString();
          
            return View(student);
        }

      
        [HttpPost]
     
        public ActionResult Edit([Bind(Include = "STUDENTID,FirstName,FatherName,LastName,DOB,CurrentAddress,PermanentAddress,Email,Contactno,Parent_Contactno,Password")] Student student)
        {

            if (ModelState.IsValid)
            {

                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // GET: Student_Admin/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Student_Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public ActionResult Listofview(string search)
        {
            var model = db.Students.Where(emp => emp.FirstName.StartsWith(search) || emp.FatherName.StartsWith(search) || emp.LastName.StartsWith(search) || emp.PermanentAddress.StartsWith(search) || emp.CurrentAddress.StartsWith(search) || emp.Email.StartsWith(search) || emp.Contactno.StartsWith(search) || emp.Parent_Contactno.StartsWith(search) || search == null).ToList();
            return View(model);

            //return View(db.Students.ToList());
        }
        //public ActionResult DeleteSudent()
        //{
        //    return View(db.Students.ToList());
        //}
        //public ActionResult EditeStudent()
        //{
        //    return View(db.Students.ToList());
        //}
        public ActionResult example()
        {
            return View(db.Students.ToList());
            //return View(db.Students.ToList());
        }



    }
}
