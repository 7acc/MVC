namespace Labb_1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class albums : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Albums",
                c => new
                    {
                        AlbumId = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 30),
                        DateCreated = c.DateTime(nullable: false),
                        UserAccount_UserID = c.Guid(),
                    })
                .PrimaryKey(t => t.AlbumId)
                .ForeignKey("dbo.UserAccounts", t => t.UserAccount_UserID)
                .Index(t => t.UserAccount_UserID);
            
            AddColumn("dbo.Photos", "Album_AlbumId", c => c.Guid());
            CreateIndex("dbo.Photos", "Album_AlbumId");
            AddForeignKey("dbo.Photos", "Album_AlbumId", "dbo.Albums", "AlbumId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Albums", "UserAccount_UserID", "dbo.UserAccounts");
            DropForeignKey("dbo.Photos", "Album_AlbumId", "dbo.Albums");
            DropIndex("dbo.Photos", new[] { "Album_AlbumId" });
            DropIndex("dbo.Albums", new[] { "UserAccount_UserID" });
            DropColumn("dbo.Photos", "Album_AlbumId");
            DropTable("dbo.Albums");
        }
    }
}
