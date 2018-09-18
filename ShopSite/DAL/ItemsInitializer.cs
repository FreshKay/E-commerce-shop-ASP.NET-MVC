using ShopSite.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ShopSite.DAL
{
    public class ItemsInitializer : DropCreateDatabaseAlways<ItemsContext>   //Initializes example items into DB 
    {
        protected override void Seed(ItemsContext context)
        {
            SeedItemData(context);
            base.Seed(context);
        }

        private void SeedItemData(ItemsContext context)
        {
            var category = new List<Category>
            {
                new Category() {CategoryId = 1, CategoryName = "Socks", CategoryPicture = "socks.png", CategoryDescription = "When your feets are cold."},
                new Category() {CategoryId = 2, CategoryName = "Pants", CategoryPicture = "pants.png", CategoryDescription = "Don't go without those!"},
                new Category() {CategoryId = 3, CategoryName = "T-Shirts", CategoryPicture = "tshirts.png", CategoryDescription = "Shaped like T."},
                new Category() {CategoryId = 4, CategoryName = "Sweaters", CategoryPicture = "sweaters.png", CategoryDescription = "Don't sweat it!"},
                new Category() {CategoryId = 5, CategoryName = "Hoodies", CategoryPicture = "hoodies.png", CategoryDescription = "So comfy it is."},
                new Category() {CategoryId = 6, CategoryName = "Jackets", CategoryPicture = "jackets.png", CategoryDescription = "For rainy days"}
            };

            category.ForEach(k => context.Categories.Add(k));
            context.SaveChanges();

            var item = new List<Item>
            {
                new Item() {ItemId = 1, ItemName = "Socks 39-42", ItemProducer = "Lorem ipsum", ItemDescription = "Plain socks", Bestseller = false,
                    Available = true, CategoryId = 1, ItemPrice = 19, ItemPicture = "socks.png"  },
                new Item() {ItemId = 2, ItemName = "Pants 33", ItemProducer = "Lorem ipsum", ItemDescription = "Pants", Bestseller = true,
                    Available = true, CategoryId = 2, ItemPrice = 45, ItemPicture = "pants.png"  },
                new Item() {ItemId = 3, ItemName = "Socks 39-42", ItemProducer = "Lorem ipsum", ItemDescription = "Plain socks", Bestseller = false,
                    Available = true, CategoryId = 3, ItemPrice = 25, ItemPicture = "tshirts.png"  },
                new Item() {ItemId = 4, ItemName = "Socks 39-42", ItemProducer = "Lorem ipsum", ItemDescription = "Plain socks", Bestseller = false,
                    Available = true, CategoryId = 4, ItemPrice = 40, ItemPicture = "sweaters.png"  },
                new Item() {ItemId = 5, ItemName = "Socks 39-42", ItemProducer = "Lorem ipsum", ItemDescription = "Plain socks", Bestseller = true,
                    Available = true, CategoryId = 5, ItemPrice = 50, ItemPicture = "hoodies.png"  },
                new Item() {ItemId = 6, ItemName = "Socks 39-42", ItemProducer = "Lorem ipsum", ItemDescription = "Plain socks", Bestseller = false,
                    Available = true, CategoryId = 6, ItemPrice = 80, ItemPicture = "jackets.png"  }
            };

            item.ForEach(k => context.Items.Add(k));
            context.SaveChanges();


        }
    }
}