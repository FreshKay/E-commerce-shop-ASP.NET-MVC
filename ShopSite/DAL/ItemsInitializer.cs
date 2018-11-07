using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ShopSite.Migrations;
using ShopSite.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace ShopSite.DAL
{
    public class ItemsInitializer : MigrateDatabaseToLatestVersion<ItemsContext, Configuration>   //Initializes example items into DB 
    {
        public static void SeedItemData(ItemsContext context)
        {
            var category = new List<Category>
            {
                new Category() {CategoryId = 1, CategoryName = "Fruits", CategoryPicture = "fruits.png", CategoryDescription = "Lorem ipsum"},
                new Category() {CategoryId = 2, CategoryName = "Vegetables", CategoryPicture = "vegetables.png", CategoryDescription = "Lorem ipsum"},
                new Category() {CategoryId = 3, CategoryName = "Meat", CategoryPicture = "meat.png", CategoryDescription = "Lorem ipsum"},
                new Category() {CategoryId = 4, CategoryName = "Fish", CategoryPicture = "fish.png", CategoryDescription = "Lorem ipsum"},
                new Category() {CategoryId = 5, CategoryName = "Bread", CategoryPicture = "bread.png", CategoryDescription = "Lorem ipsum"},
                new Category() {CategoryId = 6, CategoryName = "Dairy Products", CategoryPicture = "dairy.png", CategoryDescription = "Lorem ipsum"}
            };

            category.ForEach(k => context.Categories.AddOrUpdate(k));
            context.SaveChanges();

            var item = new List<Item>
            {
                new Item() {ItemId = 1, ItemName = "Apple", ItemProducer = "Lorem ipsum", ItemDescription = "Apple", Bestseller = false,
                    Available = true, CategoryId = 1, ItemPrice = 5, ItemPicture = "apple.jpg"  },
                new Item() {ItemId = 2, ItemName = "Carrot", ItemProducer = "Lorem ipsum", ItemDescription = "Carrot", Bestseller = true,
                    Available = true, CategoryId = 2, ItemPrice = 3, ItemPicture = "carrot.jpg"  },
                new Item() {ItemId = 3, ItemName = "Chicken", ItemProducer = "Lorem ipsum", ItemDescription = "Chicken", Bestseller = false,
                    Available = true, CategoryId = 3, ItemPrice = 20, ItemPicture = "chicken.jpg"  },
                new Item() {ItemId = 4, ItemName = "Carp", ItemProducer = "Lorem ipsum", ItemDescription = "Carp", Bestseller = false,
                    Available = true, CategoryId = 4, ItemPrice = 30, ItemPicture = "fish.png"  },
                new Item() {ItemId = 5, ItemName = "Bread", ItemProducer = "Lorem ipsum", ItemDescription = "Bread", Bestseller = true,
                    Available = true, CategoryId = 5, ItemPrice = 2, ItemPicture = "bread.jpg"  },
                new Item() {ItemId = 6, ItemName = "Milk", ItemProducer = "Lorem ipsum", ItemDescription = "Milk", Bestseller = false,
                    Available = true, CategoryId = 6, ItemPrice = 6, ItemPicture = "milk.jpg"  }
            };

            item.ForEach(k => context.Items.AddOrUpdate(k));
            context.SaveChanges();
        }

        public static void SeedUsers(ItemsContext db)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

            const string name = "admin@praktycznekursy.pl";
            const string password = "P@ssw0rd";
            const string roleName = "Admin";

            var user = userManager.FindByName(name);
            if (user == null)
            {
                user = new ApplicationUser { UserName = name, Email = name, UsersData = new UsersData() };
                var result = userManager.Create(user, password);
            }

            // utworzenie roli Admin jeśli nie istnieje 
            var role = roleManager.FindByName(roleName);
            if (role == null)
            {
                role = new IdentityRole(roleName);
                var roleresult = roleManager.Create(role);
            }

            // dodanie uzytkownika do roli Admin jesli juz nie jest w roli
            var rolesForUser = userManager.GetRoles(user.Id);
            if (!rolesForUser.Contains(role.Name))
            {
                var result = userManager.AddToRole(user.Id, role.Name);
            }
        }
    }
}