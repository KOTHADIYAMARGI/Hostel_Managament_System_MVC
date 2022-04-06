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
    public class StudentEntriesController : Controller
    {
        string applatitude = Properties.Settings.Default["latitude"].ToString();
        string applongitude = Properties.Settings.Default["longitude1"].ToString();
        private hostelprojectEntities db = new hostelprojectEntities();

        // GET: StudentEntries
        public ActionResult Index()
        {
            return View(db.StudentEntries.ToList());
        }

        // GET: StudentEntries/Details/5
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

        // GET: StudentEntries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentEntries/Create
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

        // GET: StudentEntries/Edit/5
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

        // POST: StudentEntries/Edit/5
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

        // GET: StudentEntries/Delete/5
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

        // POST: StudentEntries/Delete/5
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

       
        public ActionResult StudentDetails(StudentEntry studentEntry)
        {
            try
            {
                var user = Session["FirstName"].ToString();
                var p = db.StudentEntries.Where(m => m.StudentName == user).ToList();
                return View(p);
            }
            catch (Exception)
            {
                TempData["error"] = "Something Wrong Please try again";
                return View();
            }
        }
        //public ActionResult Student_Entry()
        //{
        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Student_Entry(StudentEntry studentEntry)
        //{
        //    List<Student> student = db.Students.ToList();
        //    List<StudentEntry> studentEntries = db.StudentEntries.ToList();
        //    int p = Convert.ToInt32(Session["UserID"]);
        //    var InvoiceList = from om in student
        //                      join cm in studentEntries on om.STUDENTID equals cm.STUDENTID
        //                      where om.STUDENTID == p

        //                      select new ViewModel
        //                      {
        //                          student = om,
        //                          studentEntry = cm

        //                      };
        //    foreach (var item in InvoiceList)
        //    {
        //        Session["ID"] = item.studentEntry.ID;
        //        Session["STUDENTID"] = item.studentEntry.STUDENTID;
        //        Session["Date"] = item.studentEntry.Date;
        //        Session["OUTTIME"] = item.studentEntry.OUTTIME;
        //        Session["INTIME"] = item.studentEntry.INTIME;
        //        Session["latitude"] = item.studentEntry.latitude;
        //        Session["longitude"] = item.studentEntry.longitude;
        //    }
            //try
            //{
            //if (studentEntry.latitude == applatitude && studentEntry.longitude == applongitude)
            //{

            //    //var exists = db.StudentEntries.Any(x =>x.ID ==studentEntry.ID && x.Date == studentEntry.Date);
            //    int y = Convert.ToInt32(Session["STUDENTID"]);
            //    var exists = db.StudentEntries.Any(x => x.Date == studentEntry.Date && x.STUDENTID==y);
               
            //    if (exists)
            //    {
            //        var d = db.StudentEntries.Where(x => x.STUDENTID == y && x.Date == studentEntry.Date).SingleOrDefault();

            //        //int p = Convert.ToInt32(Session["UserID"]);
            //        //int f = d.STUDENTID;

                   
            //        var id = db.StudentEntries.Find(studentEntry.ID);
            //        id.STUDENTID = studentEntry.STUDENTID;
            //        id.StudentName = studentEntry.StudentName;
            //        id.Date = studentEntry.Date;
            //        id.OUTTIME = studentEntry.OUTTIME;
            //        id.INTIME = studentEntry.INTIME;
            //        id.latitude = studentEntry.latitude;
            //        id.longitude = studentEntry.longitude;
            //        //id.INTIME = studentEntry.INTIME;
            //        db.Entry(id).State = EntityState.Modified;
            //        db.SaveChanges();
            //        // Session["Message"] = "Student Update succesfully";
            //        return RedirectToAction("StudentDetails", "StudentEntries");

            //        //return View();
            //        //db.Entry(studentEntry).State = EntityState.Modified;
            //        //db.SaveChanges();
            //        //Session["Message"] = "Student Update succesfully";
            //        ////return RedirectToAction("Index");

            //    }
            //    else
            //    {
            //        db.StudentEntries.Add(studentEntry);
            //        db.SaveChanges();
            //        Session["Message"] = "Student Entry succesfully";
            //        //return RedirectToAction("Index");
            //        return View();
            //    }

            //}
            //else
            //{
            //    Session["Message"] = "Your location are not in hostel area!";
            //    return View(studentEntry);
            //}
            ////}
            ////catch (Exception)
            ////{
            ////    TempData["error"] = "Something Wrong Please try again";
            ////    return View();
            ////}


        }


    }

