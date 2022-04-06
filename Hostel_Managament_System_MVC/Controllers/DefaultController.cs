using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hostel_Managament_System_MVC.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        
        public ActionResult Indexxx()
        {
            Session["FirstName"] = "l";
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult Fees()
        {
            return View();
        }
        public ActionResult Foodmenu()
        {
            return View();
        }
        public ActionResult Annoucement()
        {
            return View();
        }
        
        public ActionResult Rule()
        {
            return View();
        }
    }
}