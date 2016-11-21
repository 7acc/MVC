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
                var photolist = ctx.Photos.ToList();
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
    }
}