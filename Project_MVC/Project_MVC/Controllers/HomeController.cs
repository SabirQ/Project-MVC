using Microsoft.AspNetCore.Authorization;
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
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public HomeController(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        
        public async Task<IActionResult> Index()
        {
            HomeVM homeVM = new HomeVM
            {
                Products = await _context.Products.Include(p => p.ProductImages).ToListAsync(),
                Adds= await _context.Adds.ToListAsync(),
                Sliders= await _context.Sliders.ToListAsync(),
                Categories= await _context.Categories.Include(p => p.Products).ToListAsync()
            };
            return View(homeVM);
        }
        public IActionResult Contact()
        {
            return View();
        }
        public async Task<IActionResult> Cart()
        {
            ViewBag.BasketItems = null;
            if (User.Identity.IsAuthenticated) {
                AppUser user = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);
                if (user != null)
                {
                    List<BasketItem> items = await _context.BasketItems.Include(b => b.AppUser).Include(b => b.Color).Include(b => b.Size).Include(b => b.Product).ThenInclude(p => p.ProductImages).Where(b => b.AppUserId == user.Id && b.OrderId == null).ToListAsync();
                    ViewBag.BasketItems = items;
                    decimal TotalPrice = 0;
                    foreach (var item in items)
                    {
                        TotalPrice += item.Price * item.Quantity;
                    }
                    ViewBag.TotalPrice = TotalPrice;
                    return View();
                }
            }
            else
            {
                string basketStr = HttpContext.Request.Cookies["Basket"];
                BasketVM basket;
                List<BasketItemVM> basketItems = new List<BasketItemVM>();
                if (!string.IsNullOrEmpty(basketStr))
                {
                    decimal TotalPrice = 0;
                    basket = JsonConvert.DeserializeObject<BasketVM>(basketStr);
                    foreach (BasketCookieItemVM cookie in basket.BasketCookieItemVMs)
                    {
                        Product product = await _context.Products.Include(p => p.ProductImages).Include(p => p.Discount).FirstOrDefaultAsync(c => c.Id == cookie.Id);
                        BasketItemVM basketItem = new BasketItemVM
                        {
                            Product =product,
                            Color = await _context.Colors.FirstOrDefaultAsync(c => c.Id == cookie.ColorId),
                            Size = await _context.Sizes.FirstOrDefaultAsync(s => s.Id == cookie.SizeId),
                            Quantity = cookie.Quantity,
                            Price=product.CheckDiscount()
                        };
                        TotalPrice += basketItem.Price * basketItem.Quantity;
                        basketItems.Add(basketItem);
                    }
                    ViewBag.BasketItems = basketItems;
                    ViewBag.TotalPrice = TotalPrice;
                }
            }
            return View();
        }

        public async Task<IActionResult> AddWishlist(int? id)
        {
            if (id is null || id == 0) return NotFound();
            Product existed = await _context.Products.Include(p => p.ProductImages).Include(p => p.Discount).Include(p => p.ProductInformation).Include(p => p.Category).FirstOrDefaultAsync(p => p.Id == id);
            if (existed == null) return NotFound();
            if (User.Identity.IsAuthenticated && User.IsInRole("Customer"))
            {
                AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
                if (user == null) return NotFound();
                WishlistItem userItem = await _context.WishlistItems.FirstOrDefaultAsync(b => b.AppUserId == user.Id && b.ProductId == existed.Id);
                if (userItem == null)
                {
                    userItem = new WishlistItem
                    {
                        Product = existed,
                        AppUser = user,
                        Price = existed.CheckDiscount(),
                    };
                    _context.WishlistItems.Add(userItem);
                }
                else
                {
                    _context.WishlistItems.Remove(userItem);
                }
                await _context.SaveChangesAsync();
            }
            else
            {
                string wishlistStr = HttpContext.Request.Cookies["Wishlist"];
                WishlistVM wishlist;

                if (string.IsNullOrEmpty(wishlistStr))
                {
                    wishlist = new WishlistVM();
                    wishlist.WishlistCookieItemVMs = new List<WishlistCookieItemVM>();
                    wishlist.WishlistCookieItemVMs.Add(CreateCookieItem(existed));
                }
                else
                {
                    wishlist = JsonConvert.DeserializeObject<WishlistVM>(wishlistStr);
                    WishlistCookieItemVM existedCookie = wishlist.WishlistCookieItemVMs.Find(p => p.Id == id);
                    if (existedCookie == null)
                    {
                        wishlist.WishlistCookieItemVMs.Add(CreateCookieItem(existed));
                    }
                    else
                    {
                       wishlist.WishlistCookieItemVMs.Remove(existedCookie);
                    }
                }
                wishlistStr = JsonConvert.SerializeObject(wishlist);
                HttpContext.Response.Cookies.Append("Wishlist", wishlistStr);
            }

            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> Wishlist()
        {
            ViewBag.WishlistItems = null;
            if (User.Identity.IsAuthenticated)
            {
                AppUser user = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);
                if (user != null)
                {
                    List<WishlistItem> items = await _context.WishlistItems.Include(b => b.AppUser).Include(b => b.Product).ThenInclude(p => p.ProductImages).Where(b => b.AppUserId == user.Id).ToListAsync();
                    ViewBag.WishlistItems = items;
                    return View();
                }
            }
            else
            {
                string wishlistStr = HttpContext.Request.Cookies["Wishlist"];
                WishlistVM wishlist;
                List<WishlistItemVM> wishlistItems = new List<WishlistItemVM>();
                if (!string.IsNullOrEmpty(wishlistStr))
                {
                   
                    wishlist = JsonConvert.DeserializeObject<WishlistVM>(wishlistStr);
                    foreach (WishlistCookieItemVM cookie in wishlist.WishlistCookieItemVMs)
                    {
                        Product product = await _context.Products.Include(p => p.ProductImages).Include(p => p.Discount).FirstOrDefaultAsync(c => c.Id == cookie.Id);
                        WishlistItemVM wishlistItem = new WishlistItemVM
                        {
                            Product = product, 
                            Price = product.CheckDiscount()
                        };
                       
                        wishlistItems.Add(wishlistItem);
                    }
                    ViewBag.WishlistItems = wishlistItems;
                }
            }
            return View();
        }
        public async Task<IActionResult> RemoveWishlist(int? id)
        {
            if (id is null || id == 0) return NotFound();

            if (User.Identity.IsAuthenticated)
            {
                AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
                if (user == null) return NotFound();
                WishlistItem userItem = await _context.WishlistItems.FirstOrDefaultAsync(b => b.AppUserId == user.Id && b.ProductId == id);
                if (userItem == null) return NotFound();
                _context.WishlistItems.Remove(userItem);
                _context.SaveChanges();
            }
            else
            {
                string wishlistStr = HttpContext.Request.Cookies["Wishlist"];
                if (!string.IsNullOrEmpty(wishlistStr))
                {
                    WishlistVM wishlist = JsonConvert.DeserializeObject<WishlistVM>(wishlistStr);
                    WishlistCookieItemVM cookie = wishlist.WishlistCookieItemVMs.FirstOrDefault(p => p.Id == id);
                    if (cookie != null)
                    {
                        wishlist.WishlistCookieItemVMs.Remove(cookie);
                    }
                    wishlistStr = JsonConvert.SerializeObject(wishlist);
                    HttpContext.Response.Cookies.Append("Wishlist", wishlistStr);
                }
            }
            return RedirectToAction("Wishlist", "Home");
        }

        public WishlistCookieItemVM CreateCookieItem(Product product)
        {
            WishlistCookieItemVM cookieItem = new WishlistCookieItemVM
            {
                Id = product.Id,
            };
            return cookieItem;
        }
    }
}
