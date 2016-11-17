using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Labb_1.Models;

namespace Labb_1.Controllers
{
    public class GalleryController : Controller
    {
        private static IList<string> ImageList;
        // GET: Gallery
        public ActionResult Index()
        {
            ImageList =
                Directory.EnumerateFiles(Server.MapPath("~/GalleryPhotos"))
                    .Select(x => "~/GalleryPhotos/" + Path.GetFileName(x)).ToList();
            return View(ImageList);
        }

        public ActionResult UpLoad()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UpLoad(Photo photo, HttpPostedFileBase image)
        {
            if (!ModelState.IsValid){return View(photo);}
            if (image == null){return View(photo);}

            image.SaveAs(Path.Combine(Server.MapPath("~/GalleryPhotos"), image.FileName));
            return View("Index");
        }


    }
}
