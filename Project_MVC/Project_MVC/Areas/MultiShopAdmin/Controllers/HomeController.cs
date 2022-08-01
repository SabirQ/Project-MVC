using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_MVC.DAL;
using Project_MVC.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project_MVC.Areas.MultiShopAdmin.Controllers
{
    [Area("MultiShopAdmin")]
    //[Authorize(Roles = "Admin")]
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        

        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            List<Order> orders = await _context.Orders.ToListAsync();
            decimal totalprice = 0;
            if (orders!=null)
            {
                foreach (Order order in orders)
                {
                    totalprice += order.TotalPrice;
            }
            }
            ViewBag.TotalPrice = totalprice;
            return View(orders);
        }
    }
}
