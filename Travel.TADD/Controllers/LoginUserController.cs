using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Travel.TADD.Models;

namespace Travel.TADD.Controllers
{
    public class LoginUserController : Controller
    {
        // GET: LoginUser
           TADDEntities database = new TADDEntities();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginAccount(AdminUser _user)
        {

            var check = database.AdminUsers.Where(s => s.NameUser == _user.NameUser && s.PasswordUser == _user.PasswordUser).FirstOrDefault();

            if (check == null)
            {
                ViewBag.ErrorInfo = "SaiInfo";
                return View("Index");
            }          
            else
            {

                AdminUser idcheck = database.AdminUsers.Where(s => s.NameUser == _user.NameUser && s.PasswordUser == _user.PasswordUser).FirstOrDefault();
                if (idcheck == null)
                {
                    ViewBag.ErrorInfo = "Nhập sai tài khoản hoặc mật khẩu! ";
                    return View("Index");
                }
                else if (idcheck.RoleUser == "ad" && idcheck.RoleUser != null)
                {
                    return RedirectToAction("Index", "Product");
                }
                else
                {
                    database.Configuration.ValidateOnSaveEnabled = false;
                    Session["NameUser"] = idcheck.NameUser;
                    Session["PasswordUser"] = idcheck.PasswordUser;
                    return RedirectToAction("Home", "Home");
                }

            }
        }
        public ActionResult RegisterUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RegisterUser(AdminUser _user)
        {
            if (ModelState.IsValid)
            {
                var check_ID = database.AdminUsers.Where(s => s.ID == _user.ID || s.NameUser == _user.NameUser).FirstOrDefault();
                if (check_ID == null)
                {
                    database.Configuration.ValidateOnSaveEnabled = false;
                    int maxId = database.AdminUsers.Max(c => c.ID);
                    _user.ID = maxId + 1;
                    database.AdminUsers.Add(_user);
                    database.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.ErrorRegister = "ID hoặc tên đăng nhập đã được sử dụng!";
                    return View();
                }
            }
            return View();
        }
        public ActionResult LogOutUser()
        {
            Session.Abandon();
            return RedirectToAction("Index", "LoginUser");
        }
    }
}