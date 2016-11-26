namespace Labb_1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class uploaderid : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Photos", "uploader_UserID", "dbo.UserAccounts");
            DropIndex("dbo.Photos", new[] { "uploader_UserID" });
            AddColumn("dbo.Photos", "uploader", c => c.Guid(nullable: false));
            DropColumn("dbo.Photos", "uploader_UserID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Photos", "uploader_UserID", c => c.Guid());
            DropColumn("dbo.Photos", "uploader");
            CreateIndex("dbo.Photos", "uploader_UserID");
            AddForeignKey("dbo.Photos", "uploader_UserID", "dbo.UserAccounts", "UserID");
        }
    }
}
