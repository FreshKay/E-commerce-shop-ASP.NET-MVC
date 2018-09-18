using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShopSite.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Enter category name.")]
        [StringLength(50)]
        public string CategoryName { get; set; }
        public string CategoryPicture { get; set; }
        public string CategoryDescription { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}