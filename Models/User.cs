using System;
using System.ComponentModel.DataAnnotations;

namespace demo_app.Models
{
    public class User
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [Display(Name = "Full Name")]
        public string Fullname { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
