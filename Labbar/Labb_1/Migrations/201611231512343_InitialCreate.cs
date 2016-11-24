namespace Labb_1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentId = c.Guid(nullable: false),
                        comment = c.String(nullable: false, maxLength: 500),
                        CommentDate = c.DateTime(nullable: false),
                        commentedBy_UserID = c.Guid(),
                        Photo_PhotoID = c.Guid(),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.UserAccounts", t => t.commentedBy_UserID)
                .ForeignKey("dbo.Photos", t => t.Photo_PhotoID)
                .Index(t => t.commentedBy_UserID)
                .Index(t => t.Photo_PhotoID);
            
            CreateTable(
                "dbo.UserAccounts",
                c => new
                    {
                        UserID = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Admin = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserID);
            
            CreateTable(
                "dbo.Photos",
                c => new
                    {
                        PhotoID = c.Guid(nullable: false),
                        Name = c.String(),
                        Url = c.String(),
                        UploadedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PhotoID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "Photo_PhotoID", "dbo.Photos");
            DropForeignKey("dbo.Comments", "commentedBy_UserID", "dbo.UserAccounts");
            DropIndex("dbo.Comments", new[] { "Photo_PhotoID" });
            DropIndex("dbo.Comments", new[] { "commentedBy_UserID" });
            DropTable("dbo.Photos");
            DropTable("dbo.UserAccounts");
            DropTable("dbo.Comments");
        }
    }
}
