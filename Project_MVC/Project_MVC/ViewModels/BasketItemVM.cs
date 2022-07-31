using Project_MVC.Models;

namespace Project_MVC.ViewModels
{
    public class BasketItemVM
    {
        public Product Product { get; set; }
        public Color Color { get; set; }
        public Size Size { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
