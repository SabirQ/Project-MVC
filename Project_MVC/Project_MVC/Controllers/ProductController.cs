using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
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
        public async Task<IActionResult> Index(int? id, int page )
        {
            ViewBag.CurrentPage = page;
            
            if (id != null && id != 0)
            {
                //Category category = await _context.Categories.Include(c => c.Products).ThenInclude(p=>p.ProductImages).FirstOrDefaultAsync(c => c.Id == id);
                List<Product> related= await _context.Products.Where(p => p.CategoryId == id).Include(p => p.ProductImages).ToListAsync();
                if (related != null)
                {
                    ViewBag.TotalPage = Math.Ceiling(related.Count / 9m);
                    return View(related.Skip(page*9).Take(9));
                }
            }
           
            List<Product> products = await _context.Products.Include(p => p.ProductImages).ToListAsync();
            ViewBag.TotalPage = Math.Ceiling(products.Count / 9m);
            return View(products.Skip(page * 9).Take(9));
        }
        public async Task<IActionResult> Detail(int? id)
        {
           if (id == null || id == 0)
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
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        [ActionName("Detail")]
        public async Task<IActionResult> AddBasket(int? id,Product product)
        { 
            if (id is null||id==0) return NotFound();     
            Product existed = await _context.Products.Include(p => p.ProductImages).Include(p => p.ProductInformation).Include(p => p.Category).FirstOrDefaultAsync(p => p.Id == id);
            ViewBag.Products = await _context.Products.Include(p => p.ProductImages).Where(p => p.Id != id && p.CategoryId == product.CategoryId).ToListAsync();
            ViewBag.Colors = await _context.Colors.OrderBy(c => c.Name).ToListAsync();
            ViewBag.Sizes = await _context.Sizes.OrderBy(c => c.Name).ToListAsync();
            if (product.ColorId == null || product.ColorId == 0 || product.SizeId == null || product.SizeId == 0)
            {
                ModelState.AddModelError(string.Empty, "You have to choose Color and Size");
                return View(existed);
            }
            if (product.Quantity==0)
            {
                ModelState.AddModelError("Quantity", "Quantity have to be greater than zero");
                return View(existed);
            }
            Color existedColor = await _context.Colors.FirstOrDefaultAsync(c=> c.Id == product.ColorId);
            Size existedSize = await _context.Sizes.FirstOrDefaultAsync(s => s.Id == product.SizeId);
            if (existed == null|| existedColor == null || existedSize == null) return NotFound();
            string basketStr = HttpContext.Request.Cookies["Basket"];
            BasketVM basket;

            if (string.IsNullOrEmpty(basketStr))
            {
                BasketCookieItemVM cookieItem = new BasketCookieItemVM
                {
                    Id = existed.Id,
                    Quantity= product.Quantity,
                    ColorId=existedColor.Id,
                    SizeId=existedSize.Id
                };
                basket = new BasketVM();     
                basket.BasketCookieItemVMs = new List<BasketCookieItemVM>();
                basket.BasketCookieItemVMs.Add(cookieItem);
                basket.TotalPrice = (decimal)(existed.Price * product.Quantity);

            }
            else
            {
                basket = JsonConvert.DeserializeObject<BasketVM>(basketStr);
                BasketCookieItemVM existedCookie = basket.BasketCookieItemVMs.Find(p => p.Id == id&&p.ColorId==existedColor.Id&&p.SizeId==existedSize.Id);
                if (existedCookie == null)
                {
                    BasketCookieItemVM cookieItem = new BasketCookieItemVM
                    {

                        Id = existed.Id,
                        Quantity = product.Quantity,
                        ColorId = existedColor.Id,
                        SizeId = existedSize.Id
                    };
                    basket.BasketCookieItemVMs.Add(cookieItem);
                    basket.TotalPrice += (decimal)(existed.Price * product.Quantity);
                }
                else
                {
                    basket.TotalPrice += (decimal)(existed.Price * product.Quantity);
                    existedCookie.Quantity += product.Quantity;
                }
            }
            basketStr = JsonConvert.SerializeObject(basket);
            HttpContext.Response.Cookies.Append("Basket", basketStr);
            return RedirectToAction("Index", "Home");
        }
        public IActionResult ShowBasket()
        {
            if (HttpContext.Request.Cookies["Basket"] == null) return NotFound();
            BasketVM basket = JsonConvert.DeserializeObject<BasketVM>(HttpContext.Request.Cookies["Basket"]);
            return Json(basket);
        }
    }
}
