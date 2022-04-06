using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hostel_Managament_System_MVC.Controllers
{
    public class HomeController : Controller
    {
       
        public ActionResult Index()
        {
            Session["FirstName"] = "l";
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Facility()
        {
            ViewBag.Message = "Your Facility page.";

            return View();
        }
        public ActionResult FoodMenu()
        {
            ViewBag.Message = "Your FoodMenu page.";

            return View();
        }
        public ActionResult Fees()
        {
            ViewBag.Message = "Your Fees page.";

            return View();
        }
        public ActionResult Annoucement()
        {
            ViewBag.Message = "Your Annoucement page.";

            return View();
        }
    }
}