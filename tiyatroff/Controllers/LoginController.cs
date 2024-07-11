using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using tiyatroff.Models;
using NuGet.Protocol.Plugins;
using Microsoft.EntityFrameworkCore;

namespace tiyatroff.Controllers
{
    public class LoginController : Controller
    {
        private readonly DbTiyatroContext _context; 

      

            public LoginController(DbTiyatroContext context)
            {
                _context = context;
            }

            public IActionResult Index()
            {
                return View();
            }

            [HttpPost]
            public async Task<IActionResult> Login(Kullanici logincs)
            {
               
                var user = await _context.Kullanicis
                    .FirstOrDefaultAsync(u => u.Eposta == logincs.Eposta && u.Sifre == logincs.Sifre); 

                if (user != null)
                {
                    
                    List<Claim> claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier, user.KullaniciId.ToString()), 
                    new Claim(ClaimTypes.Name, user.Eposta), 
                    
                };

                    ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    AuthenticationProperties prop = new AuthenticationProperties()
                    {
                        AllowRefresh = true,
                        IsPersistent = logincs.Status 
                    };

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity), prop);

                    return RedirectToAction("Index", "Gosterims");
                }
                else
                {
                    ViewData["OnayMesaji"] = "Yanlış şifre veya Eposta";
                    return View();
                }
            }

            public IActionResult Login()
            {
                ClaimsPrincipal claimuser = HttpContext.User;
                if (claimuser.Identity.IsAuthenticated)
                    return RedirectToAction("Index", "Home");

                return View();
            }
        }
}
