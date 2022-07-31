using Project_MVC.Models.Base;

namespace Project_MVC.Models
{
    public class WishlistItem:BaseEntity
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
