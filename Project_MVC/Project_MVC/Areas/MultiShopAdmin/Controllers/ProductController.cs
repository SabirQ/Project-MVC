using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Project_MVC.DAL;
using Project_MVC.Models;
using Project_MVC.Utilities;
using Project_MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_MVC.Areas.MultiShopAdmin.Controllers
{
    [Area("MultiShopAdmin")]
    //[Authorize(Roles = "Admin")]
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public ProductController(AppDbContext context,IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            List<Product> products = await _context.Products.Include(p=>p.ProductImages).Include(p=>p.Category).ToListAsync();
            return View(products);
        }
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null || id == 0) return NotFound();
            Product product =await _context.Products.Include(p => p.ProductImages).Include(p=>p.Discount).Include(p => p.ProductInformation).Include(p => p.Category).FirstOrDefaultAsync(p => p.Id == id);
            if (product == null) return NotFound();
            return View(product);
        }
        public async Task<IActionResult> Create()
        {
            ViewBag.productInformations = await _context.ProductInformations.ToListAsync();
            ViewBag.Categories = await _context.Categories.ToListAsync();
            ViewBag.Discounts = await _context.Discounts.ToListAsync();
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            ViewBag.productInformations = await _context.ProductInformations.ToListAsync();
            ViewBag.Categories = await _context.Categories.ToListAsync();
            ViewBag.Discounts = await _context.Discounts.ToListAsync();

            if (!ModelState.IsValid)
            {
                return View();
            }
            if (product.MainPhoto==null||product.Photos==null)
            {
                ModelState.AddModelError(string.Empty, "You must choose 1 main photo and at least 1 additional photo");
                return View();
            }
            if (!product.MainPhoto.CheckImage(2))
            {
                ModelState.AddModelError("MainPhoto", "Please choose valid image file");
                return View();
            }

            bool NotEmpty = false;
            TempData["FileName"] = null;
            for (int i = 0; i < product.Photos.Count; i++)
            {
                if (!product.Photos[i].CheckImage(2))
                {
                    TempData["FileName"] += product.Photos[i].FileName + " ";
                    product.Photos.Remove(product.Photos[i]);
                }
                else
                {
                    NotEmpty = true;       
                    _context.ProductImages.Add(await CreateProImg(product.Photos[i], product, false));
                }
            }
            if (!NotEmpty) {
                ModelState.AddModelError("Photos", "Nothing from choosed files was valid");
                return View(); 
            }
            _context.ProductImages.Add(await CreateProImg(product.MainPhoto, product, true));
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int? id)
        {
            ViewBag.productInformations = await _context.ProductInformations.ToListAsync();
            ViewBag.Categories = await _context.Categories.ToListAsync();
            ViewBag.Discounts = await _context.Discounts.ToListAsync();

            if (id == null || id == 0) return NotFound();
            Product product =await _context.Products.Include(p => p.ProductImages).Include(p => p.Discount).Include(p => p.ProductInformation).Include(p => p.Category).FirstOrDefaultAsync(p => p.Id == id);
            if (product == null) return NotFound();
            return View(product);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Update(int? id,Product product)
        {
            ViewBag.productInformations = await _context.ProductInformations.ToListAsync();
            ViewBag.Categories = await _context.Categories.ToListAsync();
            ViewBag.Discounts = await _context.Discounts.ToListAsync();

            Product existed =await _context.Products.Include(p => p.ProductImages).Include(p => p.Discount).Include(p => p.ProductInformation).Include(p => p.Category).FirstOrDefaultAsync(p => p.Id == id);
            if (!ModelState.IsValid)
            {
                return View(existed);
            }
            if (existed == null) return NotFound();
            if (product.MainPhoto!=null)
            {
                if (!product.MainPhoto.CheckImage(2))
                {
                    ModelState.AddModelError("MainPhoto", "Please choose valid image file");
                    return View(existed);
                }
                FileValidator.FileDelete(_env.WebRootPath, "assets/img", existed.ProductImages.FirstOrDefault(p=>p.Primary==true).Name);
                existed.ProductImages.FirstOrDefault(p => p.Primary == true).Name = await product.MainPhoto.FileCreate(await CheckExistence(product.MainPhoto),_env.WebRootPath, "assets/img");
            }
            if (product.PhotoIds == null)
            {
                if (product.Photos == null || product.Photos.Any(p => p.CheckImage(2)!=true))
                {
                    ModelState.AddModelError("Photos", "You have choose or keep at least 1 valid image");
                    return View(existed);
                }
                foreach (var item in existed.ProductImages.Where(p => p.Primary == false))
                {
                    FileValidator.FileDelete(_env.WebRootPath, "assets/img", item.Name);
                    _context.ProductImages.Remove(item);
                }
                for (int i = 0; i < product.Photos.Count; i++)
                {
                    if (!product.Photos[i].CheckImage(2))
                    {
                        TempData["FileName"] += product.Photos[i].FileName + " ";
                        product.Photos.Remove(product.Photos[i]);
                        continue;
                    }
                    _context.ProductImages.Add(await CreateProImg(product.Photos[i], existed, false));
                }
            }
            else
            {
                foreach (var item in existed.ProductImages.Where(p => p.Primary == false))
                {
                    if (!product.PhotoIds.Exists(p => p == item.Id))
                    {
                        FileValidator.FileDelete(_env.WebRootPath, "assets/img", item.Name);
                        _context.ProductImages.Remove(item);

                    }
                }
                if (product.Photos != null)
                {
                    for (int i = 0; i < product.Photos.Count; i++)
                    {
                        if (!product.Photos[i].CheckImage(2))
                        {
                            TempData["FileName"] += product.Photos[i].FileName + " ";
                            product.Photos.Remove(product.Photos[i]);
                            continue;
                        }
                        _context.ProductImages.Add(await CreateProImg(product.Photos[i], existed, false));
                    }
                }
            }
            existed.Name = product.Name;
            existed.Desc = product.Desc;
            existed.Price = product.Price;
            existed.CategoryId = product.CategoryId;
            existed.ProductInformationId=product.ProductInformationId;
            existed.DiscountId=product.DiscountId;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id == 0) return NotFound();
            Product existed = await _context.Products.Include(p => p.ProductImages).Include(p => p.ProductInformation).Include(p => p.Category).FirstOrDefaultAsync(p => p.Id == id);
            if (existed == null) return NotFound();
            foreach (var item in existed.ProductImages)
            {
                FileValidator.FileDelete(_env.WebRootPath, "assets/img", item.Name);
                _context.ProductImages.Remove(item);
            }
            _context.Products.Remove(existed);
            await _context.SaveChangesAsync();
            return Json(new { status = 200 });
        }
        public async Task<ProductImage> CreateProImg(IFormFile file, Product product,bool result)
        {
            ProductImage image = new ProductImage
            {
                Name = await file.FileCreate(await CheckExistence(file),_env.WebRootPath, "assets/img"),
                Primary = result,
                Alt = product.Name,
                Product = product
            };
            return image;
        }
        public async Task<string> CheckExistence(IFormFile file)
        { 
            string filename = file.FileName;
            List<ProductImage> productImages= await _context.ProductImages.ToListAsync();
            if (productImages!=null)
            {
                if (productImages.Any(p => p.Name == file.FileName))
                {
                    filename = string.Concat(Guid.NewGuid(), file.FileName);
                }
            }
            return filename;
        } 
    }
   
}
