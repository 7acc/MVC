namespace Labb_1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class commentphotoid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserAccounts", "ConfirmPassword", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserAccounts", "ConfirmPassword");
        }
    }
}
