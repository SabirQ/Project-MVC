using Microsoft.AspNetCore.Http;
using Project_MVC.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project_MVC.Models
{
    public class Category:BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public string Image { get; set; }
        public List<Product> Products { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }

    }
}
