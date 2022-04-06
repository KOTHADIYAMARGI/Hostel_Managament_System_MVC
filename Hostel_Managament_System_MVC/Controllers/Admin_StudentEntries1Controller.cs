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
    public class Admin_StudentEntries1Controller : Controller
    {
        private hostelprojectEntities db = new hostelprojectEntities();

        // GET: Admin_StudentEntries1
        public ActionResult Index()
        {
            return View(db.StudentEntries.ToList());
        }

        // GET: Admin_StudentEntries1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentEntry studentEntry = db.StudentEntries.Find(id);
            if (studentEntry == null)
            {
                return HttpNotFound();
            }
            return View(studentEntry);
        }

        // GET: Admin_StudentEntries1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin_StudentEntries1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,StudentName,Date,OUTTIME,INTIME,latitude,longitude,STUDENTID")] StudentEntry studentEntry)
        {
            if (ModelState.IsValid)
            {
                db.StudentEntries.Add(studentEntry);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(studentEntry);
        }

        // GET: Admin_StudentEntries1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentEntry studentEntry = db.StudentEntries.Find(id);
            if (studentEntry == null)
            {
                return HttpNotFound();
            }
            return View(studentEntry);
        }

        // POST: Admin_StudentEntries1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,StudentName,Date,OUTTIME,INTIME,latitude,longitude,STUDENTID")] StudentEntry studentEntry)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentEntry).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(studentEntry);
        }

        // GET: Admin_StudentEntries1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentEntry studentEntry = db.StudentEntries.Find(id);
            if (studentEntry == null)
            {
                return HttpNotFound();
            }
            return View(studentEntry);
        }

        // POST: Admin_StudentEntries1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentEntry studentEntry = db.StudentEntries.Find(id);
            db.StudentEntries.Remove(studentEntry);
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
            
                var model = db.StudentEntries.Where(emp => emp.StudentName.StartsWith(search) || search == null).ToList();
                return View(model);
            
        }

    }
}
