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
    public class Slider:BaseEntity
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Article { get; set; }
        public string Image { get; set; }
        [Required]
        public byte Order { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
    }
}
