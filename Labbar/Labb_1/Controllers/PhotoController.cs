using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Labb1_Data;
using Labb1_Data.Interfaces;
using Labb1_Data.Repositories;
using Labb_1.Models;
using Microsoft.AspNet.Identity;

namespace Labb_1.Controllers
{
    public class PhotoController : Controller
    {
        IPhotoRepository PhotoRepository;

        public PhotoController()
        {
            PhotoRepository = new PhotoRepo();
        }

        public ActionResult Index()
        {
            return View();
        }
        [Authorize]
        public ActionResult GetUserPhotosSelector(Guid userId)
        {
            var listOfPhotos = PhotoRepository.GetUserPhoto(userId).Select(x => new Photo(x)).ToList();             
            return PartialView(listOfPhotos);
        }
        [Authorize]
        public ActionResult GetExcludedPhotoSelector(Guid userId, Guid albumId )
        {
            var albumrepo = new AlbumRepo();
            var albumphotos = albumrepo.GetAlbumPhotos(albumId);
           
            var listOfPhotos = PhotoRepository.GetUserPhoto(userId).Select(x => new Photo(x)).ToList();

            var excludedList = listOfPhotos.Where(p => albumphotos.All(x => x.PhotoID != p.PhotoID)).ToList();
            return PartialView("GetUserPhotosSelector",excludedList);
        }
        [Authorize]
        public ActionResult UploadPhoto()
        {
            return PartialView();
        }
        [HttpPost]
        [Authorize]
        public ActionResult UploadPhoto(Photo photo, HttpPostedFileBase imageFile)
        {
            if (!ModelState.IsValid) { return View(photo); }
            if (imageFile == null) { return View(photo); }

            photo.Url = "~/GalleryPhotos/" + imageFile.FileName;
            photo.UploadedDate = DateTime.Now;
            photo.PhotoID = Guid.NewGuid();
            if (User.Identity.IsAuthenticated)
            {
                photo.uploader = new Guid(User.Identity.GetUserId());
            }
            var photoData = photo.Transform();
            PhotoRepository.Add(photoData);

            imageFile.SaveAs(Path.Combine(Server.MapPath("~/GalleryPhotos"), imageFile.FileName));

            return PartialView();
        }
    }
}