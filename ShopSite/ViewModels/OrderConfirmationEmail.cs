using Postal;
using ShopSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopSite.ViewModels
{
    public class OrderConfirmationEmail : Email
    {
        public string To { get; set; }
        public string From { get; set; }
        public decimal Value { get; set; }
        public int OrderNumber { get; set; }
        public List<ItemPosition> ItemPositions { get; set; }
    }

    public class ZamowienieZrealizowaneEmail : Email
    {
        public string To { get; set; }
        public string From { get; set; }
        public int NumerZamowienia { get; set; }
    }
}