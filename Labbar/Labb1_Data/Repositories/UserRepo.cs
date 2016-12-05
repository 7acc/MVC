using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Labb1_Data.Interfaces;

namespace Labb1_Data.Repositories
{
    public class UserRepo : IUserRepository
    {
        public IEnumerable<UserAccountDataModel> GetAll()
        {
            using (var ctx = new TheContext())
            {
                return ctx.UsersAccounts.ToList();
            }
        }
        public void Add(UserAccountDataModel user)
        {
            using (var ctx = new TheContext())
            {
                var existingUser = ctx.UsersAccounts.FirstOrDefault(x => x.UserId == user.UserId);
                if (existingUser == null)
                {
                    ctx.UsersAccounts.Add(user);
                    ctx.SaveChanges();
                }
                else
                {

                    existingUser.Update(user);
                    ctx.Entry(existingUser).State = EntityState.Modified;
                    ctx.SaveChanges();

                }
            }
        }

        public void Delete(Guid userId)
        {
            using (var ctx = new TheContext())
            {
                var userToBeDeeleted = ctx.UsersAccounts.FirstOrDefault(x => x.UserId == userId);
                if (userToBeDeeleted != null)
                {
                    ctx.UsersAccounts.Remove(userToBeDeeleted);
                    ctx.SaveChanges();
                }
            }
        }

        public UserAccountDataModel LoginUser(string Email, string Password)
        {
            using (var ctx = new TheContext())
            {
                return ctx.UsersAccounts.FirstOrDefault(x => x.Email == Email && x.Password == Password);
            }
        }

        public UserAccountDataModel GetProfile(Guid userId)
        {
            using (var ctx = new TheContext())
            {
                ctx.Configuration.LazyLoadingEnabled = false;
                  return ctx.UsersAccounts.Include("Albums").FirstOrDefault(x => x.UserId == userId);
                
            }
        }
        public UserAccountDataModel GetById(Guid userId)
        {
            using (var ctx = new TheContext())
            {

                return ctx.UsersAccounts.Include("Albums").Include("Albums.Photos").FirstOrDefault(x => x.UserId == userId);

            }
        }

        public IEnumerable<AlbumDatamodel> GetUserAlbums(Guid userId)
        {
            using (var ctx = new TheContext())
            {
                var user = ctx.UsersAccounts.FirstOrDefault(x => x.UserId == userId);
                
                    var useralbums = user.Albums;
                    return useralbums;
               
            }
        }

    }
}
