using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopSite.Models
{
    public class Item
    {
        public int ItemId { get; set; }
        public int CategoryId { get; set; }
        public decimal ItemPrice { get; set; }
        [Required(ErrorMessage ="Enter item name.")]
        [StringLength(50)]
        public string ItemName { get; set; }
        [Required(ErrorMessage = "Enter item producer.")]
        [StringLength(50)]
        public string ItemProducer { get; set; }
        public string ItemPicture { get; set; }
        public string ItemDescription { get; set; }
        public bool Bestseller { get; set; }
        public bool Available { get; set; }

        public virtual Category Category { get; set; }
    }
}