using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inbetween.Models
{
    public class News
    {
        public int UserId { get; set; }
        public string Topic { get; set; }
        public string Text { get; set; }
        //public image Image { get; set; }
        public DateTime Date { get; set; }
    }
}
