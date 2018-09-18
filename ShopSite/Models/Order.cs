using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopSite.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Street { get; set; }
        public string EMail { get; set; }
        public string PhoneNumber { get; set; }
        public string Comment { get; set; }
        public decimal OrderValue { get; set; }
        public DateTime AdditionDate { get; set; }
        public OrderState OrderState { get; set; }
               
        List<ItemPosition> ItemPosition { get; set; }
    }

    public enum OrderState
    {
        New,
        Executed
    }
}