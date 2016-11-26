using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Labb_1.Models;

namespace Labb_1.Controllers
{
    public class AlbumController : Controller
    {
        private static readonly DataAccess Db = new DataAccess();
        // GET: Album
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateAlbum()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateAlbum(Album newalbum, Guid[] photoIds)
        {
            if (!ModelState.IsValid) { return View(newalbum); }
            if (photoIds.Count() < 1) { return View(newalbum); }

            newalbum.AlbumId = Guid.NewGuid();
            newalbum.DateCreated = DateTime.Now;
            Db.SavenewAlbum(newalbum, photoIds, (Guid)Session["UserID"]);


            return View();
        }

        public ActionResult ViewAlbum(Guid albumId)
        {
            var album = Db.GetAlbum(albumId);
            return View(album);
        }
    }
}