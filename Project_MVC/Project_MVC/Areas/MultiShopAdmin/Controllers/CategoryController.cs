using Microsoft.AspNetCore.Mvc;

namespace Project_MVC.Areas.MultiShopAdmin.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
