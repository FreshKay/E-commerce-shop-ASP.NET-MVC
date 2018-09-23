namespace ShopSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Item", "AddDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Item", "AddDate");
        }
    }
}
