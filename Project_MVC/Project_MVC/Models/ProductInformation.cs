using Project_MVC.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project_MVC.Models
{
    public class ProductInformation:BaseEntity
    {
        [Required]
        public string Key { get; set; }
        [Required]
        public string Desc { get; set; }
        public List<Product> Products { get; set; }
    }
}
