using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Web;
using System.Web.Mvc;
using Labb_1.Models;

namespace Labb_1.Controllers
{
    public class GalleryController : Controller
    {
        private static DataAccess Db = new DataAccess();

        // GET: Gallery
        public ActionResult Index()
        {
            var ImageList = Db.GetGalleryPhotos();               
            return View(ImageList);
        }

        public ActionResult UpLoad()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UpLoad(Photo photo, HttpPostedFileBase image)
        {
            if (!ModelState.IsValid) { return View(photo); }
            if (image == null) { return View(photo); }

            photo.Url = "~/GalleryPhotos/" + image.FileName;
            photo.UploadedDate = DateTime.Now;
            photo.PhotoID = Guid.NewGuid();
            Db.SavePhoto(photo);

            image.SaveAs(Path.Combine(Server.MapPath("~/GalleryPhotos"), image.FileName));
            return RedirectToAction("Index");
        }
        public ActionResult ShowImage(Photo image)
        {
            //fick nått konstigt exeption när jag försökte skicka in "ImageUrl" i viewn för att sedan komma åt de via model.
            //så de fick bli viewbag sålänge, sålänge funktionen finns tänker jag^^
            
            return View(model: image);
        }
        public ActionResult Delete(Photo image)
        {
            string absolutePath = HttpContext.Server.MapPath(image.Url);
            if (System.IO.File.Exists(absolutePath))
            {
                System.IO.File.Delete(absolutePath);
                return RedirectToAction("Index");

            }
            else
            {

                return RedirectToAction("ShowImage", new { photo = image });
            }

        }

        //public PartialViewResult RecentUploads()
        //{
        //    if (Photos != null)
        //    {
        //        var list = Photos.OrderByDescending(x => x.UploadedDate)
        //            .Take(3)
        //            .ToList();
        //        ViewBag.list = list;
        //    }

        //        return PartialView();

        //}





    }
}
