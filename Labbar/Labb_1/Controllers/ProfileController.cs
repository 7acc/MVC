using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Labb_1.Models;
using System.Security.Claims;

namespace Labb_1.Controllers
{
    public class ProfileController : Controller
    {
        private static DataAccess db = new DataAccess();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UserProfile()
        {
            if (User.Identity.IsAuthenticated)
            {
                var identity = User.Identity as ClaimsIdentity;
                var id = new Guid(identity.FindFirst(ClaimTypes.Sid).Value);

                var user = db.GetProfile(id);

                if(user != null)
                {
                    return View(user);
                }                               
            }      
                            
                return RedirectToAction("Login", "Account");            
        }
    }
}