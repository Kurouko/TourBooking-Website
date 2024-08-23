using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Travel.TADD.Models;
namespace Travel.TADD.Controllers
{
    public class DetailController : Controller
    {
        // GET: Detail
        TADDEntities database = new TADDEntities();
        public ActionResult Index(int id)
        {
            var _pro = database.Products.SingleOrDefault(s => s.ProductID == id);
            if (_pro.ProductID == 10)
                return RedirectToAction("AsiaPark", "Detail");
            if (_pro.ProductID == 11)
                return RedirectToAction("DaNang1", "Detail");
            if (_pro.ProductID == 13)
                return RedirectToAction("DaNang2", "Detail");
            if (_pro.ProductID == 14)
                return RedirectToAction("DaNang3", "Detail");
            if (_pro.ProductID == 17)
                return RedirectToAction("DaNang4", "Detail");
            if (_pro.ProductID == 21)
                return RedirectToAction("DaLat1", "Detail");
            if (_pro.ProductID == 23)
                return RedirectToAction("DaLat2", "Detail");
            if (_pro.ProductID == 22)
                return RedirectToAction("DaLat3", "Detail");
            if (_pro.ProductID == 31)
                return RedirectToAction("HCM1", "Detail");
            if (_pro.ProductID == 32)
                return RedirectToAction("HCM2", "Detail");
            if (_pro.ProductID == 33)
                return RedirectToAction("HCM3", "Detail");
            if (_pro.ProductID == 34)
                return RedirectToAction("HCM4", "Detail");
            if (_pro.ProductID == 35)
                return RedirectToAction("HN1", "Detail");
            if (_pro.ProductID == 36)
                return RedirectToAction("HN2", "Detail");
            if (_pro.ProductID == 15)
                return RedirectToAction("Nhatrang1", "Detail");
            if (_pro.ProductID == 18)
                return RedirectToAction("Nhatrang2", "Detail");
            if (_pro.ProductID == 19)
                return RedirectToAction("Nhatrang3", "Detail");
            if (_pro.ProductID == 20)
                return RedirectToAction("Nhatrang4", "Detail");
            if (_pro.ProductID == 27)
                return RedirectToAction("PhuQuoc1", "Detail");
            if (_pro.ProductID == 25)
                return RedirectToAction("PhuQuoc2", "Detail");
            if (_pro.ProductID == 28)
                return RedirectToAction("PhuQuoc2", "Detail");
            else return RedirectToAction("Home", "Home");
         
        }
    
        public ActionResult AsiaPark()
        {
               
            return View();
        }
        public ActionResult DaNang1()
        {

            return View();
        }
        public ActionResult DaNang2()
        {

            return View();
        }
        public ActionResult DaNang3()
        {

            return View();
        }
        public ActionResult DaNang4()
        {

            return View();
        }
        public ActionResult Nhatrang1()
        {

            return View();
        }
        public ActionResult Nhatrang2()
        {

            return View();
        }
        public ActionResult Nhatrang3()
        {

            return View();
        }
        public ActionResult Nhatrang4()
        {

            return View();
        }
        public ActionResult PhuQuoc1()
        {

            return View();
        }
        public ActionResult PhuQuoc2()
        {

            return View();
        }
        public ActionResult PhuQuoc3()
        {

            return View();
        }
        public ActionResult DaLat1()
        {

            return View();
        }
        public ActionResult DaLat2()
        {

            return View();
        }
        public ActionResult DaLat3()
        {

            return View();
        }
        public ActionResult HCM1()
        {

            return View();
        }
        public ActionResult HCM2()
        {

            return View();
        }
        public ActionResult HCM3()
        {

            return View();
        }
        public ActionResult HCM4()
        {

            return View();
        }
        public ActionResult HN1()
        {

            return View();
        }
        public ActionResult HN2()
        {

            return View();
        }
        public ActionResult VéVinWondersNhaTrang()
        {

            return View();
        }
    }
}