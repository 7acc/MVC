using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Labb1_Data.Interfaces;

namespace Labb1_Data.Repositories
{
    public class AlbumRepo : IAlbumRepository
    {
       
        public IEnumerable<AlbumDatamodel> GetAll()
        {
            using (var ctx = new TheContext())
            {
                return ctx.Albums.ToList();
            }
        }

        public void Add(AlbumDatamodel album)
        {
            using (var ctx = new TheContext())
            {
                var existingAlbum = ctx.Albums.FirstOrDefault(x => x.AlbumID == album.AlbumID);
                if (existingAlbum == null)
                {
                    ctx.Albums.Add(album);
                    ctx.SaveChanges();
                }
                else
                {
                    existingAlbum.Update(album);
                    ctx.Entry(existingAlbum).State = EntityState.Modified;
                    ctx.SaveChanges();
                }
            }
        }

        public void Delete(Guid id)
        {
            using (var ctx = new TheContext())
            {
                var albumToBeDeleted = ctx.Albums.FirstOrDefault(x => x.AlbumID == id);
                if (albumToBeDeleted != null)
                {
                    ctx.Albums.Remove(albumToBeDeleted);
                    ctx.SaveChanges();
                }
            }
        }

        public AlbumDatamodel GetById(Guid id)
        {
            using (var ctx = new TheContext())
            {
                return ctx.Albums.Include("Photos").FirstOrDefault(x => x.AlbumID == id);
            }
        }
        public void SavenewAlbum(AlbumDatamodel newalbum, Guid[] photoIds, Guid userId)
        {
            using (var ctx = new TheContext())
            {
                var photoList = ctx.Photos.Where(x => photoIds.Contains(x.PhotoID)).ToList();
                foreach (var photo in photoList)
                {
                    newalbum.Photos.Add(photo);
                }
                var user = ctx.UsersAccounts.Single(x => x.UserId == userId);
                user.Albums.Add(newalbum);

                ctx.Albums.Add(newalbum);


                ctx.SaveChanges();
            }
        }

        public IEnumerable<PhotoDataModel> GetAlbumPhotos(Guid albumId)
        {
            using (var ctx = new TheContext())
            {
                var album = ctx.Albums.Include("Photos").FirstOrDefault(x => x.AlbumID == albumId);
                var photos = album.Photos.ToList();
                return photos;
            }
        }

        public void SavePhotosToAlbum(Guid albumId, Guid[] photoIds)
        {
            using (var ctx = new TheContext())
            {
                var album = GetById(albumId);
                var photoList = ctx.Photos.Include("Albums").Where(x => photoIds.Contains(x.PhotoID)).ToList();
                ctx.Albums.Attach(album);
                foreach (var photoDataModel in photoList)
                {
                    album.Photos.Add(photoDataModel);
                }
             
                ctx.Entry(album).State = EntityState.Modified;
 
                ctx.SaveChanges();
            }
        }
    }
}
