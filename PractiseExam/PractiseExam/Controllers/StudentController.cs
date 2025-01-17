using Microsoft.AspNetCore.Mvc;
using PractiseExam.Models;
namespace PractiseExam.Controllers
{
    public class StudentController : Controller
    {
        //setting the object of Student Context
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
                Id = s.Id,
                Name = s.Name,
                Gender= s.Gender,
                Address = s.Address,
                Phone = s.Phone,
                Position=s.Position,

               

            };
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
