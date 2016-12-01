using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Labb_1.Models;
using System.Security.Claims;

namespace Labb_1.Controllers
{
    public class AccountController : Controller
    {
        private static readonly DataAccess Db = new DataAccess();
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
        [ValidateAntiForgeryToken]
        public ActionResult Register(UserAccount account)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "You Did Something Wrong");
                return View(account);
            }

            account.UserID = Guid.NewGuid();
            Db.SaveUser(account);
      
            return View("Login");

        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserAccount user)
        {
            //get user logic       
            var usr = Db.LoginUser(user);

            if (usr != null)
            {
                var identity = new ClaimsIdentity(new[]
                 {
                    new Claim(ClaimTypes.Name, usr.Name),
                    new Claim(ClaimTypes.Email, usr.Email),
                    new Claim(ClaimTypes.Sid, usr.UserID.ToString()),
                    new Claim(ClaimTypes.NameIdentifier, usr.UserID.ToString()),
                    new Claim(ClaimTypes.Role, usr.Admin ? "Admin" : "User")

                },
                         "ApplicationCookie");

                var ctx = Request.GetOwinContext();
                var authManager = ctx.Authentication;



                authManager.SignIn(identity);

                return RedirectToAction("Index", "Home");

            }
            else
            {
                ModelState.AddModelError("", "UserName/Password is Invalid");
                return View();
            }

        }
        public ActionResult LogOut(string url)
        {
            var ctx = Request.GetOwinContext();
            var authManager = ctx.Authentication;

            authManager.SignOut("ApplicationCookie");
            return RedirectToAction("Login", "Account");
           
        }

        public ActionResult LoggedIn()
        {
            if (User.Identity.IsAuthenticated)
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

