    using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Travel.TADD.Models;
namespace Travel.TADD.Controllers
{
    public class HomeController : Controller
    {
        TADDEntities database = new TADDEntities();
        public ActionResult Index()
        {
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
        public ActionResult Home()
        {
            return View(database.Products.ToList());
        }
        public ActionResult DaNang1()
        {
            return View();
        }
    }
}