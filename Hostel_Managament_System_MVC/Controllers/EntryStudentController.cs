using Hostel_Managament_System_MVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace Hostel_Managament_System_MVC.Controllers
{
    public class EntryStudentController : Controller
    {
        string applatitude = Properties.Settings.Default["latitude"].ToString();
        string applongitude = Properties.Settings.Default["longitude1"].ToString();
        private hostelprojectEntities db = new hostelprojectEntities();
        // GET: EntryStudent
        public ActionResult StudentDetails(StudentEntry studentEntry)
        {
            try
            {
                //var user = Session["FirstName"].ToString();

                int UserID = Convert.ToInt32(Session["UserID"]);
                var p = db.StudentEntries.Where(m => m.STUDENTID == UserID).ToList();
               

                DateTime dtFrom = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                DateTime dtTo = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
              
                
               var g= p.Where(x => x.Date >= dtFrom && x.Date <= dtTo).ToList();
                //var ff = db.StudentEntries.Where(x => x.Date == d).ToList();
                return View(g);
               
            }
            catch (Exception)
            {
                TempData["error"] = "Something Wrong Please try again";
                return View();
            }
        }
        public ActionResult Student_Entry()
        {
            int id = Convert.ToInt32(Session["UserID"]);
            var dateTime = DateTime.Now.Date;
            var p = db.StudentEntries.Where(x => x.STUDENTID == id && x.Date== dateTime).FirstOrDefault();

            if (p!=null)
            {
                Session["outtime"] = p.OUTTIME;
                Session["Inintimetime"] = p.INTIME;
                return View();
            }
               
           return View();
        }

        [HttpPost]

        public ActionResult Student_Entry(StudentEntry studentEntryy)
        {
           
            List<Student> student = db.Students.ToList();
            List<StudentEntry> studentEntries = db.StudentEntries.ToList();
           

            int p = Convert.ToInt32(Session["UserID"]);
           var pp = db.PARENTS.Where(x=>x.STUDENTID==p).FirstOrDefault();
           var hh = pp.FirstName.ToString();

            var InvoiceList = from om in student
                              join cm in studentEntries on om.STUDENTID equals cm.STUDENTID
                              where om.STUDENTID == p

                              select new ViewModel
                              {
                                  student = om,
                                  studentEntry = cm

                              };
            foreach (var item in InvoiceList)
            {
                Session["ID"] = item.studentEntry.ID;
                Session["STUDENTID"] = item.studentEntry.STUDENTID;
                Session["Date"] = item.studentEntry.Date;
                Session["OUTTIME"] = item.studentEntry.OUTTIME;
                Session["INTIME"] = item.studentEntry.INTIME;
                Session["latitude"] = item.studentEntry.latitude;
                Session["longitude"] = item.studentEntry.longitude;
            }
            try
            {
                if (studentEntryy.latitude == applatitude && studentEntryy.longitude == applongitude)
                {

                    //var exists = db.StudentEntries.Any(x =>x.ID ==studentEntry.ID && x.Date == studentEntry.Date);
                    int y = Convert.ToInt32(Session["STUDENTID"]);
                    var exists = db.StudentEntries.Any(x => x.Date == studentEntryy.Date && x.STUDENTID == studentEntryy.STUDENTID);

                    if (exists)
                    {
                        var d = db.StudentEntries.Where(x => x.STUDENTID == y && x.Date == studentEntryy.Date).SingleOrDefault();
                        if (studentEntryy.INTIME>studentEntryy.OUTTIME)
                        {

                     
                        //int p = Convert.ToInt32(Session["UserID"]);
                        //int f = d.STUDENTID;
                        int o = d.ID;

                        var id = db.StudentEntries.Find(o);

                        id.INTIME = studentEntryy.INTIME;

                        db.Entry(id).State = EntityState.Modified;
                        db.SaveChanges();
                   
                        Session["out"] = id.OUTTIME;
                        Session["in"] = id.INTIME;
                        Session["Messag"]= "Your Child Enrty Time:";
                        var a = Session["in"].ToString();
                        var b = Session["out"].ToString();
                        var fname=Session["FirstName"];
                       var lname= Session["LastName"];
                        

                        MailModel mailModel = new MailModel();
                        mailModel.To = Session["pmail"].ToString();
                        mailModel.From = "gamimahipat888@gmail.com";
                        mailModel.Subject = "Entry Time ";
                       
                        mailModel.Body = "Dear " +hh+
                            ", <br/><br/>Name :" + fname + " " + lname +
                            "<br/>Your Child OutTime is : " + b +
                            "<br/>and InTime is : " + a;
                            
                       
                        MailMessage mail = new MailMessage();
                        mail.To.Add(mailModel.To);    //customere Email
                        mail.From = new MailAddress(mailModel.From);   //admin Email
                        mail.Subject = mailModel.Subject;
                        string Body = mailModel.Body;
                        mail.Body = Body;
                        mail.IsBodyHtml = true;
                        SmtpClient smtp = new SmtpClient();
                        smtp.Host = "smtp.gmail.com";
                        smtp.Port = 587;
                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = new System.Net.NetworkCredential("gamimahipat888@gmail.com", "Gami@123");
                        smtp.EnableSsl = true;


                        smtp.Send(mail);
                        Session["Message"] = "Student Entry succesfully";
                        return RedirectToAction("StudentDetails", "EntryStudent");

                        }
                        else
                        {
                            TempData["error"] = "Your InTime Not Correct";
                            return View(studentEntryy);
                        }

                    }
                    else
                    {
                        db.StudentEntries.Add(studentEntryy);
                        db.SaveChanges();
                        //TempData["error"] = "Student Entry succesfully";
                        //return RedirectToAction("Index");
                        return RedirectToAction("StudentDetails", "EntryStudent");
                        //return View();
                    }

                }
                else
                {
                    TempData["error"] = "Your location are not in hostel area!";
                    return View(studentEntryy);
                }
            }
            catch (Exception)
            {
                TempData["error"] = "Something Wrong Please try again";
                return View();
            }


        }

    }
}