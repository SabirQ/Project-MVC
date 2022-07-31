using Project_MVC.Models.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project_MVC.Models
{
    public class Discount:BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Value { get; set; }
        public List<Product> Products { get; set; }
    }
}
