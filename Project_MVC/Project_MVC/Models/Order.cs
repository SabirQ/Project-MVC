using Project_MVC.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project_MVC.Models
{
    public class Order:BaseEntity
    {
        [Required]
        public DateTime Date { get; set; }
        public decimal TotalPrice { get; set; }
        public bool? Status { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }
        public List<BasketItem> BasketItems { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
