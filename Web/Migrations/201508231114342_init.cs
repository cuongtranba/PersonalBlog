namespace Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ApplicationUser", "FirstName", c => c.String());
            AddColumn("dbo.ApplicationUser", "LastName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ApplicationUser", "LastName");
            DropColumn("dbo.ApplicationUser", "FirstName");
        }
    }
}
