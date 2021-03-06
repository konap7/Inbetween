﻿using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inbetween.ViewModels
{
    public class LoginVM
    {
        [Display(Name = "User name")]
        [Required(ErrorMessage = "You must enter a user name")]
        public string Username { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "You must enter a password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
