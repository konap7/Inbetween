using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inbetween.ViewModels
{
    public class AddReviewVM
    {
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Please enter your name")]
        public string Name { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Review")]
        [Required(ErrorMessage = "Pleas add your review")]
        public string Review { get; set; }
    }
}
