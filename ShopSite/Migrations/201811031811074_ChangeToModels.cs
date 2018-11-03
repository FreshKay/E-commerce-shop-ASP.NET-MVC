namespace ShopSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeToModels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "UsersData_Street", c => c.String());
            AddColumn("dbo.AspNetUsers", "UsersData_PostalCode", c => c.String());
            DropColumn("dbo.AspNetUsers", "UsersData_Address");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "UsersData_Address", c => c.String());
            DropColumn("dbo.AspNetUsers", "UsersData_PostalCode");
            DropColumn("dbo.AspNetUsers", "UsersData_Street");
        }
    }
}
