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
    public class Product:BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        public decimal? OldPrice { get; set; }
        [Required]
        public string Desc { get; set; }
        public List<ProductImage> ProductImages { get; set; }
        [Required]
        public int ProductInformationId { get; set; }
       
        public ProductInformation ProductInformation { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int DiscountId { get; set; }
        public Discount Discount { get; set; }

        [NotMapped]
        public IFormFile MainPhoto { get; set; }
        [NotMapped]
        public List<IFormFile> Photos { get; set; }
        [NotMapped]
        public List<int> PhotoIds { get; set; }
        [NotMapped]
        public int? ColorId { get; set; }
        [NotMapped]
        public int? SizeId { get; set; }
        [NotMapped]
        public int Quantity { get; set; }
    }
}
