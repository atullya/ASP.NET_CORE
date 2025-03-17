using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationAndAuthorizationDemo.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public IActionResult Dashboard() => View();

        [Authorize(Roles = "Admin")]
        public IActionResult Contact() => View();

        [Authorize(Roles = "Admin")]
        public IActionResult AdminPanel() => View();

        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            ViewData["returnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        public IActionResult Login(string uname, string pass, string returnUrl)
        {
            if (uname == "atullya" && pass == "atullya")
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, uname),
                    new Claim(ClaimTypes.Name, uname),
                    new Claim(ClaimTypes.Role, "Admin")
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                HttpContext.SignInAsync(principal);

                // Redirect Admin users to AdminPanel
                return RedirectToAction("AdminPanel");
            }
            return View();
        }
    }
}
