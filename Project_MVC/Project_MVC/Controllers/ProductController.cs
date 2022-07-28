using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_MVC.DAL;
using Project_MVC.Models;
using Project_MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_MVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(int? id)
        {
            if (id != null && id != 0)
            {
                //Category category = await _context.Categories.Include(c => c.Products).ThenInclude(p=>p.ProductImages).FirstOrDefaultAsync(c => c.Id == id);
                List<Product> related= await _context.Products.Where(p => p.CategoryId == id).Include(p => p.ProductImages).ToListAsync();
                if (related != null)
                {
                    return View(related);
                }
            }
            List<Product> products = await _context.Products.Include(p => p.ProductImages).ToListAsync();
            return View(products);
        }
        public async Task<IActionResult> Detail(int? id)
        {
            if (id==null||id==0)
            {
                return NotFound();
            }
            Product product = _context.Products.Include(p => p.ProductImages).Include(p => p.ProductInformation).Include(p => p.Category).FirstOrDefault(p => p.Id == id);
            if (product == null)return NotFound();
            ViewBag.Products = await _context.Products.Include(p => p.ProductImages).Where(p => p.Id!=id && p.CategoryId ==product.CategoryId).ToListAsync();
            ViewBag.Colors = await _context.Colors.OrderBy(c => c.Name).ToListAsync();
            ViewBag.Sizes = await _context.Sizes.OrderBy(c => c.Name).ToListAsync();
            return View(product);
        }
    }
}
