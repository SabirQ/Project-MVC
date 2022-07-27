using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_MVC.DAL;
using Project_MVC.Models;
using Project_MVC.Utilities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_MVC.Areas.MultiShopAdmin.Controllers
{
    [Area("MultiShopAdmin")]
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
            Product product =await _context.Products.Include(p => p.ProductImages).Include(p => p.ProductInformation).Include(p => p.Category).FirstOrDefaultAsync(p => p.Id == id);
            if (product == null) return NotFound();
            return View(product);
        }
        public async Task<IActionResult> Create()
        {
            ViewBag.productInformations = await _context.ProductInformations.ToListAsync();
            ViewBag.Categories = await _context.Categories.ToListAsync();
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            ViewBag.productInformations = await _context.ProductInformations.ToListAsync();
            ViewBag.Categories = await _context.Categories.ToListAsync();

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
            TempData["FileName"] = "";
            int count = product.Photos.Count;
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

            if (id == null || id == 0) return NotFound();
            Product product =await _context.Products.Include(p => p.ProductImages).Include(p => p.ProductInformation).Include(p => p.Category).FirstOrDefaultAsync(p => p.Id == id);
            if (product == null) return NotFound();
            return View(product);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Update(int? id,Product product)
        {
            ViewBag.productInformations = await _context.ProductInformations.ToListAsync();
            ViewBag.Categories = await _context.Categories.ToListAsync();

            Product existed =await _context.Products.Include(p => p.ProductImages).Include(p => p.ProductInformation).Include(p => p.Category).FirstOrDefaultAsync(p => p.Id == id);
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
                existed.ProductImages.FirstOrDefault(p => p.Primary == true).Name = await product.MainPhoto.FileCreate(_env.WebRootPath, "assets/img");
                _context.ProductImages.Add(await CreateProImg(product.MainPhoto, existed, true));
            }
            if (product.PhotoIds == null)
            {
                if (product.Photos == null)
                {
                    ModelState.AddModelError("Photos", "You have choose or keep at least 1 image");
                    return View(existed);
                }
                
            }
            return View();
        }
        public async Task<ProductImage> CreateProImg(IFormFile file, Product product,bool result)
        {
            ProductImage image = new ProductImage
            {
                Name = await file.FileCreate(_env.WebRootPath, "assets/img"),
                Primary = result,
                Alt = product.Name,
                Product = product
            };
            return image;
        }
    }
   
}
