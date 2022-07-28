using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_MVC.DAL;
using Project_MVC.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_MVC.Areas.MultiShopAdmin.Controllers
{
    [Area("MultiShopAdmin")]
    public class ProductInformationController : Controller
    {
        private readonly AppDbContext _context;

        public ProductInformationController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            List<ProductInformation> productInformations = await _context.ProductInformations.Include(p => p.Products).ToListAsync();
            return View(productInformations);
        }
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null || id == 0) return NotFound();
            ProductInformation productInformation = await _context.ProductInformations.Include(p => p.Products).ThenInclude(p => p.ProductImages).FirstOrDefaultAsync(p => p.Id == id);
            if (productInformation == null) return NotFound();
            return View(productInformation);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(ProductInformation productInformation)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            List<ProductInformation> productInformations = await _context.ProductInformations.ToListAsync();
            if (productInformations.Any(p => p.Key.ToLower().Trim() == productInformation.Key.ToLower().Trim()))
            {
                ModelState.AddModelError("Key", "ProductInformation with this Key is already exist");
                return View();
            }
            await _context.ProductInformations.AddAsync(productInformation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null || id == 0) return NotFound();
            ProductInformation productInformation = await _context.ProductInformations.FirstOrDefaultAsync(p => p.Id == id);
            if (productInformation == null) return NotFound();
            return View(productInformation);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Update(int? id, ProductInformation productInformation)
        {
            ProductInformation existed = await _context.ProductInformations.FirstOrDefaultAsync(p => p.Id == id);
            if (!ModelState.IsValid)
            {
                return View(existed);
            }
            if (existed == null) return NotFound();
            _context.Entry(existed).CurrentValues.SetValues(productInformation);
            List<ProductInformation> productInformations = await _context.ProductInformations.ToListAsync();
            if (productInformations.Any(p => p.Key.ToLower().Trim() == existed.Key.ToLower().Trim() && p.Id != existed.Id))
            {
                ModelState.AddModelError("Key", "ProductInformation with this Key is already exist");
                return View(existed);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id == 0) return NotFound();
            ProductInformation existed = await _context.ProductInformations.FirstOrDefaultAsync(s => s.Id == id);
            if (existed == null) return NotFound();
            _context.ProductInformations.Remove(existed);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
