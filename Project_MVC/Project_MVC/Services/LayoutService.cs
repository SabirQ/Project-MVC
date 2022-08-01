
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Project_MVC.DAL;
using Project_MVC.Models;
using Project_MVC.Utilities;
using Project_MVC.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_MVC.Services
{
    public class LayoutService
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _http;
        private readonly UserManager<AppUser> _userManager;

        public LayoutService(AppDbContext context, IHttpContextAccessor http,UserManager<AppUser> userManager)
        {
            _context = context;
            _http = http;
            _userManager = userManager;
        }
        public List<Setting> GetSettings()
        {
            List<Setting> settings = _context.Settings.ToList();
            return settings;
        }
        
        public async Task<List<BasketItemVM>> GetBasket()
        {   List<BasketItemVM> items=new List<BasketItemVM>();

            if (_http.HttpContext.User.Identity.IsAuthenticated)
            {
                List<Product> products = _context.Products.Include(p => p.Discount).ToList();
                List<Color> colors = _context.Colors.ToList();
                List<Size> sizes = _context.Sizes.ToList();
                AppUser user = await _userManager.FindByNameAsync(_http.HttpContext.User.Identity.Name);
                List<BasketItem> basketItems= await _context.BasketItems.Where(p=>p.AppUserId==user.Id && p.OrderId == null).ToListAsync();
                if (basketItems != null)
                {
                    for (int i = 0; i <basketItems.Count; i++)
                    {
                        if (!products.Exists(p => p.Id == basketItems[i].ProductId) || !colors.Exists(p => p.Id == basketItems[i].ColorId) || !sizes.Exists(p => p.Id == basketItems[i].SizeId))
                        {
                            _context.BasketItems.Remove(basketItems[i]);
                        }
                    }
                    _context.SaveChanges();
                    foreach (BasketItem item in basketItems)
                    {
                        BasketItemVM basketItem = new BasketItemVM
                        {
                            Product = item.Product,
                            Color = item.Color,
                            Size = item.Size,
                            Price = item.Price,
                            Quantity = item.Quantity
                        };
                        items.Add(basketItem);

                    }
                    return items;
                }
            }

            
            string basketStr = _http.HttpContext.Request.Cookies["Basket"];
            if (!string.IsNullOrEmpty(basketStr))
            {
                List<Product> products = _context.Products.Include(p => p.Discount).ToList();
                List<Color> colors = _context.Colors.ToList();
                List<Size> sizes = _context.Sizes.ToList();
                BasketVM basket = JsonConvert.DeserializeObject<BasketVM>(basketStr);
                
                    for (int i = 0; i < basket.BasketCookieItemVMs?.Count; i++)
                    {
                        if (!products.Exists(p => p.Id == basket.BasketCookieItemVMs[i].Id) || !colors.Exists(p => p.Id == basket.BasketCookieItemVMs[i].ColorId) || !sizes.Exists(p => p.Id == basket.BasketCookieItemVMs[i].SizeId))
                        {
                            basket.BasketCookieItemVMs.Remove(basket.BasketCookieItemVMs[i]);
                        }
                    }
                    foreach (BasketCookieItemVM cookie in basket.BasketCookieItemVMs)
                    {
                        Product product = products.FirstOrDefault(p => p.Id == cookie.Id);
                        BasketItemVM basketItem = new BasketItemVM
                        {
                            Product = product,
                            Color = colors.FirstOrDefault(p => p.Id == cookie.ColorId),
                            Size = sizes.FirstOrDefault(p => p.Id == cookie.SizeId),
                            Price = product.CheckDiscount(),
                            Quantity = cookie.Quantity,
                        };
                        items.Add(basketItem);
                    }
                
               
            }
            return items;
        }
        public async Task<List<WishlistItemVM>> GetWishlist()
        {
            List<WishlistItemVM> items = new List<WishlistItemVM>();

            if (_http.HttpContext.User.Identity.IsAuthenticated)
            {
                List<Product> products = _context.Products.Include(p => p.Discount).ToList();
                AppUser user = await _userManager.FindByNameAsync(_http.HttpContext.User.Identity.Name);
                List<WishlistItem> wishlistItems = await _context.WishlistItems.Where(p => p.AppUserId == user.Id).ToListAsync();
                if (wishlistItems != null)
                {
                    for (int i = 0; i < wishlistItems.Count; i++)
                    {
                        if (!products.Exists(p => p.Id == wishlistItems[i].ProductId))
                        {
                            _context.WishlistItems.Remove(wishlistItems[i]);
                        }
                    }
                    _context.SaveChanges();
                    foreach (WishlistItem item in wishlistItems)
                    {
                        WishlistItemVM wishlistItem = new WishlistItemVM
                        {
                            Product = item.Product,
                            Price = item.Price
                        };
                        items.Add(wishlistItem);

                    }
                    return items;
                }
            }
            string wishlistStr = _http.HttpContext.Request.Cookies["Wishlist"];
            if (!string.IsNullOrEmpty(wishlistStr))
            {
                List<Product> products = _context.Products.Include(p => p.Discount).ToList();
                WishlistVM wishlist = JsonConvert.DeserializeObject<WishlistVM>(wishlistStr);

                for (int i = 0; i < wishlist.WishlistCookieItemVMs?.Count; i++)
                {
                    if (!products.Exists(p => p.Id == wishlist.WishlistCookieItemVMs[i].Id))
                    {
                        wishlist.WishlistCookieItemVMs.Remove(wishlist.WishlistCookieItemVMs[i]);
                    }
                }
                foreach (WishlistCookieItemVM cookie in wishlist.WishlistCookieItemVMs)
                {
                    Product product = products.FirstOrDefault(p => p.Id == cookie.Id);
                    WishlistItemVM wishlistItem = new WishlistItemVM
                    {
                        Product = product,
                        Price = product.CheckDiscount()
                    };
                    items.Add(wishlistItem);
                }


            }
            return items;
        }
        public async Task<List<CustomMessage>> GetMessages()
        {
            List<CustomMessage> customMessages = await _context.CustomMessages.ToListAsync();
            return customMessages;
        }
        public async Task<List<Category>> GetCategories()
        {
            List<Category> categories = await _context.Categories.ToListAsync();
            return categories;
        }
    }
}
