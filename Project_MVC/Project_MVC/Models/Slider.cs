using Project_MVC.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_MVC.Models
{
    public class Slider:BaseEntity
    {
        public string Title { get; set; }
        public string Article { get; set; }
        public string Image { get; set; }
        public byte Order { get; set; }
    }
}
