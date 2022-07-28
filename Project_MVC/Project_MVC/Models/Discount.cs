using Project_MVC.Models.Base;
using System.Collections.Generic;

namespace Project_MVC.Models
{
    public class Discount:BaseEntity
    {
        public string Name { get; set; }
        public decimal Value { get; set; }
        public List<Product> Products { get; set; }
    }
}
