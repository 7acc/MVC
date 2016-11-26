using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Labb_1.Models;

namespace Labb_1.Controllers
{
    public class CommentsController : Controller
    {
        private static DataAccess Db = new DataAccess();
        // GET: Comments
        public ActionResult Index()
        {

            return View();
        }
       [HttpGet]
        public ActionResult GetComments(Guid imageId)
        {
           
            var image = Db.GetImageById(imageId);
            var comments = image.Comments.OrderByDescending(x => x.CommentDate);
            return PartialView(comments);
        }

        public ActionResult PostComment()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult PostComment(Comment newComment, Guid photoId)
        {
            if (ModelState.IsValid)
            {             
                newComment.CommentId = Guid.NewGuid();
                newComment.CommentDate = DateTime.Now;

                Db.SaveComment(photoId, newComment);
                ModelState.Clear();
                return PartialView();
            }
            else
            {
                return View(newComment);
            }
        }
    }
}