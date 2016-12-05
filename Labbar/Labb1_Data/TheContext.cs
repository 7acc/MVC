using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb1_Data
{
    class TheContext : DbContext
    {
        
            public DbSet<PhotoDataModel> Photos { get; set; }
            public DbSet<UserAccountDataModel> UsersAccounts { get; set; }
            public DbSet<CommentDataModel> Comments { get; set; }
            public DbSet<AlbumDatamodel> Albums { get; set; }
            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder.Entity<AlbumDatamodel>().
                  HasMany(c => c.Photos).
                  WithMany(p => p.Albums).
                  Map(
                   m =>
                   {
                       m.MapLeftKey("AlbumID");
                       m.MapRightKey("PhotoID");
                       m.ToTable("Album-Photo");
                   });
            }
        
    }
}
