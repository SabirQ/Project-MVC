using Project_MVC.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_MVC.Models
{
    public class Product:BaseEntity
    {
        public string Name { get; set; }
        
        public decimal Price { get; set; }
        public string Desc { get; set; }
        public int MyProperty { get; set; }
        public List<ProductImage> ProductImages { get; set; }
        public int ProductInformationId { get; set; }
        public ProductInformation ProductInformation { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
