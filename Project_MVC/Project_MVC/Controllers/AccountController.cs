using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Project_MVC.DAL;
using Project_MVC.Models;
using Project_MVC.Utilities;
using Project_MVC.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(AppDbContext context,UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Register(RegisterVM register)
        {
            if (!ModelState.IsValid) return View();
            if (!register.TermsApplied)
            {
                ModelState.AddModelError("TermsApplied", "Please check our terms and conditions");
                return View();
            }

            AppUser user = new AppUser
            {
                Firstname = register.Firstname,
                Lastname = register.Lastname,
                UserName = register.Username,
                Email = register.Email
            };

            IdentityResult result = await _userManager.CreateAsync(user, register.Password);

            if (!result.Succeeded)
            {
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View();
            }
            await _userManager.AddToRoleAsync(user, "Customer");
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Login(LoginVM login)
        {
           
            if (!ModelState.IsValid) return View();

            AppUser user = await _userManager.FindByNameAsync(login.Username);
            if (user is null) return View();


            Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(user, login.Password, login.RememberOn, true);
            if (!result.Succeeded)
            {
                if (result.IsLockedOut)
                {
                    ModelState.AddModelError(string.Empty, "You were blocked for 15 minutes as failed 5 attempts to Login");
                    return View();
                }
                ModelState.AddModelError(string.Empty, "Username or password is incorrect");
                return View();
            }
            string basketStr = HttpContext.Request.Cookies["Basket"];
            if (!string.IsNullOrEmpty(basketStr))
            {
                BasketVM basket = JsonConvert.DeserializeObject<BasketVM>(basketStr);
                List<Product> products = _context.Products.ToList();
                List<Color> colors = _context.Colors.ToList();
                List<Size> sizes = _context.Sizes.ToList();

                for (int i = 0; i < basket.BasketCookieItemVMs.Count; i++)
                {
                        BasketItem userItem = await _context.BasketItems.FirstOrDefaultAsync(b => b.AppUserId == user.Id && b.ProductId == basket.BasketCookieItemVMs[i].Id && b.ColorId == basket.BasketCookieItemVMs[i].ColorId && b.SizeId == basket.BasketCookieItemVMs[i].SizeId&&b.OrderId==null);
                        if (userItem == null)
                        {
                            Product product = await _context.Products.Include(p => p.Discount).FirstOrDefaultAsync(p => p.Id == basket.BasketCookieItemVMs[i].Id);

                            userItem = new BasketItem
                            {
                                ProductId = basket.BasketCookieItemVMs[i].Id,
                                AppUser = user,
                                ColorId = basket.BasketCookieItemVMs[i].ColorId,
                                SizeId = basket.BasketCookieItemVMs[i].SizeId,
                                Quantity = basket.BasketCookieItemVMs[i].Quantity,
                                Price = product.CheckDiscount(),
                                OrderId=null
                            };
                            _context.BasketItems.Add(userItem);
                        }
                        else
                        {
                            userItem.Quantity += basket.BasketCookieItemVMs[i].Quantity;
                        }
                        HttpContext.Response.Cookies.Delete("Basket");

                        await _context.SaveChangesAsync();
                }
            }
            string wishlistStr = HttpContext.Request.Cookies["Wishlist"];
            if (!string.IsNullOrEmpty(wishlistStr))
            {
                WishlistVM wishlist = JsonConvert.DeserializeObject<WishlistVM>(wishlistStr);
                List<Product> products = _context.Products.ToList();
                for (int i = 0; i < wishlist.WishlistCookieItemVMs.Count; i++)
                {
                      WishlistItem wishItem = await _context.WishlistItems.FirstOrDefaultAsync(b => b.AppUserId == user.Id && b.ProductId == wishlist.WishlistCookieItemVMs[i].Id);
                        if (wishItem == null)
                        {
                            Product product = await _context.Products.Include(p => p.Discount).FirstOrDefaultAsync(p => p.Id == wishlist.WishlistCookieItemVMs[i].Id);

                            wishItem = new WishlistItem
                            {
                                ProductId = wishlist.WishlistCookieItemVMs[i].Id,
                                AppUser = user,
                                Price = product.CheckDiscount()
                            };
                            _context.WishlistItems.Add(wishItem);
                        }
                        HttpContext.Response.Cookies.Delete("Wishlist");
                        await _context.SaveChangesAsync();
                }
            }
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        //public async Task<IActionResult> CreateRoles()
        //{
        //    await _roleManager.CreateAsync(new IdentityRole("Customer"));
        //    await _roleManager.CreateAsync(new IdentityRole("Admin"));
        //    return Content("Created");
        //}

    }
}
