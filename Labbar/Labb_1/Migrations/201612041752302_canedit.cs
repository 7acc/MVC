namespace Labb_1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class canedit : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comments", "commentedBy_UserID", "dbo.UserAccounts");
            DropIndex("dbo.Comments", new[] { "commentedBy_UserID" });
            AddColumn("dbo.Albums", "CanBeEdited", c => c.Boolean(nullable: false));
            AddColumn("dbo.Comments", "commentedById", c => c.Guid(nullable: false));
            DropColumn("dbo.Comments", "commentedBy_UserID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comments", "commentedBy_UserID", c => c.Guid());
            DropColumn("dbo.Comments", "commentedById");
            DropColumn("dbo.Albums", "CanBeEdited");
            CreateIndex("dbo.Comments", "commentedBy_UserID");
            AddForeignKey("dbo.Comments", "commentedBy_UserID", "dbo.UserAccounts", "UserID");
        }
    }
}
