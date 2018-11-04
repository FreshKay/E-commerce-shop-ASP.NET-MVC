namespace ShopSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Orders : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Order", name: "ApplicationUser_Id", newName: "UserId");
            RenameIndex(table: "dbo.Order", name: "IX_ApplicationUser_Id", newName: "IX_UserId");
            AlterColumn("dbo.Order", "Comment", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Order", "Comment", c => c.String());
            RenameIndex(table: "dbo.Order", name: "IX_UserId", newName: "IX_ApplicationUser_Id");
            RenameColumn(table: "dbo.Order", name: "UserId", newName: "ApplicationUser_Id");
        }
    }
}
