using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Labb_1.Models;

namespace Labb_1.Controllers
{
    public class ProfileController : Controller
    {
        private static DataAccess db = new DataAccess();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UserProfile(Guid userId)
        {
            var user = db.GetProfile(userId);
            return View(user);
        }
    }
}