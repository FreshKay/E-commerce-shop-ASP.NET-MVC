using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopSite.ViewModels
{
    public class BasketDeletionViewModel
    {
        public int BasketQuantity { get; set; }
        public decimal BasketValue { get; set; }
        public int QuantityToDelete { get; set; }
        public int ItemIdToRemove { get; set; }
    }
}