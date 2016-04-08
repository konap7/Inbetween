using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inbetween.ViewModels
{
    public class AddAlbumVM
    {
        [Display(Name = "Album Name")]
        [Required(ErrorMessage = "The album must have a title")]
        public string Albumname { get; set; }

        [Display(Name = "Date")]
        [Required(ErrorMessage = "Enter the release date of the album in the following format: yyyy-mm-dd")]
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }

        [Display(Name = "Tracks")]
        [Required(ErrorMessage = "Enter the number of tracks for the album")]
        public int Tracks { get; set; }

        [Display(Name = "Album Cover")]
        [Required(ErrorMessage = "Insert the URL of the cover for the album")]
        public string Picture { get; set; }
    }
}
