using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Project_MVC.DAL;
using Project_MVC.Models;
using Project_MVC.Utilities;
using Project_MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public HomeController(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        
        public async Task<IActionResult> Index()
        {
            HomeVM homeVM = new HomeVM
            {
                Products = await _context.Products.Include(p => p.ProductImages).ToListAsync(),
                Adds= await _context.Adds.ToListAsync(),
                Sliders= await _context.Sliders.ToListAsync(),
                Categories= await _context.Categories.Include(p => p.Products).ToListAsync()
            };
            return View(homeVM);
        }
        public IActionResult Contact()
        {
            return View();
        }
        public async Task<IActionResult> Cart()
        {
            if (User.Identity.IsAuthenticated) {
                AppUser user = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);
                if (user != null)
                {
                    List<BasketItem> items = await _context.BasketItems.Include(b => b.AppUser).Include(b => b.Color).Include(b => b.Size).Include(b => b.Product).ThenInclude(p => p.ProductImages).Where(b => b.AppUserId == user.Id).ToListAsync();
                    ViewBag.BasketItems = items;
                    decimal TotalPrice = 0;
                    foreach (var item in items)
                    {
                        TotalPrice += item.Price * item.Quantity;
                    }
                    ViewBag.TotalPrice = TotalPrice;
                    return View();
                }
            }
            else
            {
                string basketStr = HttpContext.Request.Cookies["Basket"];
                BasketVM basket;
                List<BasketItemVM> basketItems = new List<BasketItemVM>();
                if (!string.IsNullOrEmpty(basketStr))
                {
                    decimal TotalPrice = 0;
                    basket = JsonConvert.DeserializeObject<BasketVM>(basketStr);
                    foreach (BasketCookieItemVM cookie in basket.BasketCookieItemVMs)
                    {
                        Product product = await _context.Products.Include(p => p.ProductImages).Include(p => p.Discount).FirstOrDefaultAsync(c => c.Id == cookie.Id);
                        BasketItemVM basketItem = new BasketItemVM
                        {
                            Product =product,
                            Color = await _context.Colors.FirstOrDefaultAsync(c => c.Id == cookie.ColorId),
                            Size = await _context.Sizes.FirstOrDefaultAsync(s => s.Id == cookie.SizeId),
                            Quantity = cookie.Quantity,
                            Price=product.CheckDiscount()
                        };
                        TotalPrice = basketItem.Price * basketItem.Quantity;
                        basketItems.Add(basketItem);
                    }
                    ViewBag.BasketItems = basketItems;
                }
            }
            return View();
        }

    }
}
