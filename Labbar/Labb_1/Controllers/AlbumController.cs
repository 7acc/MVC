using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Labb_1.Models;
using Labb1_Data.Interfaces;
using Labb1_Data;
using Labb1_Data.Repositories;
using Labb_1.Migrations;
using Microsoft.AspNet.Identity;

namespace Labb_1.Controllers
{
    public class AlbumController : Controller
    {
     IAlbumRepository  albumRepository;

        public AlbumController()
        {
            this.albumRepository = new AlbumRepo();
        }

        // GET: Album
        public ActionResult Index()
        {
            return View();
        }
        [Authorize]
        public ActionResult CreateAlbum()
        {
            return View();
        }
        [HttpPost]
        [Authorize]
        public ActionResult CreateAlbum(Album newalbum, Guid[] photoIds)
        {
            if (!ModelState.IsValid) { return View(newalbum); }
            if (photoIds == null || photoIds.Count() < 1) { return View(newalbum); }

            newalbum.AlbumId = Guid.NewGuid();
            newalbum.DateCreated = DateTime.Now;
            AlbumDatamodel albumData = newalbum.Transform();
            albumRepository.SavenewAlbum(albumData, photoIds, new Guid(User.Identity.GetUserId()));;


            return RedirectToAction("ViewAlbum", new {albumId = newalbum.AlbumId});
        }

        public ActionResult ViewAlbum(Guid albumId)
        {

            

            var album = new Album(albumRepository.GetById(albumId));
            album.Photos = albumRepository.GetAlbumPhotos(album.AlbumId).Select(x => new Photo(x)).ToList();
            if(User.Identity.IsAuthenticated)
            { 
            album.CanBeEdited = CanEdit(new Guid(User.Identity.GetUserId()), albumId);
            }
            else
            {
                album.CanBeEdited = false;
            }


            return View(album);
        }
    
        [HttpPost]
        [Authorize]        
        public ActionResult DeletePhotosFromAlbum(Guid albumId, Guid[] photoIds)
        {
            return RedirectToAction("ViewAlbum", albumId);
        }

        [Authorize]
        [HttpGet]
        public ActionResult AddPhotosToAlbum(Guid albumId)
        {
            var album = new Album(albumRepository.GetById(albumId));
            return PartialView(album);
        }


        [HttpPost]
        [Authorize]       
        public ActionResult AddPhotosToAlbum(Guid albumId, Guid[] photoIds)
        {

            albumRepository.SavePhotosToAlbum(albumId, photoIds);
            return RedirectToAction("ViewAlbum", new {albumId = albumId});
        }

        public ActionResult ViewAlbumSlider(Album album)
        {
           //album.Photos = albumRepository.GetAlbumPhotos(album.AlbumId).ToList()
            return PartialView(album);
        }

        public bool CanEdit(Guid UserId, Guid AlbumId)
        {
           var userRepo = new UserRepo();
            var userAblums = userRepo.GetUserAlbums(UserId);

            if (userAblums.Any(x => x.AlbumID == AlbumId))
            {
                return true;
            }
            return false;
        }
        [Authorize]
        public ActionResult RemoveAlbum(Guid albumid)
        {
            albumRepository.Delete(albumid);
            return RedirectToAction("UserProfile", "Profile");
        }
    }
}