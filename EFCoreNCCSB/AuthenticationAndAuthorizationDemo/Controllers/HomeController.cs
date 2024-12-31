using System.Diagnostics;
using System.Net.Http.Headers;
using System.Security.Claims;
using AuthenticationAndAuthorizationDemo.Models;
using Microsoft.AspNetCore.Authentication;//req
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;//req
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationAndAuthorizationDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        //to be authroize a person should be authenticate first 
        //ofr authentication and authorization cookie is used as unique id
        //step1: Create controller and use annotation [authorize]
        //step2: add authentication mechanism (cookie) in program
        //stem3: make user to login first if login success then make authorize
        [Authorize]
        public IActionResult Dashboard()
        {
            return View();
        }
        [Authorize(Roles ="Admin")]
        public IActionResult Contact()
        {
            return View();
        }
        //creating login controller for authrntication
        [HttpGet]
        public IActionResult Login(String returnUrl)
        {
            //send url to view for thhis we will use viewData
            ViewData["returnUrl"] = returnUrl;
            return View();
        }
        //creating login action method with post annotation
        //checking authentication:username password if mathced add
        [HttpPost]
        public IActionResult Login(string uname,string pass, string returnUrl)
        {
            if(uname=="atullya" && pass == "atullya")
            {
                //add authorization:claim, claimIdentity, claimPrinciple
                //claim: detial of authorizaton. which identifier to
                List<Claim> cl = new List<Claim>();
                cl.Add(new Claim(ClaimTypes.NameIdentifier,uname));
                cl.Add(new Claim(ClaimTypes.Name, uname));
                //for roles admin:add role
                cl.Add(new Claim(ClaimTypes.Role, "Admin"));
                //claim identity: how to authorize (token or cookie)
                ClaimsIdentity ci=new ClaimsIdentity(cl,CookieAuthenticationDefaults.AuthenticationScheme);
                //clai principle: whom to authorize
                ClaimsPrincipal cp=new ClaimsPrincipal(ci);
                //executing authorization mechanism
                HttpContext.SignInAsync(cp);    
                return RedirectToAction(returnUrl);
            }
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
