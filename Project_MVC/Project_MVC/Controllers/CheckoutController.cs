using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_MVC.DAL;
using Project_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_MVC.Controllers
{
    [Authorize(Roles ="Customer")]
    public class CheckoutController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public CheckoutController(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
            List<BasketItem> items = await _context.BasketItems.Include(b => b.AppUser).Include(b => b.Product).Include(b => b.Color).Include(b => b.Size).Where(b => b.AppUserId == user.Id&&b.OrderId==null).ToListAsync();
            ViewBag.BasketItems = items;
            decimal TotalPrice = 0;
            foreach (BasketItem item in items)
            {
                TotalPrice += item.Price * item.Quantity;
            }
            ViewBag.TotalPrice = TotalPrice;
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Index(Order order)
        {
            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);

            List<BasketItem> items = await _context.BasketItems.Include(b => b.AppUser).Include(b => b.Product).Include(b => b.Color).Include(b => b.Size).Where(b => b.AppUserId == user.Id && b.OrderId == null).ToListAsync();

            ViewBag.BasketItems = items;
            decimal TotalPrice = 0;
            foreach (var item in items)
            {
                TotalPrice += item.Price * item.Quantity;
            }
            ViewBag.TotalPrice = TotalPrice;
            if (!ModelState.IsValid) return View();
            if (items.Count == 0)
            {
                ModelState.AddModelError("City", "Your bag is empty");
                return View();
            }
            order.BasketItems = items;
            order.AppUser = user;
            order.Date = DateTime.Now;
            order.Status = null;
            order.TotalPrice = TotalPrice;

            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
