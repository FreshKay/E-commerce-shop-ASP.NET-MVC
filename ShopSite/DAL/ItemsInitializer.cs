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
                new Category() {CategoryId = 4, CategoryName = "Fish", CategoryPicture = "fish.pngb", CategoryDescription = "Lorem ipsum"},
                new Category() {CategoryId = 5, CategoryName = "Bread", CategoryPicture = "bread.png", CategoryDescription = "Lorem ipsum"},
                new Category() {CategoryId = 6, CategoryName = "Dairy Products", CategoryPicture = "dairy.png", CategoryDescription = "Lorem ipsum"}
            };

            category.ForEach(k => context.Categories.AddOrUpdate(k));
            context.SaveChanges();

            var item = new List<Item>
            {
                new Item() {ItemId = 1, ItemName = "Kiku Apple", ItemProducer = "Tasty Compmany", ItemDescription = "Lorem ipsum dolor sit amet," +
                " consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis" +
                " nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate " +
                "velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt", Bestseller = false,
                    Available = true, CategoryId = 1, ItemPrice = 2.99M, ItemPicture = "apple.jpg", AddDate= DateTime.Now  },
                
                new Item() {ItemId = 2, ItemName = "Banana", ItemProducer = "Fresh Food", ItemDescription = "Lorem ipsum dolor sit amet," +
                " consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis" +
                " nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate " +
                "velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt ", Bestseller = true,
                    Available = true, CategoryId = 1, ItemPrice = 1.99M, ItemPicture = "fruit3.jpg", AddDate= DateTime.Now  },

                new Item() {ItemId = 3, ItemName = "Cherry", ItemProducer = "Tasty Compmany", ItemDescription = "Lorem ipsum dolor sit amet," +
                " consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis" +
                " nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate " +
                "velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt ", Bestseller = false,
                    Available = true, CategoryId = 1, ItemPrice = 4.49M, ItemPicture = "fruit1.jpg", AddDate= DateTime.Now  },

                new Item() {ItemId = 4, ItemName = "Fuji Apple", ItemProducer = "Tasty Compmany", ItemDescription = "Lorem ipsum dolor sit amet," +
                " consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis" +
                " nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate " +
                "velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt ", Bestseller = false,
                    Available = true, CategoryId = 1, ItemPrice = 1.99M, ItemPicture = "apple.jpg" , AddDate= DateTime.Now },

                new Item() {ItemId = 5, ItemName = "Grapefruit", ItemProducer = "Fresh Food", ItemDescription = "Lorem ipsum dolor sit amet," +
                " consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis" +
                " nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate " +
                "velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt ", Bestseller = true,
                    Available = true, CategoryId = 1, ItemPrice = 4.99M, ItemPicture = "fruit4.jpg", AddDate= DateTime.Now  },

                new Item() {ItemId = 6, ItemName = "Pear", ItemProducer = "Tasty Compmany", ItemDescription = "Lorem ipsum dolor sit amet," +
                " consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis" +
                " nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate " +
                "velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt ", Bestseller = true,
                    Available = true, CategoryId = 1, ItemPrice = 3.49M, ItemPicture = "fruit5.jpg" , AddDate= DateTime.Now },

                new Item() {ItemId = 7, ItemName = "Quince", ItemProducer = "Fresh Food", ItemDescription = "Lorem ipsum dolor sit amet," +
                " consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis" +
                " nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate " +
                "velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt ", Bestseller = false,
                    Available = true, CategoryId = 1, ItemPrice =5.00M, ItemPicture = "fruit6.jpg" , AddDate= DateTime.Now },

                new Item() {ItemId = 8, ItemName = "Raspberry", ItemProducer = "Tasty Compmany", ItemDescription = "Lorem ipsum dolor sit amet," +
                " consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis" +
                " nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate " +
                "velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt ", Bestseller = false,
                    Available = true, CategoryId = 1, ItemPrice = 2.99M, ItemPicture = "fruit2.jpg" , AddDate= DateTime.Now },

                new Item() {ItemId = 9, ItemName = "Cavendish Banana", ItemProducer = "Fresh Food", ItemDescription = "Lorem ipsum dolor sit amet," +
                " consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis" +
                " nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate " +
                "velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt ", Bestseller = false,
                    Available = true, CategoryId = 1, ItemPrice = 4.49M, ItemPicture = "fruit3.jpg" , AddDate= DateTime.Now },

                new Item() {ItemId = 10, ItemName = "Bartlett Pear", ItemProducer = "Tasty Compmany", ItemDescription = "Lorem ipsum dolor sit amet," +
                " consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis" +
                " nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate " +
                "velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt ", Bestseller = false,
                    Available = true, CategoryId = 1, ItemPrice = 3.99M, ItemPicture = "fruit5.jpg" , AddDate= DateTime.Now },

                new Item() {ItemId = 11, ItemName = "Envy Apple", ItemProducer = "Eating Tasty", ItemDescription = "Lorem ipsum dolor sit amet," +
                " consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis" +
                " nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate " +
                "velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt ", Bestseller = false,
                    Available = true, CategoryId = 1, ItemPrice = 1.99M, ItemPicture = "apple.jpg" , AddDate= DateTime.Now },




                new Item() {ItemId = 12, ItemName = "Carrot", ItemProducer = "Tasty Compmany", ItemDescription = "Lorem ipsum dolor sit amet," +
                " consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis" +
                " nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate " +
                "velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt", Bestseller = false,
                    Available = true, CategoryId = 2, ItemPrice = 2.99M, ItemPicture = "veg2.jpg", AddDate= DateTime.Now  },

                new Item() {ItemId = 13, ItemName = "Nelson Carrot", ItemProducer = "Fresh Food", ItemDescription = "Lorem ipsum dolor sit amet," +
                " consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis" +
                " nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate " +
                "velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt ", Bestseller = true,
                    Available = true, CategoryId = 2, ItemPrice = 1.99M, ItemPicture = "veg2.jpg", AddDate= DateTime.Now  },

                new Item() {ItemId = 14, ItemName = "Pepper", ItemProducer = "Tasty Compmany", ItemDescription = "Lorem ipsum dolor sit amet," +
                " consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis" +
                " nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate " +
                "velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt ", Bestseller = false,
                    Available = true, CategoryId = 2, ItemPrice = 4.49M, ItemPicture = "veg3.jpg", AddDate= DateTime.Now  },

                new Item() {ItemId = 15, ItemName = "Chilli Pepper", ItemProducer = "Tasty Compmany", ItemDescription = "Lorem ipsum dolor sit amet," +
                " consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis" +
                " nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate " +
                "velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt ", Bestseller = false,
                    Available = true, CategoryId = 2, ItemPrice = 1.99M, ItemPicture = "veg3.jpg" , AddDate= DateTime.Now },

                new Item() {ItemId = 16, ItemName = "Cucamber", ItemProducer = "Fresh Food", ItemDescription = "Lorem ipsum dolor sit amet," +
                " consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis" +
                " nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate " +
                "velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt ", Bestseller = true,
                    Available = true, CategoryId = 2, ItemPrice = 4.99M, ItemPicture = "veg6.jpg", AddDate= DateTime.Now  },

                new Item() {ItemId = 17, ItemName = "Parsley", ItemProducer = "Tasty Compmany", ItemDescription = "Lorem ipsum dolor sit amet," +
                " consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis" +
                " nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate " +
                "velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt ", Bestseller = true,
                    Available = true, CategoryId = 2, ItemPrice = 3.49M, ItemPicture = "veg1.jpg" , AddDate= DateTime.Now },

                new Item() {ItemId = 18, ItemName = "Beetroot", ItemProducer = "Fresh Food", ItemDescription = "Lorem ipsum dolor sit amet," +
                " consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis" +
                " nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate " +
                "velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt ", Bestseller = false,
                    Available = true, CategoryId = 2, ItemPrice =5.00M, ItemPicture = "veg5.jpg" , AddDate= DateTime.Now },

                new Item() {ItemId = 19, ItemName = "Cabbage", ItemProducer = "Tasty Compmany", ItemDescription = "Lorem ipsum dolor sit amet," +
                " consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis" +
                " nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate " +
                "velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt ", Bestseller = false,
                    Available = true, CategoryId = 2, ItemPrice = 2.99M, ItemPicture = "veg7.jpg" , AddDate= DateTime.Now },

                new Item() {ItemId = 20, ItemName = "Broccoli", ItemProducer = "Fresh Food", ItemDescription = "Lorem ipsum dolor sit amet," +
                " consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis" +
                " nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate " +
                "velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt ", Bestseller = false,
                    Available = true, CategoryId = 2, ItemPrice = 4.49M, ItemPicture = "veg4.jpg" , AddDate= DateTime.Now },

                new Item() {ItemId = 21, ItemName = " Small Cucamber", ItemProducer = "Tasty Compmany", ItemDescription = "Lorem ipsum dolor sit amet," +
                " consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis" +
                " nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate " +
                "velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt ", Bestseller = false,
                    Available = true, CategoryId = 2, ItemPrice = 3.99M, ItemPicture = "veg6.jpg" , AddDate= DateTime.Now },

                new Item() {ItemId = 22, ItemName = "North Cabbage", ItemProducer = "Eating Tasty", ItemDescription = "Lorem ipsum dolor sit amet," +
                " consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis" +
                " nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate " +
                "velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt ", Bestseller = false,
                    Available = true, CategoryId = 2, ItemPrice = 1.99M, ItemPicture = "veg7.jpg" , AddDate= DateTime.Now },




                new Item() {ItemId = 23, ItemName = "Chicken", ItemProducer = "Eating Tasty", ItemDescription = "Lorem ipsum dolor sit amet," +
                " consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis" +
                " nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate " +
                "velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt ", Bestseller = false,
                    Available = true, CategoryId = 3, ItemPrice = 11.99M, ItemPicture = "chicken.jpg" , AddDate= DateTime.Now },

                new Item() {ItemId = 24, ItemName = "Beef", ItemProducer = "Tasty Compmany", ItemDescription = "Lorem ipsum dolor sit amet," +
                " consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis" +
                " nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate " +
                "velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt", Bestseller = false,
                    Available = true, CategoryId = 3, ItemPrice = 12.99M, ItemPicture = "meat1.jpg", AddDate= DateTime.Now  },

                new Item() {ItemId = 25, ItemName = "Bacon", ItemProducer = "Fresh Food", ItemDescription = "Lorem ipsum dolor sit amet," +
                " consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis" +
                " nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate " +
                "velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt ", Bestseller = true,
                    Available = true, CategoryId = 3, ItemPrice = 11.99M, ItemPicture = "meat2.jpg", AddDate= DateTime.Now  },

                new Item() {ItemId = 26, ItemName = "Dark Meat", ItemProducer = "Tasty Compmany", ItemDescription = "Lorem ipsum dolor sit amet," +
                " consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis" +
                " nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate " +
                "velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt ", Bestseller = false,
                    Available = true, CategoryId = 3, ItemPrice = 14.49M, ItemPicture = "meat3.jpg", AddDate= DateTime.Now  },

                new Item() {ItemId = 27, ItemName = "Ground Beef", ItemProducer = "Tasty Compmany", ItemDescription = "Lorem ipsum dolor sit amet," +
                " consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis" +
                " nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate " +
                "velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt ", Bestseller = false,
                    Available = true, CategoryId = 3, ItemPrice = 11.99M, ItemPicture = "meat4.jpg" , AddDate= DateTime.Now },

                new Item() {ItemId = 28, ItemName = "Pork", ItemProducer = "Fresh Food", ItemDescription = "Lorem ipsum dolor sit amet," +
                " consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis" +
                " nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate " +
                "velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt ", Bestseller = true,
                    Available = true, CategoryId = 3, ItemPrice = 14.99M, ItemPicture = "meat5.jpg", AddDate= DateTime.Now  },

                new Item() {ItemId = 29, ItemName = "Lamb", ItemProducer = "Tasty Compmany", ItemDescription = "Lorem ipsum dolor sit amet," +
                " consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis" +
                " nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate " +
                "velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt ", Bestseller = true,
                    Available = true, CategoryId = 3, ItemPrice = 13.49M, ItemPicture = "meat6.jpg" , AddDate= DateTime.Now },




                new Item() {ItemId = 30, ItemName = "Carp", ItemProducer = "Fresh Food", ItemDescription = "Lorem ipsum dolor sit amet," +
                " consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis" +
                " nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate " +
                "velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt ", Bestseller = false,
                    Available = true, CategoryId = 4, ItemPrice = 15.00M, ItemPicture = "fish.jpg" , AddDate= DateTime.Now },

                new Item() {ItemId = 31, ItemName = "Zander", ItemProducer = "Tasty Compmany", ItemDescription = "Lorem ipsum dolor sit amet," +
                " consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis" +
                " nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate " +
                "velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt ", Bestseller = false,
                    Available = true, CategoryId = 4, ItemPrice = 12.99M, ItemPicture = "fish1.jpg" , AddDate= DateTime.Now },

                new Item() {ItemId = 32, ItemName = "Pike", ItemProducer = "Fresh Food", ItemDescription = "Lorem ipsum dolor sit amet," +
                " consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis" +
                " nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate " +
                "velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt ", Bestseller = false,
                    Available = true, CategoryId = 4, ItemPrice = 14.49M, ItemPicture = "fish2.jpg" , AddDate= DateTime.Now },

                new Item() {ItemId = 33, ItemName = "Tench", ItemProducer = "Tasty Compmany", ItemDescription = "Lorem ipsum dolor sit amet," +
                " consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis" +
                " nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate " +
                "velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt ", Bestseller = false,
                    Available = true, CategoryId = 4, ItemPrice = 13.99M, ItemPicture = "fish3.jpg" , AddDate= DateTime.Now },

                new Item() {ItemId = 34, ItemName = "Mackerel", ItemProducer = "Eating Tasty", ItemDescription = "Lorem ipsum dolor sit amet," +
                " consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis" +
                " nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate " +
                "velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt ", Bestseller = false,
                    Available = true, CategoryId = 4, ItemPrice = 11.99M, ItemPicture = "fish4.jpg" , AddDate= DateTime.Now },

                new Item() {ItemId = 35, ItemName = "Trout", ItemProducer = "Eating Tasty", ItemDescription = "Lorem ipsum dolor sit amet," +
                " consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis" +
                " nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate " +
                "velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt ", Bestseller = false,
                    Available = true, CategoryId = 4, ItemPrice = 11.99M, ItemPicture = "fish5.jpg" , AddDate= DateTime.Now },



                 new Item() {ItemId = 36, ItemName = "Bread", ItemProducer = "Fresh Food", ItemDescription = "Lorem ipsum dolor sit amet," +
                " consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis" +
                " nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate " +
                "velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt ", Bestseller = false,
                    Available = true, CategoryId = 5, ItemPrice = 5.00M, ItemPicture = "bread1.jpg" , AddDate= DateTime.Now },

                new Item() {ItemId = 37, ItemName = "Barrel", ItemProducer = "Tasty Compmany", ItemDescription = "Lorem ipsum dolor sit amet," +
                " consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis" +
                " nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate " +
                "velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt ", Bestseller = false,
                    Available = true, CategoryId = 5, ItemPrice = 2.99M, ItemPicture = "bread2.jpg" , AddDate= DateTime.Now },

                new Item() {ItemId = 38, ItemName = "Baguette", ItemProducer = "Fresh Food", ItemDescription = "Lorem ipsum dolor sit amet," +
                " consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis" +
                " nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate " +
                "velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt ", Bestseller = false,
                    Available = true, CategoryId = 5, ItemPrice = 4.49M, ItemPicture = "bread3.jpg" , AddDate= DateTime.Now },

                new Item() {ItemId = 39, ItemName = "Rolls", ItemProducer = "Tasty Compmany", ItemDescription = "Lorem ipsum dolor sit amet," +
                " consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis" +
                " nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate " +
                "velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt ", Bestseller = false,
                    Available = true, CategoryId = 5, ItemPrice = 3.99M, ItemPicture = "bread1.jpg" , AddDate= DateTime.Now },

                new Item() {ItemId = 40, ItemName = "Ciabatta", ItemProducer = "Eating Tasty", ItemDescription = "Lorem ipsum dolor sit amet," +
                " consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis" +
                " nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate " +
                "velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt ", Bestseller = false,
                    Available = true, CategoryId = 5, ItemPrice = 1.99M, ItemPicture = "bread4.jpg" , AddDate= DateTime.Now },

                new Item() {ItemId = 41, ItemName = "Baguette", ItemProducer = "Eating Tasty", ItemDescription = "Lorem ipsum dolor sit amet," +
                " consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis" +
                " nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate " +
                "velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt ", Bestseller = false,
                    Available = true, CategoryId = 5, ItemPrice = 1.99M, ItemPicture = "bread5.jpg" , AddDate= DateTime.Now },



                new Item() {ItemId = 42, ItemName = "Milk", ItemProducer = "Tasty Compmany", ItemDescription = "Lorem ipsum dolor sit amet," +
                " consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis" +
                " nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate " +
                "velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt ", Bestseller = false,
                    Available = true, CategoryId = 6, ItemPrice = 12.99M, ItemPicture = "dairy1.jpg" , AddDate= DateTime.Now },

                new Item() {ItemId = 43, ItemName = "Yellow Cheese", ItemProducer = "Fresh Food", ItemDescription = "Lorem ipsum dolor sit amet," +
                " consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis" +
                " nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate " +
                "velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt ", Bestseller = false,
                    Available = true, CategoryId = 6, ItemPrice = 4.49M, ItemPicture = "dairy2.jpg" , AddDate= DateTime.Now },

                new Item() {ItemId = 44, ItemName = "White Cheese", ItemProducer = "Tasty Compmany", ItemDescription = "Lorem ipsum dolor sit amet," +
                " consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis" +
                " nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate " +
                "velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt ", Bestseller = false,
                    Available = true, CategoryId = 6, ItemPrice = 3.99M, ItemPicture = "dairy3.jpg" , AddDate= DateTime.Now },

                new Item() {ItemId = 45, ItemName = "Goat's Milk", ItemProducer = "Eating Tasty", ItemDescription = "Lorem ipsum dolor sit amet," +
                " consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis" +
                " nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate " +
                "velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt ", Bestseller = false,
                    Available = true, CategoryId = 6, ItemPrice = 1.99M, ItemPicture = "dairy1.jpg" , AddDate= DateTime.Now },

                new Item() {ItemId = 46, ItemName = "Goat's Cheese", ItemProducer = "Eating Tasty", ItemDescription = "Lorem ipsum dolor sit amet," +
                " consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis" +
                " nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate " +
                "velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt ", Bestseller = false,
                    Available = true, CategoryId = 6, ItemPrice = 1.99M, ItemPicture = "dairy4.jpg" , AddDate= DateTime.Now },

                 new Item() {ItemId = 47, ItemName = "Gouda", ItemProducer = "Fresh Food", ItemDescription = "Lorem ipsum dolor sit amet," +
                " consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis" +
                " nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate " +
                "velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt ", Bestseller = false,
                    Available = true, CategoryId = 6, ItemPrice = 5.00M, ItemPicture = "dairy6.jpg" , AddDate= DateTime.Now },

                new Item() {ItemId = 48, ItemName = "Eggs", ItemProducer = "Tasty Compmany", ItemDescription = "Lorem ipsum dolor sit amet," +
                " consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis" +
                " nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate " +
                "velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt ", Bestseller = false,
                    Available = true, CategoryId = 6, ItemPrice = 2.99M, ItemPicture = "bread2.jpg" , AddDate= DateTime.Now },

                new Item() {ItemId = 49, ItemName = "Parmesan Cheese", ItemProducer = "Fresh Food", ItemDescription = "Lorem ipsum dolor sit amet," +
                " consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis" +
                " nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate " +
                "velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt ", Bestseller = false,
                    Available = true, CategoryId = 6, ItemPrice = 4.49M, ItemPicture = "dairy5.jpg" , AddDate= DateTime.Now },

                new Item() {ItemId = 50, ItemName = "Yoghurt", ItemProducer = "Tasty Compmany", ItemDescription = "Lorem ipsum dolor sit amet," +
                " consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis" +
                " nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate " +
                "velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt ", Bestseller = false,
                    Available = true, CategoryId = 6, ItemPrice = 3.99M, ItemPicture = "dairy1.jpg" , AddDate= DateTime.Now },

                new Item() {ItemId = 51, ItemName = "Cheddar Cheese", ItemProducer = "Eating Tasty", ItemDescription = "Lorem ipsum dolor sit amet," +
                " consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis" +
                " nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate " +
                "velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt ", Bestseller = false,
                    Available = true, CategoryId = 6, ItemPrice = 1.99M, ItemPicture = "dairy4.jpg" , AddDate= DateTime.Now }
            };

            item.ForEach(k => context.Items.AddOrUpdate(k));
            context.SaveChanges();
        }

        public static void SeedUsers(ItemsContext db)
        {
            // initializes user manager
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

            const string name = "admin@foodshop.c";
            const string password = "P@ssw0rd";
            const string roleName = "Admin";

            var user = userManager.FindByName(name);
            if (user == null)
            {
                user = new ApplicationUser { UserName = name, Email = name, UsersData = new UsersData() };
                var result = userManager.Create(user, password);
            }

            // creating Admin
            var role = roleManager.FindByName(roleName);
            if (role == null)
            {
                role = new IdentityRole(roleName);
                var roleresult = roleManager.Create(role);
            }

            // Adds adminif there is none
            var rolesForUser = userManager.GetRoles(user.Id);
            if (!rolesForUser.Contains(role.Name))
            {
                var result = userManager.AddToRole(user.Id, role.Name);
            }
        }
    }
}