using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Project_MVC.DAL;
using Project_MVC.Models;
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

        public HomeController(AppDbContext context)
        {
            _context = context;
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
            string basketStr=HttpContext.Request.Cookies["Basket"];
            BasketVM basket;
            List<BasketItemVM> basketItems=new List<BasketItemVM>();
            if (!string.IsNullOrEmpty(basketStr))
            {
                basket = JsonConvert.DeserializeObject<BasketVM>(basketStr);
                foreach (BasketCookieItemVM cookie in basket.BasketCookieItemVMs)
                {
                    BasketItemVM basketItem = new BasketItemVM
                    {
                        Product = await _context.Products.Include(p => p.ProductImages).Include(p => p.Discount).FirstOrDefaultAsync(c => c.Id == cookie.Id),
                        Color = await _context.Colors.FirstOrDefaultAsync(c => c.Id == cookie.ColorId),
                        Size = await _context.Sizes.FirstOrDefaultAsync(s => s.Id == cookie.SizeId),
                        Quantity=cookie.Quantity
                    };
                    basketItems.Add(basketItem);
                }

            }


            return View(basketItems);
        }
       
    }
}
