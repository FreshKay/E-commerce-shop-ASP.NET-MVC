using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopSite.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
        
        [Required(ErrorMessage = "Enter your name.")]
        [StringLength(50)]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Enter your surname.")]
        [StringLength(50)]
        public string Surname { get; set; }
        
        [Required(ErrorMessage = "Enter city name.")]
        [StringLength(50)]
        public string City { get; set; }
        
        [Required(ErrorMessage = "Enter postal code.")]
        [StringLength(16)]
        public string PostalCode { get; set; }
        
        [Required(ErrorMessage = "Enter address.")]
        [StringLength(50)]
        public string Street { get; set; }
        
        [Required(ErrorMessage = "Enter your e-mail.")]
        [EmailAddress(ErrorMessage = "Wrong format for your e-mail address.")]
        [StringLength(50)]
        public string EMail { get; set; }

        [Required(ErrorMessage = "Enter your phone number.")]
        [StringLength(50)]
        public string PhoneNumber { get; set; }

        public string Comment { get; set; }
        public decimal OrderValue { get; set; }
        public DateTime AdditionDate { get; set; }
        public OrderState OrderState { get; set; }
               
        public List<ItemPosition> ItemPosition { get; set; }
    }

    public enum OrderState
    {
        New,
        Executed
    }
}