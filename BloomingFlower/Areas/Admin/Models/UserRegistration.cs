using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BloomingFlower.Areas.Admin.Models
{
    public class UserRegistration
    {

        public int Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "UserName Exceeds its length.")]
        [MinLength(5, ErrorMessage = "Minimum Length is 5")]
        public string UserName { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Password Exceeds its length")]
        [DataType(DataType.Password)]
        [MinLength(5, ErrorMessage = "Minimum Length is 5")]
        public string Password { get; set; }

    }
}