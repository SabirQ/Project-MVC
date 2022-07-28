using Project_MVC.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project_MVC.Models
{
    public class Size:BaseEntity
    {
        [Required]
        public string Name { get; set; }
        
    }
}
