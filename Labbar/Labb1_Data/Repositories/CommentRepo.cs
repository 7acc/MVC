using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Labb1_Data.Interfaces;

namespace Labb1_Data.Repositories
{
    public class CommentRepo : ICommentRepository
    { 
        public IEnumerable<CommentDataModel> GetAll()
        {
            using (var ctx = new TheContext())
            {
                return ctx.Comments.ToList();
            }
        }

        public void Add(CommentDataModel comment)
        {
            using (var ctx = new TheContext())
            {

                {
                    var ExistingComment = ctx.Comments.FirstOrDefault(x => x.CommentId == comment.CommentId);
                    if (ExistingComment == null)
                    {
                        ctx.Comments.Add(comment);
                        ctx.SaveChanges();
                    }
                    else
                    {
                        ExistingComment.Update(comment);
                        ctx.Entry(ExistingComment).State = EntityState.Modified;
                        ctx.SaveChanges();
                    }
                }
            }
        }

        public void Delete(Guid id)
        {
            using (var ctx = new TheContext())
            {
                var CommentToBeDeleted = ctx.Comments.FirstOrDefault(x => x.CommentId == id);
                if (CommentToBeDeleted != null)
                {
                    ctx.Comments.Remove(CommentToBeDeleted);
                    ctx.SaveChanges();
                }
            }
        }

        public CommentDataModel GetById(Guid id)
        {
            using (var ctx = new TheContext())
            {
                return ctx.Comments.FirstOrDefault(x => x.CommentId == id);
            }
        }

        public IEnumerable<CommentDataModel> GetCommentsForPhoto(Guid imageId)
        {
            using (var ctx = new TheContext())
            {
                return ctx.Comments.Where(x => x.PhotoId == imageId).ToList();

            }
        }
    }
}
