using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopSite.Models
{
    public class UsersData
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string City { get; set; }

        [RegularExpression(@"(\+\d{2})*[\d\s-)]+", ErrorMessage = "Wrong phone number format.")]
        public string Number { get; set; }

        [EmailAddress(ErrorMessage = "Wrong e-mail format.")]
        public string Email { get; set; }
    }
}