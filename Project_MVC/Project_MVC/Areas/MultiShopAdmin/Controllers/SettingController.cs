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
    public class SettingController : Controller
    {
        private readonly AppDbContext _context;

        public SettingController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            List<Setting> settings = await _context.Settings.ToListAsync();

            return View(settings);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(Setting setting)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            List<Setting> settings = await _context.Settings.ToListAsync();
            if (settings.Any(s => s.Key.ToLower().Trim() == setting.Key.ToLower().Trim()))
            {
                ModelState.AddModelError("Key", "Setting with this Key is already exist");
                return View();
            }
            await _context.Settings.AddAsync(setting);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null || id == 0) return NotFound();
            Setting setting = await _context.Settings.FirstOrDefaultAsync(s => s.Id == id);
            if (setting == null) return NotFound();
            return View(setting);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Update(int? id, Setting setting)
        {
            Setting existed = await _context.Settings.FirstOrDefaultAsync(s => s.Id == id);
            if (!ModelState.IsValid)
            {
                return View(existed);
            }
            if (existed == null) return NotFound();
            _context.Entry(existed).CurrentValues.SetValues(setting);
            List<Setting> settings = await _context.Settings.ToListAsync();
            if (settings.Any(s => s.Key.ToLower().Trim() == existed.Key.ToLower().Trim() && s.Id!=existed.Id))
            {
                ModelState.AddModelError("Key", "Setting with this Key is already exist");
                return View(existed);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id == 0) return NotFound();
            Setting existed = await _context.Settings.FirstOrDefaultAsync(s => s.Id == id);
            if (existed == null) return NotFound();
            _context.Settings.Remove(existed);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
