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
        private static DataAccess Db = new DataAccess();
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
         
            account.UserID = Guid.NewGuid();
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
                ModelState.AddModelError("", "UserName/Password is Invalid");
                return View();
            }
          
        }
        public ActionResult LogOut(string url)
        {
            Session.Clear();
            return Redirect(url);
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
           
            