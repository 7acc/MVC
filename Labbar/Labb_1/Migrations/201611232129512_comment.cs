namespace Labb_1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class comment : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comments", "Photo_PhotoID", "dbo.Photos");
            DropIndex("dbo.Comments", new[] { "Photo_PhotoID" });
            RenameColumn(table: "dbo.Comments", name: "Photo_PhotoID", newName: "photoId");
            AlterColumn("dbo.Comments", "photoId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Comments", "photoId");
            AddForeignKey("dbo.Comments", "photoId", "dbo.Photos", "PhotoID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "photoId", "dbo.Photos");
            DropIndex("dbo.Comments", new[] { "photoId" });
            AlterColumn("dbo.Comments", "photoId", c => c.Guid());
            RenameColumn(table: "dbo.Comments", name: "photoId", newName: "Photo_PhotoID");
            CreateIndex("dbo.Comments", "Photo_PhotoID");
            AddForeignKey("dbo.Comments", "Photo_PhotoID", "dbo.Photos", "PhotoID");
        }
    }
}
