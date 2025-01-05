using Microsoft.AspNetCore.Mvc;

namespace StateManagement.Controllers
{
    public class PractiseController : Controller
    {
        //state managgement refers to saving the user information
        //through the session
        //if state menagement is not handle then we have login each
        //time for each redirect
        //server side state management:
       //1. temp data:manage the state in page level (for only one page)
       //2. session
        public IActionResult Index()
        {
            //used to pass data from controller to view my manging state
            ViewData["data1"] = "this is data from view data";
            //keword  var           data
            ViewBag.data2 = "this is data from view bag"; //viewBag ko lagi . garney [] na garney
            TempData["data3"] = "data from temp data"; //temp bhaneko temporary data 
            return View();
        }
        public IActionResult AboutUs()
        {
            return View();
        }
    }
}
