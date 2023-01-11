using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CropsMVC.Models
{
    public class LoginViewModel
    {
        [Display(Name ="Email*")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Password*")]

        public string password { get; set; }

        public int ID { get; set; }
    }
}