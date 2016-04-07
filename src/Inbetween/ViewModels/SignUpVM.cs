using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inbetween.ViewModels
{
    public class SignUpVM
    {
        [Required]
        [Display(Name = "User name")]
        //[EmailAddress(ErrorMessage = "Enter a valid user name")]
        public string Username { get; set; }

        [Required]
        [Display(Name = "Pasword")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
