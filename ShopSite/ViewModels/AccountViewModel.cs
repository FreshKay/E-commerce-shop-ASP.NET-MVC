using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopSite.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "You need to enter e-mail address!")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "You need to enter password!")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]    
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "{0} must have at least {2} characters.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "Passwords are not the same.")]
        public string ConfirmPassword { get; set; }
    }

}