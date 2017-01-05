using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Labb_1.Models;
using Labb1_Data.Repositories;
using Labb1_Data.Interfaces;

using System.Security.Claims;
using Labb1_Data;

namespace Labb_1.Controllers
{
    public class CommentsController : Controller
    {
         ICommentRepository CommentRepository;
        // GET: Comments
        public CommentsController()
        {
            CommentRepository = new CommentRepo();
        }

        [HttpGet]
        public ActionResult GetComments(Guid imageId)
        {


            var comments = CommentRepository.GetCommentsForPhoto(imageId).Select(x => new Comment(x));
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
                var identity = User.Identity as ClaimsIdentity;
                if (identity != null)
                {                  
                    newComment.CommentId = Guid.NewGuid();
                    newComment.CommentDate = DateTime.Now;
                    if (User.Identity.IsAuthenticated)
                    {
                        newComment.commentedById = new Guid(identity.FindFirst(ClaimTypes.Sid).Value);
                    }
                    else
                    {
                        newComment.commentedById = new Guid();
                    }
                    newComment.photoId = photoId;
                }
                CommentRepository.Add(newComment.Transform());              
                ModelState.Clear();
                return PartialView();
            }
            else
            {
                return View(newComment);
            }
        }
      
        public ActionResult DeleteComment(Guid commentid, Guid photoId)
        {
            CommentRepository.Delete(commentid);
            return RedirectToAction("ShowImage", "Gallery",new {id = photoId});

        }
    }
}