using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Project_MVC.DAL;
using Project_MVC.Models;
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

        public LayoutService(AppDbContext context, IHttpContextAccessor http)
        {
            _context = context;
            _http = http;
        }
        public List<Setting> GetSettings()
        {
            List<Setting> settings = _context.Settings.ToList();
            return settings;
        }
        public BasketVM GetBasket()
        {

            string basketStr = _http.HttpContext.Request.Cookies["Basket"];
            if (!string.IsNullOrEmpty(basketStr))
            {
                BasketVM basket = JsonConvert.DeserializeObject<BasketVM>(basketStr);
                List<Product> products= _context.Products.ToList();
                List<Color> colors = _context.Colors.ToList();
                List<Size>sizes = _context.Sizes.ToList();

                for (int i = 0; i < basket.BasketCookieItemVMs.Count; i++)
                {
                    if (!products.Exists(p => p.Id== basket.BasketCookieItemVMs[i].Id) || !colors.Exists(p => p.Id == basket.BasketCookieItemVMs[i].ColorId) || !sizes.Exists(p => p.Id == basket.BasketCookieItemVMs[i].SizeId))
                    {
                        basket.BasketCookieItemVMs.Remove(basket.BasketCookieItemVMs[i]); 
                    }
                }
                    
                
                return basket;
            }

            return null;

        }
    }
}
