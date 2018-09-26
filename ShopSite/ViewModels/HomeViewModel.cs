using ShopSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopSite.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Item> Bestseller { get; set; }
        public IEnumerable<Item> New { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Item> Categories_2 { get; set; }
    }
}