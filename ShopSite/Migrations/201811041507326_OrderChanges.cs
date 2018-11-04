namespace ShopSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderChanges : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Order", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Order", "PostalCode", c => c.String(nullable: false, maxLength: 16));
            AlterColumn("dbo.Order", "Street", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Order", "Comment", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Order", "Comment", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Order", "Street", c => c.String(nullable: false, maxLength: 16));
            AlterColumn("dbo.Order", "PostalCode", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Order", "Name", c => c.String());
        }
    }
}
