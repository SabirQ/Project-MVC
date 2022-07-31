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
    public class DiscountController : Controller
    {
        private readonly AppDbContext _context;

        public DiscountController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            List<Discount> discounts = await _context.Discounts.Include(d=>d.Products).ToListAsync();

            return View(discounts);
        }
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null || id == 0) return NotFound();
            Discount discount = await _context.Discounts.Include(c => c.Products).ThenInclude(p => p.ProductImages).FirstOrDefaultAsync(s => s.Id == id);
            if (discount == null) return NotFound();
            return View(discount);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(Discount discount)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            List<Discount> discounts = await _context.Discounts.ToListAsync();
            if (discounts.Any(s => s.Name.ToLower().Trim() == discount.Name.ToLower().Trim()))
            {
                ModelState.AddModelError("Name", "Discount with this Name is already exist");
                return View();
            }
            await _context.Discounts.AddAsync(discount);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null || id == 0) return NotFound();
            Discount discount = await _context.Discounts.FirstOrDefaultAsync(s => s.Id == id);
            if (discount == null) return NotFound();
            return View(discount);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Update(int? id, Discount discount)
        {
            Discount existed = await _context.Discounts.FirstOrDefaultAsync(s => s.Id == id);
            if (!ModelState.IsValid)
            {
                return View(existed);
            }
            if (existed == null) return NotFound();
            _context.Entry(existed).CurrentValues.SetValues(discount);
            List<Discount> discounts = await _context.Discounts.ToListAsync();
            if (discounts.Any(s => s.Name.ToLower().Trim() == existed.Name.ToLower().Trim() && s.Id != existed.Id))
            {
                ModelState.AddModelError("Name", "Discount with this Name is already exist");
                return View(existed);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id == 0) return NotFound();
            Discount existed = await _context.Discounts.Include(d=>d.Products).FirstOrDefaultAsync(s => s.Id == id);
            if (existed == null) return NotFound();
            if (existed.Products!=null)
            {
                foreach (Product item in existed.Products)
                {
                    item.DiscountId = null;
                }
            }
            _context.Discounts.Remove(existed);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
       
    }
}
