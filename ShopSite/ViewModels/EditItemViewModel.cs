using ShopSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopSite.ViewModels
{
    public class EditItemViewModel
    {
        public Item Item { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public bool? Confirmation { get; set; }
    }
}