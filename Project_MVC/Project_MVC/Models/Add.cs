using Project_MVC.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_MVC.Models
{
    public class Add:BaseEntity
    {
        public string Title { get; set; }
        public string Discount { get; set; }
        public string Image { get; set; }

    }
}
