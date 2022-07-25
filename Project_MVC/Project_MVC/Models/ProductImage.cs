using Project_MVC.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_MVC.Models
{
    public class ProductImage:BaseEntity
    {
        public string Name { get; set; }
        public bool Primary { get; set; }
        public string Alt { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
