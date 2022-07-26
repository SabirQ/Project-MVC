using Project_MVC.Models;
using System.Collections.Generic;

namespace Project_MVC.ViewModels
{
    public class HomeVM
    {
        public List<Product> Products { get; set; }
        public List<Add> Adds { get; set; }
        public List<Slider> Sliders { get; set; }
        public List<Category> Categories { get; set; }
    }
}
