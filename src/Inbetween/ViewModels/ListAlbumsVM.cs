using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inbetween.ViewModels
{
    public class ListAlbumsVM
    {
        public int Id { get; set; }
        public string Albumname { get; set; }
        public DateTime Date { get; set; }
        public int Tracks { get; set; }
        public string Picture { get; set; }
        //public List<Review> Reviews { get; set; }
    }
}
