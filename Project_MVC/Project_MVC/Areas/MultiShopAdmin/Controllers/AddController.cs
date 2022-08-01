using Microsoft.AspNetCore.Authorization;
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
    //[Authorize(Roles ="Admin")]
    public class AddController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public AddController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            List<Add> adds = await _context.Adds.ToListAsync();

            return View(adds);
        }
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null || id == 0) return NotFound();
            Add add = await _context.Adds.FirstOrDefaultAsync(s => s.Id == id);
            if (add == null) return NotFound();
            return View(add);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(Add add)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (add.Photo == null)
            {
                ModelState.AddModelError("Photo", "You have to choose Image");
                return View();
            }
            if (!add.Photo.CheckImage(2))
            {
                ModelState.AddModelError("Photo", "Please choose valid image file");
                return View();
            }
            
            add.Image = await add.Photo.FileCreate(await CheckExistence(add.Photo), _env.WebRootPath, "assets/img");
            await _context.Adds.AddAsync(add);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null || id == 0) return NotFound();
            Add add = await _context.Adds.FirstOrDefaultAsync(s => s.Id == id);
            if (add == null) return NotFound();
            return View(add);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Update(int? id, Add add)
        {
            Add existed = await _context.Adds.FirstOrDefaultAsync(s => s.Id == id);
            if (!ModelState.IsValid)
            {
                return View(existed);
            }
            if (existed == null) return NotFound();
            
            if (add.Photo != null)
            {
                if (!add.Photo.CheckImage(2))
                {
                    ModelState.AddModelError("Photo", "Please choose valid image file");
                    return View(existed);
                }
                FileValidator.FileDelete(_env.WebRootPath, "assets/img", existed.Image);
                _context.Entry(existed).CurrentValues.SetValues(add);
                existed.Image = await add.Photo.FileCreate(await CheckExistence(add.Photo), _env.WebRootPath, "assets/img");
            }
            else
            {
                string filename = existed.Image;
                _context.Entry(existed).CurrentValues.SetValues(add);
                existed.Image = filename;
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id == 0) return NotFound();
            Add existed = await _context.Adds.FirstOrDefaultAsync(s => s.Id == id);
            if (existed == null) return NotFound();

            FileValidator.FileDelete(_env.WebRootPath, "assets/img", existed.Image);
            _context.Adds.Remove(existed);
            await _context.SaveChangesAsync();
            return Json(new { status = 200 });
        }
        public async Task<string> CheckExistence(IFormFile file)
        {
            string filename = file.FileName;
            List<Add> adds = await _context.Adds.ToListAsync();
            if (adds != null)
            {
                if (adds.Any(p => p.Image == file.FileName))
                {
                    filename = string.Concat(Guid.NewGuid(), file.FileName);
                }
            }
            return filename;
        }
    }
}
