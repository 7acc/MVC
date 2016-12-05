using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Web;
using System.Web.Mvc;
using Labb1_Data;
using Labb_1.Models;
using Labb1_Data.Repositories;
using Labb1_Data.Interfaces;
using Microsoft.AspNet.Identity;

namespace Labb_1.Controllers
{
    public class GalleryController : Controller
    {
        IPhotoRepository PhotoRepository;

     
        public GalleryController()
        {
            PhotoRepository = new PhotoRepo();
        }

        // GET: Gallery
        public ActionResult Index()
        {
            var imageList = PhotoRepository.GetAll().Select(x => new Photo(x)).ToList();        
            return View(imageList);
        }

        public ActionResult UpLoad()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpLoad(Photo photo, HttpPostedFileBase image)
        {
            if (!ModelState.IsValid) { return View(photo); }
            if (image == null) { return View(photo); }

            photo.Url = "~/GalleryPhotos/" + image.FileName;
            photo.UploadedDate = DateTime.Now;
            photo.PhotoID = Guid.NewGuid();
            if (User.Identity.IsAuthenticated)
            {
                photo.uploader = new Guid(User.Identity.GetUserId());
            }
            var photoData = photo.Transform();
            PhotoRepository.Add(photoData);

            image.SaveAs(Path.Combine(Server.MapPath("~/GalleryPhotos"), image.FileName));
            return RedirectToAction("Index");
        }
        public ActionResult ShowImage(Guid id)
        {
            var image = new Photo(PhotoRepository.GetById(id));
             
            return View(model: image);
        }
        public ActionResult Delete(Guid imageId)
        {
            var image = new Photo(PhotoRepository.GetById(imageId));
            string absolutePath = HttpContext.Server.MapPath(image.Url);
            if (System.IO.File.Exists(absolutePath))
            {
               PhotoRepository.Delete(imageId);
                System.IO.File.Delete(absolutePath);             
                return RedirectToAction("Index");            
            }
            else
            {
                return RedirectToAction("ShowImage", new { photo = image });
            }
        }

        public PartialViewResult RecentUploads()
        {
            var list = PhotoRepository.GetRecentUploads(3).Select(x => new Photo(x)).ToList();
             
            return PartialView(model: list);

        }





    }
}
