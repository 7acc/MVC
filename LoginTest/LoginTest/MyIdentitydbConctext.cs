using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoginTest
{
    public class MyIdentitydbConctext : IdentityDbContext<IdentityUser>
    {
        public MyIdentitydbConctext() : base("LoginTest")
        {

        }
    }
}