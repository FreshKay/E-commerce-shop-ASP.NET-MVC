using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopSite.Models
{
    public class BasketStatus
    {
        public Item Item{ get; set; }
        public int Quantity { get; set; }
        public decimal Value { get; set; }
    }
}