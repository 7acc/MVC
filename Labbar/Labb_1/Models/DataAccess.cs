using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Labb_1.Models
{
    public class DataAccess
    {

        public void SaveUser(UserAccount user)
        {
            using (var ctx = new DataContext())
            {
                ctx.UsersAccounts.Add(user);
                ctx.SaveChanges();
            }
        }

        public UserAccount LoginUser(UserAccount user)
        {
            using (var ctx = new DataContext())
            {
                var userToLogIn = ctx.UsersAccounts.FirstOrDefault(x => x.Email == user.Email && x.Password == user.Password);
                return userToLogIn;
            }
        }

        public List<Photo> GetGalleryPhotos()
        {
            using (var ctx = new DataContext())
            {
                var photolist = ctx.Photos.Include("Comments").ToList<Photo>();
                return photolist;
            }
        }

        public void SavePhoto(Photo newPhoto)
        {
            using (var ctx = new DataContext())
            {
                ctx.Photos.Add(newPhoto);
                ctx.SaveChanges();
            }
        }

        internal Photo GetImageById(Guid id)
        {

            using (var ctx = new DataContext())
            {
                var image = ctx.Photos.Include("Comments").Include("Comments.commentedBy").Single(x => x.PhotoID == id);
                return image;
            }
        }

        internal object GetRecentUploads(int count)
        {
            using (var ctx = new DataContext())
            {
                var list = ctx.Photos.OrderByDescending(x => x.UploadedDate)
                          .Take(count)
                          .ToList();
                return list;
            }
        }

        internal void RemoveImage(Photo image)
        {
            using (var ctx = new DataContext())
            {
                ctx.Photos.Attach(image);
                ctx.Photos.Remove(image);
                ctx.SaveChanges();
            }
        }
    }
}