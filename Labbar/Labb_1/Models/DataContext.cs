using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Labb_1.Models
{
    public class DataContext :DbContext
    {
        public DbSet<Photo> Photos { get; set; }
        public DbSet<UserAccount> UsersAccounts { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}