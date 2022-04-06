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
    public class Admin_StaffController : Controller
    {
        private hostelprojectEntities db = new hostelprojectEntities();

        // GET: Admin_Staff
        public ActionResult Index(string search)
        {
            var model = db.Staffs.Where(emp => emp.FirstName.StartsWith(search) || emp.LastName.StartsWith(search) || emp.Address.StartsWith(search) ||  emp.Email.StartsWith(search) || emp.Contactno.StartsWith(search) || search == null).ToList();
            return View(model);
            //return View(db.Staffs.ToList());
        }

        // GET: Admin_Staff/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Staff staff = db.Staffs.Find(id);
            if (staff == null)
            {
                return HttpNotFound();
            }
            return View(staff);
        }

        // GET: Admin_Staff/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin_Staff/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StaffID,FirstName,LastName,Address,Email,Contactno,Password")] Staff staff)
        {
            if (ModelState.IsValid)
            {
                db.Staffs.Add(staff);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(staff);
        }

        // GET: Admin_Staff/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Staff staff = db.Staffs.Find(id);
            if (staff == null)
            {
                return HttpNotFound();
            }
            return View(staff);
        }

        // POST: Admin_Staff/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StaffID,FirstName,LastName,Address,Email,Contactno,Password")] Staff staff)
        {
            if (ModelState.IsValid)
            {
                db.Entry(staff).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(staff);
        }

        // GET: Admin_Staff/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Staff staff = db.Staffs.Find(id);
            if (staff == null)
            {
                return HttpNotFound();
            }
            return View(staff);
        }

        // POST: Admin_Staff/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Staff staff = db.Staffs.Find(id);
            db.Staffs.Remove(staff);
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
            //if (Searchby == "StudentName")
            //{
            //    var model = db.StudentEntries.Where(emp => emp.StudentName == search || search == null).ToList();
            //    return View(model);

            //}
              var model = db.Staffs.Where(emp => emp.FirstName.StartsWith(search) || emp.LastName.StartsWith(search) || emp.Address.StartsWith(search) || emp.Email.StartsWith(search) || emp.Contactno.StartsWith(search) || search == null).ToList();
                return View(model);
            
            //return View(db.Staffs.ToList());
        }
       
    }
}
