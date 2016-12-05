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
        public DbSet<Album> Albums { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Album>().
              HasMany(c => c.Photos).
              WithMany(p => p.Albums).
              Map(
               m =>
               {
                   m.MapLeftKey("AlbumId");
                   m.MapRightKey("PhotoID");
                   m.ToTable("Album-Photo");
               });
        }
    }
}