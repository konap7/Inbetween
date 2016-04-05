using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inbetween.ViewModels
{
    public class AddNewsVM
    {
        [Display(Name = "Topic")]
        [Required(ErrorMessage = "You must have a topic")]
        public string Topic { get; set; }

        [Display(Name = "Text")]
        [Required(ErrorMessage = "Du måte ange en text")]
        public string Text { get; set; }

        [Display(Name = "Picture")]
        public string Picture { get; set; }
    }
}
