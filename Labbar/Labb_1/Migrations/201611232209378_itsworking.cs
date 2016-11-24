namespace Labb_1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class itsworking : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.UserAccounts", "ConfirmPassword");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserAccounts", "ConfirmPassword", c => c.String());
        }
    }
}
