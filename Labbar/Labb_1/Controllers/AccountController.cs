using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Labb_1.Models;

namespace Labb_1.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserAccount account)
        {
            if (!ModelState.IsValid)
            {
                return View(account);
            }
            var Db = new DataAccess();
            account.UserID = new Guid();
            Db.SaveUser(account);


            ModelState.Clear();
            ViewBag.Message = account.Name + " Successfully registered";

            return View();

        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(UserAccount user)
        {
            //get user logic
            var Db = new DataAccess();
            var usr = Db.LoginUser(user);
            if (usr != null)
            {
                Session["UserID"] = usr.UserID.ToString();
                Session["UserName"] = usr.Name.ToString();
                Session["Admin"] = usr.Admin;
                return RedirectToAction("LoggedIn");
            }
            else
            {
                ModelState.AddModelError("", "UserName Or Password is Invalid");
                return View();
            }
          
        }

        public ActionResult LoggedIn()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    }
}
           
            