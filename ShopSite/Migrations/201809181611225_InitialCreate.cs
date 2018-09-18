namespace ShopSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false, maxLength: 50),
                        CategoryPicture = c.String(),
                        CategoryDescription = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Item",
                c => new
                    {
                        ItemId = c.Int(nullable: false, identity: true),
                        CategoryId = c.Int(nullable: false),
                        ItemPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ItemName = c.String(nullable: false, maxLength: 50),
                        ItemProducer = c.String(nullable: false, maxLength: 50),
                        ItemPicture = c.String(),
                        ItemDescription = c.String(),
                        Bestseller = c.Boolean(nullable: false),
                        Available = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ItemId)
                .ForeignKey("dbo.Category", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.ItemPosition",
                c => new
                    {
                        ItemPositionId = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        ItemId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        OrderValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ItemPositionId)
                .ForeignKey("dbo.Item", t => t.ItemId, cascadeDelete: true)
                .ForeignKey("dbo.Order", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.ItemId);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(nullable: false, maxLength: 50),
                        City = c.String(nullable: false, maxLength: 50),
                        PostalCode = c.String(nullable: false, maxLength: 50),
                        Street = c.String(nullable: false, maxLength: 16),
                        EMail = c.String(nullable: false, maxLength: 50),
                        PhoneNumber = c.String(nullable: false, maxLength: 50),
                        Comment = c.String(),
                        OrderValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AdditionDate = c.DateTime(nullable: false),
                        OrderState = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ItemPosition", "OrderId", "dbo.Order");
            DropForeignKey("dbo.ItemPosition", "ItemId", "dbo.Item");
            DropForeignKey("dbo.Item", "CategoryId", "dbo.Category");
            DropIndex("dbo.ItemPosition", new[] { "ItemId" });
            DropIndex("dbo.ItemPosition", new[] { "OrderId" });
            DropIndex("dbo.Item", new[] { "CategoryId" });
            DropTable("dbo.Order");
            DropTable("dbo.ItemPosition");
            DropTable("dbo.Item");
            DropTable("dbo.Category");
        }
    }
}
