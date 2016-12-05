using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using Labb1_Data.Interfaces;

namespace Labb1_Data.Repositories
{
    public class PhotoRepo :IPhotoRepository
    {
        /*
          using (var ctx = new Context())
           {
                
           }
*/
        public IEnumerable<PhotoDataModel> GetAll()
        {
            using (var ctx = new TheContext())
            {
                return ctx.Photos.Include("Comments").Include("Albums").ToList();
            }
        }

        public void Add(PhotoDataModel Photo)
        {
            using (var ctx = new TheContext())
            {
                var existingPhoto = ctx.Photos.FirstOrDefault(x => x.PhotoID == Photo.PhotoID);
                if (existingPhoto == null)
                {
                    ctx.Photos.Add(Photo);
                    ctx.SaveChanges();
                }
                else
                {
                    existingPhoto.Update(Photo);
                    ctx.Entry(existingPhoto).State = EntityState.Modified;
                    ctx.SaveChanges();
                }
            }

        }

        public void Delete(Guid id)
        {
            using (var ctx = new TheContext())
            {
                var photoToBeDeleted = ctx.Photos.FirstOrDefault(x => x.PhotoID == id);
                if (photoToBeDeleted != null)
                {
                    ctx.Photos.Remove(photoToBeDeleted);
                    ctx.SaveChanges();
                }

            }

        }

        public PhotoDataModel GetById(Guid id)
        {
            using (var ctx = new TheContext())
            {
                return ctx.Photos.Include("Comments").Include("Albums").FirstOrDefault(x => x.PhotoID == id);
            }
        }

        public IEnumerable<PhotoDataModel> GetUserPhoto(Guid userId)
        {
            using (var ctx = new TheContext())
            {
                var list = ctx.Photos.Include("Albums").Include("Comments").Where(x => x.uploader == userId).ToList();
                return list;
            }
        }

        public IEnumerable<PhotoDataModel> GetRecentUploads(int count)
        {
            using (var ctx = new TheContext())
            {
                var list = ctx.Photos.Include("Comments").Include("Albums").OrderByDescending(x => x.UploadedDate)
                    .Take(count)
                    .ToList();
                return list;
            }
        }

      
    }
}
