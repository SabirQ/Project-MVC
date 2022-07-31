using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_MVC.DAL;
using Project_MVC.Models;
using Project_MVC.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_MVC.Areas.MultiShopAdmin.Controllers
{
    [Area("MultiShopAdmin")]
    public class CategoryController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public CategoryController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            List<Category> categories = await _context.Categories.Include(c => c.Products).ThenInclude(p=>p.ProductImages).ToListAsync();

            return View(categories);
        }
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null || id == 0) return NotFound();
            Category category = await _context.Categories.Include(c=>c.Products).ThenInclude(p => p.ProductImages).Include(c => c.Products).ThenInclude(p => p.Discount).FirstOrDefaultAsync(s => s.Id == id);
            if (category == null) return NotFound();
            return View(category);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (category.Photo == null)
            {
                ModelState.AddModelError("Photo", "You have to choose Image");
                return View();
            }
            if (!category.Photo.CheckImage(2))
            {
                ModelState.AddModelError("Photo", "Please choose valid image file");
                return View();
            }

            category.Image = await category.Photo.FileCreate(await CheckExistence(category.Photo), _env.WebRootPath, "assets/img");
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null || id == 0) return NotFound();
            Category category = await _context.Categories.FirstOrDefaultAsync(s => s.Id == id);
            if (category == null) return NotFound();
            return View(category);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Update(int? id, Category category)
        {
            Category existed = await _context.Categories.FirstOrDefaultAsync(s => s.Id == id);
            if (!ModelState.IsValid)
            {
                return View(existed);
            }
            if (existed == null) return NotFound();

            if (category.Photo != null)
            {
                if (!category.Photo.CheckImage(2))
                {
                    ModelState.AddModelError("Photo", "Please choose valid image file");
                    return View(existed);
                }
                FileValidator.FileDelete(_env.WebRootPath, "assets/img", existed.Image);
                _context.Entry(existed).CurrentValues.SetValues(category);
                existed.Image = await category.Photo.FileCreate(await CheckExistence(category.Photo), _env.WebRootPath, "assets/img");
            }
            else
            {
                string filename = existed.Image;
                _context.Entry(existed).CurrentValues.SetValues(category);
                existed.Image = filename;
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id == 0) return NotFound();
            Category existed = await _context.Categories.Include(c=>c.Products).ThenInclude(p=>p.ProductImages).FirstOrDefaultAsync(s => s.Id == id);
            if (existed == null) return NotFound();
           
            if (existed.Products!=null)
            {
                foreach (Product product in existed.Products)
                {
                    foreach (var item in product.ProductImages)
                    {
                        FileValidator.FileDelete(_env.WebRootPath, "assets/img", item.Name);
                        _context.ProductImages.Remove(item);
                    }
                    _context.Products.Remove(product);
                }
            }
            FileValidator.FileDelete(_env.WebRootPath, "assets/img", existed.Image);
            _context.Categories.Remove(existed);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<string> CheckExistence(IFormFile file)
        {
            string filename = file.FileName;
            List<Category> categories = await _context.Categories.ToListAsync();
            if (categories != null)
            {
                if (categories.Any(p => p.Image == file.FileName))
                {
                    filename = string.Concat(Guid.NewGuid(), file.FileName);
                }
            }
            return filename;
        }
    }
}
