using Microsoft.AspNetCore.Identity;
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

namespace Project_MVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public ProductController(AppDbContext context,UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index(int? id, int page=1,int key=1)
        {
            ViewBag.CurrentKey=key;
            ViewBag.CurrentPage = page;
            ViewBag.CurrentCategory = null;
            List<Product> products;
           
            if (id != null && id != 0)
            {
                ViewBag.CurrentCategory = id;
                products=await _context.Products.Where(p => p.CategoryId == id).Include(p => p.ProductImages).Include(p=>p.Discount).Skip((page - 1) * 1).Take(1).ToListAsync();
                if (products == null)return NotFound();
                ViewBag.TotalPage = Math.Ceiling((decimal)_context.Products.Where(p=>p.CategoryId==id).Count() / 1);
            }
            else
            {
                products = await _context.Products.Include(p => p.ProductImages).Include(p => p.Discount).Skip((page - 1) * 2).Take(2).ToListAsync();
                ViewBag.TotalPage = Math.Ceiling((decimal)_context.Products.Count() / 2);
            }
            //products = products.Skip((page - 1) * 2).Take(2)
            switch (key)
            { case 2:
                    List<Product> sorted= products.OrderBy(p => p.Name).ToList();
                    return View(sorted);
                case 3:
                    List<Product> sorted1 = products.OrderBy(p => p.CheckDiscount()).ToList();
                    return View(sorted1);
                case 4:
                    List<Product> sorted2 = products.OrderByDescending(p => p.Id).ToList();
                    return View(sorted2);
            }
            return View(products);
        }
        public async Task<IActionResult> Detail(int? id)
        {
           if (id == null || id == 0)
           {
             return NotFound();
           }       
            Product product = _context.Products.Include(p => p.ProductImages).Include(p => p.Discount).Include(p => p.ProductInformation).Include(p => p.Category).FirstOrDefault(p => p.Id == id);
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
            Product existed = await _context.Products.Include(p => p.ProductImages).Include(p=>p.Discount).Include(p => p.ProductInformation).Include(p => p.Category).FirstOrDefaultAsync(p => p.Id == id);
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
            if (User.Identity.IsAuthenticated && User.IsInRole("Customer"))
            {
                AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
                if (user == null) return NotFound();
                BasketItem userItem = await _context.BasketItems.FirstOrDefaultAsync(b => b.AppUserId == user.Id && b.ProductId == existed.Id&&b.ColorId==existedColor.Id&&b.SizeId==existedSize.Id && b.OrderId == null);
                if (userItem == null)
                {
                    userItem = new BasketItem
                    {
                        Product = existed,
                        AppUser = user,
                        Color = existedColor,
                        Size = existedSize,
                        Quantity = product.Quantity,
                        Price = existed.CheckDiscount(),
                        OrderId=null
                    };
                    _context.BasketItems.Add(userItem);
                }
                else
                {
                    userItem.Quantity+=product.Quantity;
                }
                await _context.SaveChangesAsync();
            }
            else
            {
                string basketStr = HttpContext.Request.Cookies["Basket"];
                BasketVM basket;

                if (string.IsNullOrEmpty(basketStr))
                {
                    basket = new BasketVM();
                    basket.BasketCookieItemVMs = new List<BasketCookieItemVM>();
                    basket.BasketCookieItemVMs.Add(CreateCookieItem(existed, existedColor, existedSize, product.Quantity));
                    basket.TotalPrice = (decimal)(existed.Price * product.Quantity);
                }
                else
                {
                    basket = JsonConvert.DeserializeObject<BasketVM>(basketStr);
                    BasketCookieItemVM existedCookie = basket.BasketCookieItemVMs.Find(p => p.Id == id && p.ColorId == existedColor.Id && p.SizeId == existedSize.Id);
                    if (existedCookie == null)
                    {
                        basket.BasketCookieItemVMs.Add(CreateCookieItem(existed, existedColor, existedSize, product.Quantity));
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
            }
           
            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> RemoveBasket(int? id, int? colorid, int? sizeid)
        {
            if (id is null || id == 0 || colorid is null || colorid == 0 || sizeid is null || sizeid == 0) return NotFound();

            if (User.Identity.IsAuthenticated)
            {
                AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
                if (user == null) return NotFound();
                BasketItem userItem = await _context.BasketItems.FirstOrDefaultAsync(b => b.AppUserId == user.Id && b.ProductId == id && b.ColorId == colorid && b.SizeId == sizeid && b.OrderId == null);
                if (userItem == null) return NotFound();
                _context.BasketItems.Remove(userItem);
                _context.SaveChanges();
            }
            else
            {
                string basketStr = HttpContext.Request.Cookies["Basket"];
                if (!string.IsNullOrEmpty(basketStr))
                {
                    BasketVM basket = JsonConvert.DeserializeObject<BasketVM>(basketStr);
                    BasketCookieItemVM cookie = basket.BasketCookieItemVMs.FirstOrDefault(p => p.Id == id && p.ColorId == colorid && p.SizeId == sizeid);
                    if (cookie != null)
                    {
                        basket.BasketCookieItemVMs.Remove(cookie);
                    }
                    basketStr = JsonConvert.SerializeObject(basket);
                    HttpContext.Response.Cookies.Append("Basket", basketStr);
                }

            }
            return RedirectToAction("Cart", "Home");
        }

        public BasketCookieItemVM CreateCookieItem(Product product,Color color,Size size,int quantity)
        {
            BasketCookieItemVM cookieItem = new BasketCookieItemVM
            {
                Id = product.Id,
                Quantity = quantity,
                ColorId = color.Id,
                SizeId = size.Id
            };
            return cookieItem;
        }
      
    }
}
