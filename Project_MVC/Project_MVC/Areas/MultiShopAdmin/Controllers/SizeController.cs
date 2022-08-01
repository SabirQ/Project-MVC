using Microsoft.AspNetCore.Authorization;
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
    //[Authorize(Roles = "Admin")]
    public class SizeController : Controller
    {
        private readonly AppDbContext _context;

        public SizeController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            List<Size> sizes = await _context.Sizes.ToListAsync();

            return View(sizes);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(Size size)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            List<Size> sizes = await _context.Sizes.ToListAsync();
            if (sizes.Any(s => s.Name.ToLower().Trim() == size.Name.ToLower().Trim()))
            {
                ModelState.AddModelError("Name", "Size with this Name is already exist");
                return View();
            }
            await _context.Sizes.AddAsync(size);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null || id == 0) return NotFound();
            Size size = await _context.Sizes.FirstOrDefaultAsync(c => c.Id == id);
            if (size == null) return NotFound();
            return View(size);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Update(int? id, Size size)
        {
            Size existed = await _context.Sizes.FirstOrDefaultAsync(c => c.Id == id);
            if (!ModelState.IsValid)
            {
                return View(existed);
            }
            if (existed == null) return NotFound();
            _context.Entry(existed).CurrentValues.SetValues(size);
            List<Size> sizes = await _context.Sizes.ToListAsync();
            if (sizes.Any(s => s.Name.ToLower().Trim() == existed.Name.ToLower().Trim() && s.Id != existed.Id))
            {
                ModelState.AddModelError("Name", "Size with this Name is already exist");
                return View(existed);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id == 0) return NotFound();
            Size existed = await _context.Sizes.FirstOrDefaultAsync(c => c.Id == id);
            if (existed == null) return NotFound();
            _context.Sizes.Remove(existed);
            await _context.SaveChangesAsync();
            return Json(new { status = 200 });
        }
    }
}
