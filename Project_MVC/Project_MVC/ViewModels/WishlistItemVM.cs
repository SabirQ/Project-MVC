using Project_MVC.Models;

namespace Project_MVC.ViewModels
{
    public class WishlistItemVM
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public decimal Price { get; set; }
    }
}
