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
    public class SliderController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public SliderController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            List<Slider> sliders = await _context.Sliders.ToListAsync();
            
            return View(sliders);
        }
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null || id == 0) return NotFound();
            Slider slider = await _context.Sliders.FirstOrDefaultAsync(s=> s.Id == id);
            if (slider == null) return NotFound();
            return View(slider);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(Slider slider)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (slider.Photo == null)
            {
                ModelState.AddModelError("Photo", "You have to choose Image");
                return View();
            }
            if (!slider.Photo.CheckImage(2))
            {
                ModelState.AddModelError("Photo", "Please choose valid image file");
                return View();
            }
            List<Slider> sliders= await _context.Sliders.ToListAsync();
            while (sliders.Any(s => s.Order==slider.Order))
            {
                slider.Order++;
            } 
            slider.Image = await slider.Photo.FileCreate(await CheckExistence(slider.Photo), _env.WebRootPath, "assets/img");
            await _context.Sliders.AddAsync(slider);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null || id == 0) return NotFound();
            Slider slider = await _context.Sliders.FirstOrDefaultAsync(s => s.Id == id);
            if (slider == null) return NotFound();
            return View(slider);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Update(int? id, Slider slider)
        {
            Slider existed = await _context.Sliders.FirstOrDefaultAsync(s => s.Id == id);
            if (!ModelState.IsValid)
            {
                return View(existed);
            }
            if (existed == null) return NotFound();
            Slider sameOrder =await _context.Sliders.FirstOrDefaultAsync(s => s.Order == slider.Order);
            if (sameOrder != null)
            {
                sameOrder.Order = existed.Order;
                existed.Order = slider.Order;
            }
            if (slider.Photo != null)
            {
                if (!slider.Photo.CheckImage(2))
                {
                    ModelState.AddModelError("Photo", "Please choose valid image file");
                    return View(existed);
                }
                FileValidator.FileDelete(_env.WebRootPath, "assets/img", existed.Image);
                _context.Entry(existed).CurrentValues.SetValues(slider);
                existed.Image = await slider.Photo.FileCreate(await CheckExistence(slider.Photo), _env.WebRootPath, "assets/img");
            }
            else
            {
                string filename = existed.Image;
                _context.Entry(existed).CurrentValues.SetValues(slider);
                existed.Image = filename;
            } 
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id == 0) return NotFound();
            Slider existed = await _context.Sliders.FirstOrDefaultAsync(s => s.Id == id);
            if (existed == null) return NotFound();
           
            FileValidator.FileDelete(_env.WebRootPath, "assets/img", existed.Image);
            _context.Sliders.Remove(existed);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<string> CheckExistence(IFormFile file)
        {
            string filename = file.FileName;
            List<Slider> sliders = await _context.Sliders.ToListAsync();
            if (sliders!= null)
            {
                if (sliders.Any(p => p.Image == file.FileName))
                {
                    filename = string.Concat(Guid.NewGuid(), file.FileName);
                }
            }
            return filename;
        }
    }
}
