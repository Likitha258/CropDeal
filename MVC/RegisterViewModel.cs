using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CropsMVC.Models
{
    public class RegisterViewModel
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "*")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "*")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "*")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "*")]
        public string Email { get; set; }
        [Required(ErrorMessage = "*")]

        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "*")]
        public string Address { get; set; }
        [Required(ErrorMessage = "*")]
        public string Role { get; set; }
        public string Status { get; set; }

    }
}