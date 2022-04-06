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
    public class Admin_ParentsController : Controller
    {
        private hostelprojectEntities db = new hostelprojectEntities();

        // GET: Admin_Parents
        public ActionResult Index( string search)
        {
            var model = db.PARENTS.Where(emp => emp.FirstName.StartsWith(search) || emp.LastName.StartsWith(search) || emp.Address.StartsWith(search)||emp.Email.StartsWith(search) || emp.Contactno.StartsWith(search) ||  search == null).ToList();
            return View(model);
            //var pARENTS = db.PARENTS.Include(p => p.Student);
            //return View(pARENTS.ToList());
        }

        // GET: Admin_Parents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PARENT pARENT = db.PARENTS.Find(id);
            if (pARENT == null)
            {
                return HttpNotFound();
            }
            return View(pARENT);
        }

        // GET: Admin_Parents/Create
        public ActionResult Create()
        {
            ViewBag.STUDENTID = new SelectList(db.Students, "STUDENTID", "FirstName");
            return View();
        }

        // POST: Admin_Parents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PARENTSID,FirstName,LastName,Address,Email,Contactno,STUDENTID,Password")] PARENT pARENT)
        {
            if (ModelState.IsValid)
            {
                db.PARENTS.Add(pARENT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.STUDENTID = new SelectList(db.Students, "STUDENTID", "FirstName", pARENT.STUDENTID);
            return View(pARENT);
        }

        // GET: Admin_Parents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PARENT pARENT = db.PARENTS.Find(id);
            if (pARENT == null)
            {
                return HttpNotFound();
            }
            ViewBag.STUDENTID = new SelectList(db.Students, "STUDENTID", "FirstName", pARENT.STUDENTID);
            return View(pARENT);
        }

        // POST: Admin_Parents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PARENTSID,FirstName,LastName,Address,Email,Contactno,STUDENTID,Password")] PARENT pARENT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pARENT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.STUDENTID = new SelectList(db.Students, "STUDENTID", "FirstName", pARENT.STUDENTID);
            return View(pARENT);
        }

        // GET: Admin_Parents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PARENT pARENT = db.PARENTS.Find(id);
            if (pARENT == null)
            {
                return HttpNotFound();
            }
            return View(pARENT);
        }

        // POST: Admin_Parents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PARENT pARENT = db.PARENTS.Find(id);
            db.PARENTS.Remove(pARENT);
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
            var model = db.PARENTS.Where(emp => emp.FirstName.StartsWith(search) || emp.LastName.StartsWith(search) || emp.Address.StartsWith(search) || emp.Email.StartsWith(search) || emp.Contactno.StartsWith(search) || search == null).ToList();
            return View(model);
            //var pARENTS = db.PARENTS.Include(p => p.Student);
            //return View(pARENTS.ToList());
        }
       
    }
}
