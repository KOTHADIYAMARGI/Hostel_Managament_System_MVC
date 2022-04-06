using Hostel_Managament_System_MVC.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hostel_Managament_System_MVC.Controllers
{
    public class AdminPageController : Controller
    {
        private hostelprojectEntities db = new hostelprojectEntities();
        // GET: AdminPage
        public ActionResult Index()
        {
            var studentcount = db.Students.ToList().Count();
            Session["Students"] = studentcount;

            var TotalStaff = db.Staffs.ToList().Count();
            Session["Staffs"] = TotalStaff;

            var TotalParents = db.PARENTS.ToList().Count();
            Session["PARENTS"] = TotalParents;

            var TotalStudentEntry = db.StudentEntries.ToList().Count();
            Session["Entry"] = TotalStudentEntry;

            return View();
        }
        //public void ProcessDirectory(string targetDirectory)
        //{
        //    // Process the list of files found in the directory.
        //    string[] fileEntries = Directory.GetFiles(targetDirectory);
        //    foreach (string fileName in fileEntries)
        //    {
        //        string found = ProcessFile(fileName);
        //    }
        //    //Recursive loop through subdirectories of this directory.
        //    string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
        //    foreach (string subdirectory in subdirectoryEntries)
        //    {
        //        ProcessDirectory(subdirectory);
        //    }
        //}


    }
}