using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace LoginTest.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var identity = User.Identity as ClaimsIdentity;
            var email = identity.FindFirst(ClaimTypes.Name).Value;
            var id = identity.FindFirst(ClaimTypes.NameIdentifier).Value;
            var guid = new Guid(id);
            return Content("OK\n"+ $"Du är inloggad som {email} adn your id is {id}   guid => {guid} ");
        }
    }
}