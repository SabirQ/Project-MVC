using Project_MVC.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_MVC.Models
{
    public class ProductInformation:BaseEntity
    {
        public string Key { get; set; }
        public string Desc { get; set; }
        public List<Product> Products { get; set; }
    }
}
