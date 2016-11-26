namespace Labb_1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixingstuff : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Photos", "uploader_UserID", c => c.Guid());
            CreateIndex("dbo.Photos", "uploader_UserID");
            AddForeignKey("dbo.Photos", "uploader_UserID", "dbo.UserAccounts", "UserID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Photos", "uploader_UserID", "dbo.UserAccounts");
            DropIndex("dbo.Photos", new[] { "uploader_UserID" });
            DropColumn("dbo.Photos", "uploader_UserID");
        }
    }
}
