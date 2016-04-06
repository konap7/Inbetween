using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inbetween.ViewModels
{
    public class ListNewsVM
    {
        public int Id { get; set; }
        public string Topic { get; set; }
        public string Text { get; set; }
        public string Picture { get; set; }
        public DateTime Date { get; set; }
    }
}
