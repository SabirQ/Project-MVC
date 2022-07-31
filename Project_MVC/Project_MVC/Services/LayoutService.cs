
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
                for (int i = 0; i < basket.BasketCookieItemVMs.Count; i++)
                {
                    if (!products.Exists(p => p.Id== basket.BasketCookieItemVMs[i].Id) || !colors.Exists(p => p.Id == basket.BasketCookieItemVMs[i].ColorId) || !sizes.Exists(p => p.Id == basket.BasketCookieItemVMs[i].SizeId))
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
    }
}
