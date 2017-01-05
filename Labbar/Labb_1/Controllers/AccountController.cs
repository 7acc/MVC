using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Labb_1.Models;
using Labb1_Data;
using Labb1_Data.Repositories;
using Labb1_Data.Interfaces;

using System.Security.Claims;

namespace Labb_1.Controllers
{
    public class AccountController : Controller
    {
        IUserRepository userRepository;
     
        // GET: Account
        public AccountController()
        {
            this.userRepository = new UserRepo();
        }

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
            UserAccountDataModel accountData = account.Transform();
            userRepository.Add(accountData);
      
            return RedirectToAction("Login");

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
            var usr = userRepository.LoginUser(user.Email, user.Password);

            if (usr != null)
            {
                var identity = new ClaimsIdentity(new[]
                 {
                    new Claim(ClaimTypes.Name, usr.Name),
                    new Claim(ClaimTypes.Email, usr.Email),
                    new Claim(ClaimTypes.Sid, usr.UserId.ToString()),
                    new Claim(ClaimTypes.NameIdentifier, usr.UserId.ToString()),
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
                return View("Login");
            }

        }
        [Authorize]
        public ActionResult LogOut(string url)
        {
            var ctx = Request.GetOwinContext();
            var authManager = ctx.Authentication;

            authManager.SignOut("ApplicationCookie");
            return RedirectToAction("Login", "Account");
           
        }
        [Authorize]
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

