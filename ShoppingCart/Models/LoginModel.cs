using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShoppingCart.Models
{
    public class LoginModel
    {
        [Display(Name ="Email")]
        public string email { get; set; }

        [Display(Name ="Password")]
        public string password { get; set; }
        public string conformpassword { get; set; }
    }
}