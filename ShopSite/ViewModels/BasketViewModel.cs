using ShopSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopSite.ViewModels
{
    public class BasketViewModel
    {
        public List<BucketStatus> BucketStatus { get; set; }
        public decimal PriceSum { get; set; }
    }
}