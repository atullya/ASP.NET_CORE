using EFCoreNCCSB.Models;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreNCCSB.Controllers
    //controller is responsible for transferring the request and 
    //handling the income request
    //to interact with database and table context class (StudentContext)
    //will be used
{
    public class StudentController : Controller
    {
        //setting the boject os Student Context
        private readonly StudentContext sc;
        public StudentController(StudentContext sc)
        {
            this.sc = sc;
        }
        [HttpGet]
        public IActionResult AddStudent()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddStudent(InsertStudent s)
        {
            var s1 = new Student()
            {
                //lefthandside=table and righthand side=form
                Id = s.Id,//form's id->table.id
                Name = s.Name,
                Gender = s.Gender,
                Faculty = s.Faculty,
                Fee = s.Fee
            };
            //transfering into database table
            sc.Students.Add(s1);
            sc.SaveChanges();
            return RedirectToAction("Index");  

        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
