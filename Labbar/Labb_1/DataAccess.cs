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
                var userToLogIn =
                    ctx.UsersAccounts.FirstOrDefault(x => x.Email == user.Email && x.Password == user.Password);
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

        public List<Photo> GetuserPhoto(Guid userId)
        {
            using (var ctx = new DataContext())
            {
                var list = ctx.Photos.Where(x => x.uploader == userId).ToList();
                return list;
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

        public void SaveComment(Guid photoId, Comment newComment)
        {
            using (var ctx = new DataContext())
            {
                var photo = ctx.Photos.Single(x => x.PhotoID == photoId);
                photo.Comments.Add(newComment);

                ctx.Comments.Add(newComment);
                ctx.SaveChanges();
            }
        }

        public UserAccount GetProfile(Guid userId)
        {
            using (var ctx = new DataContext())
            {
                var user =
                    ctx.UsersAccounts.Include("Albums").Include("Albums.Photos").FirstOrDefault(x => x.UserID == userId);
                return user;
            }
        }

        public void SavenewAlbum(Album newalbum, Guid[] photoIds, Guid userId)
        {
            using (var ctx = new DataContext())
            {
                var photoList = ctx.Photos.Where(x => photoIds.Contains(x.PhotoID)).ToList();
                foreach (var photo in photoList)
                {
                    newalbum.Photos.Add(photo);
                }
                var user = ctx.UsersAccounts.Single(x => x.UserID == userId);
                user.Albums.Add(newalbum);

                ctx.Albums.Add(newalbum);


                ctx.SaveChanges();
            }
        }

        public Album GetAlbum(Guid albumId)
        {
            using (var ctx = new DataContext())
            {
               var album = ctx.Albums.Include("Photos").FirstOrDefault(x => x.AlbumId == albumId);
                return album;
            }
        }
    }
}