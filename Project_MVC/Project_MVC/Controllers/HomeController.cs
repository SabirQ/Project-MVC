using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_MVC.DAL;
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
    }
}
