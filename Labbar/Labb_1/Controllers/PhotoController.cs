using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Labb_1.Models;

namespace Labb_1.Controllers
{
    public class PhotoController : Controller
    {
        private static DataAccess Db = new DataAccess();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetUserPhotosSelector(Guid userId)
        {
            var listOfPhotos = Db.GetuserPhoto(userId);
            return PartialView(listOfPhotos);
        }
    }
}