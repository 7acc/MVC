using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Labb_1.Models;
using System.Security.Claims;
using Labb1_Data;
using Labb1_Data.Interfaces;
using Labb1_Data.Repositories;

namespace Labb_1.Controllers
{
    public class ProfileController : Controller
    {
        IUserRepository UserRepository;

        public ProfileController()
        {
            UserRepository = new UserRepo();
        }
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
        [Authorize]
        public ActionResult UserProfile()
        {
            if (User.Identity.IsAuthenticated)
            {
                var identity = User.Identity as ClaimsIdentity;
                var id = new Guid(identity.FindFirst(ClaimTypes.Sid).Value);

                var userData = UserRepository.GetProfile(id);   
                            
                if(userData != null)
                {
                    var user = new UserAccount(userData);
                    user.Albums = UserRepository.GetUserAlbums(user.UserID).Select(x => new Album(x)).ToList();
                    return View(user);
                }                               
            }      
                            
                return RedirectToAction("Login", "Account");            
        }
    }
}