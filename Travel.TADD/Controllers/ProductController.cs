using Travel.TADD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using PagedList;
using PagedList.Mvc;

namespace Travel.TADD.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult SearchOption(double min = double.MinValue, double max = double.MaxValue)
        {
            var list = database.Products.Where(p => (double)p.Price >= min && (double)p.Price <= max).ToList();
            return View(list);
        }
        TADDEntities database = new TADDEntities();
        public ActionResult Index(string category, int? page, double min = double.MinValue, double max = double.MaxValue)
        {
            int pageSize = 5;
            int pageNum = (page ?? 1);
            if (category == null)
            {
                var productList = database.Products.OrderByDescending(x => x.NamePro);
                return View(productList.ToPagedList(pageNum, pageSize));
            }
            else
            {
                var productList = database.Products.OrderByDescending(x => x.NamePro).Where(x => x.Category == category);
                return View(productList);
            }
        }
        public ActionResult Create()
        {
            List<Category> list = database.Categories.ToList();
            ViewBag.listCategory = new SelectList(list, "IDCate", "NameCate", "");
            Product pro = new Product();
            return View(pro);
        }
        public ActionResult SelectCate()
        {
            Category se_cate = new Category();
            se_cate.ListCate = database.Categories.ToList<Category>();
            return PartialView(se_cate);
        }
        [HttpPost]
        public ActionResult Create(Product pro)
        {
            try
            {
                if (pro.UploadImage != null)
                {
                    var fileName = Path.GetFileName(pro.UploadImage.FileName);
                    var path = Path.Combine(Server.MapPath("~/Images"), fileName);
                    pro.ImagePro = fileName;
                       
                }
                database.Products.Add(pro);
                database.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Details(int id)
        {
            return View(database.Categories.Where(s => s.Id == id).FirstOrDefault());
        }
        public ActionResult Edit(int id)
        {

            List<Category> list = database.Categories.ToList();
            ViewBag.listCategory = new SelectList(list, "IDCate", "NameCate", "");

            return View(database.Categories.Where(s => s.Id == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Edit(int id, Product pro)
        {
     
            database.Entry(pro).State = System.Data.Entity.EntityState.Modified;
            database.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            return View(database.Products.Where(s => s.ProductID == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Delete(int id, Product pro)
        {
            try
            {
                pro = database.Products.Where(s => s.ProductID == id).FirstOrDefault();
                database.Products.Remove(pro);
                database.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return Content("This data is using in other table, Error Delete!");
            }
        }
        //public ViewResult GetPro()
        //{
        //    List<Product> list = database.Products.ToList();
        //    //Where(s => s.NameCate == "DaNang").
        //    ViewBag.DaNang = list;
        //    return View();
        //}

    }
}