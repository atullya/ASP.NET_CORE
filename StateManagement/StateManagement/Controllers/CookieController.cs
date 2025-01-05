using Microsoft.AspNetCore.Mvc;
using StateManagement.Models;

namespace StateManagement.Controllers
{
    public class CookieController : Controller
    {
        //cookie is a information of user like id, phone, username which stored in client's browser to track client activity.
        //to create cookie, cookieOption is used
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
       //controller for creating cookie
       public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Person u)
        {
            //creating cookie
            CookieOptions cookie=new CookieOptions();
            //expire time limit of cookie. here it expire after 10 sec
            cookie.Expires = DateTime.Now.AddSeconds(5);
            //setting cookie variable
            Response.Cookies.Append("Username",u.Name, cookie);
            //var       value
            ViewBag.saved = "Cookie saved";

            return View("Index");

        }
        public IActionResult Test()
        {
            //accessing cookie and placing in viewbag
            ViewBag.msg = Request.Cookies["Username"].ToString();
            
            return View();                          //cookie variable

        }
    }
}
