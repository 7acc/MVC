namespace Labb_1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ablum : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Photos", "Album_AlbumId", "dbo.Albums");
            DropIndex("dbo.Photos", new[] { "Album_AlbumId" });
            CreateTable(
                "dbo.Album-Photo",
                c => new
                    {
                        AlbumId = c.Guid(nullable: false),
                        PhotoID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.AlbumId, t.PhotoID })
                .ForeignKey("dbo.Albums", t => t.AlbumId, cascadeDelete: true)
                .ForeignKey("dbo.Photos", t => t.PhotoID, cascadeDelete: true)
                .Index(t => t.AlbumId)
                .Index(t => t.PhotoID);
            
            DropColumn("dbo.Photos", "Album_AlbumId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Photos", "Album_AlbumId", c => c.Guid());
            DropForeignKey("dbo.Album-Photo", "PhotoID", "dbo.Photos");
            DropForeignKey("dbo.Album-Photo", "AlbumId", "dbo.Albums");
            DropIndex("dbo.Album-Photo", new[] { "PhotoID" });
            DropIndex("dbo.Album-Photo", new[] { "AlbumId" });
            DropTable("dbo.Album-Photo");
            CreateIndex("dbo.Photos", "Album_AlbumId");
            AddForeignKey("dbo.Photos", "Album_AlbumId", "dbo.Albums", "AlbumId");
        }
    }
}
