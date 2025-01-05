using Microsoft.AspNetCore.Mvc;
using StateManagement.Models;
namespace StateManagement.Controllers
{
    public class SessionController : Controller
    {
        //session is used to save user's information throught one
        //particular login time. after logout the information of 
        //session is destroyed. to create session either HTTPSession  or
        //response.session is used
        public IActionResult CreateSession()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateSession(User u) { 
            //extracting data from model and setting session variable
            string uname = u.Username;//taking data from User model
            string pass = u.Password;

            HttpContext.Session.SetString("susername", uname);
            //sessionvar,session value
            HttpContext.Session.SetString("spass", pass);
            return RedirectToAction("Index");
        }
        //accessing session variable in next page
        public IActionResult Index()
        {
            //accessing session variable and sending to view
            ViewBag.firstSession = HttpContext.Session.GetString("susername");
            ViewBag.secondSession = HttpContext.Session.GetString("spass");

            return View();
        }
    }
}
