namespace ShopSite.Migrations
{
    using ShopSite.DAL;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<ShopSite.DAL.ItemsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "ShopSite.DAL.ItemsContext";
        }

        protected override void Seed(ShopSite.DAL.ItemsContext context)
        {
            ItemsInitializer.SeedItemData(context);
            ItemsInitializer.SeedUsers(context);
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
