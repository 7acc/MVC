namespace Labb1_Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class canedit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AlbumDatamodels",
                c => new
                    {
                        AlbumID = c.Guid(nullable: false),
                        Name = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        CreatedBy = c.Guid(nullable: false),
                        UserAccountDataModel_UserId = c.Guid(),
                    })
                .PrimaryKey(t => t.AlbumID)
                .ForeignKey("dbo.UserAccountDataModels", t => t.UserAccountDataModel_UserId)
                .Index(t => t.UserAccountDataModel_UserId);
            
            CreateTable(
                "dbo.PhotoDataModels",
                c => new
                    {
                        PhotoID = c.Guid(nullable: false),
                        Name = c.String(),
                        Url = c.String(),
                        uploader = c.Guid(nullable: false),
                        UploadedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PhotoID);
            
            CreateTable(
                "dbo.CommentDataModels",
                c => new
                    {
                        CommentId = c.Guid(nullable: false),
                        PhotoId = c.Guid(nullable: false),
                        Comment = c.String(),
                        CommentDate = c.DateTime(nullable: false),
                        CommentedById = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.PhotoDataModels", t => t.PhotoId, cascadeDelete: true)
                .Index(t => t.PhotoId);
            
            CreateTable(
                "dbo.UserAccountDataModels",
                c => new
                    {
                        UserId = c.Guid(nullable: false),
                        Name = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        Admin = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Album-Photo",
                c => new
                    {
                        AlbumID = c.Guid(nullable: false),
                        PhotoID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.AlbumID, t.PhotoID })
                .ForeignKey("dbo.AlbumDatamodels", t => t.AlbumID, cascadeDelete: true)
                .ForeignKey("dbo.PhotoDataModels", t => t.PhotoID, cascadeDelete: true)
                .Index(t => t.AlbumID)
                .Index(t => t.PhotoID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AlbumDatamodels", "UserAccountDataModel_UserId", "dbo.UserAccountDataModels");
            DropForeignKey("dbo.Album-Photo", "PhotoID", "dbo.PhotoDataModels");
            DropForeignKey("dbo.Album-Photo", "AlbumID", "dbo.AlbumDatamodels");
            DropForeignKey("dbo.CommentDataModels", "PhotoId", "dbo.PhotoDataModels");
            DropIndex("dbo.Album-Photo", new[] { "PhotoID" });
            DropIndex("dbo.Album-Photo", new[] { "AlbumID" });
            DropIndex("dbo.CommentDataModels", new[] { "PhotoId" });
            DropIndex("dbo.AlbumDatamodels", new[] { "UserAccountDataModel_UserId" });
            DropTable("dbo.Album-Photo");
            DropTable("dbo.UserAccountDataModels");
            DropTable("dbo.CommentDataModels");
            DropTable("dbo.PhotoDataModels");
            DropTable("dbo.AlbumDatamodels");
        }
    }
}
