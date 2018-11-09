using Microsoft.AspNet.Identity.EntityFramework;
using ShopSite.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace ShopSite.DAL
{
    public class ItemsContext : IdentityDbContext<ApplicationUser>
    {
        public ItemsContext(): base("ItemsContext")  //Sets up connection string. 
        {

        }        

        static ItemsContext()       // Sets up initializer.
        {
            Database.SetInitializer<ItemsContext>(new ItemsInitializer());
        }

        public static ItemsContext Create()
        {
            return new ItemsContext();
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ItemPosition> ItemPositions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();  // Removes plurallizing of table names.
        }
    }
}