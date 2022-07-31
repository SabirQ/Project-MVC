using Project_MVC.Models;
using System.Collections.Generic;

namespace Project_MVC.ViewModels
{
    public class ProductVM
    {
        public Product Product { get; set; }
        public List<Product> Products { get; set; }
    }
}
