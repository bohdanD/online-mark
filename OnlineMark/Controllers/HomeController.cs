using OnlineMark.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace OnlineMark.Controllers
{
    public class HomeController : Controller
    {
        MarksContext db = new MarksContext();
        // GET: Home
        public async Task<ActionResult> Index()
        {
            List<Student> list = await db.Students.ToListAsync();
            ViewBag.Students = list;
            return View();
        }

        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Add(string Name, string Login, string Password, string Group)
        {
            //Student student;
            //Lecturer lec;
            //if (!string.IsNullOrEmpty(Group))
            //{ 
            //    student = new Student()
            //    {
            //        Name = Name,
            //        Login = Login,
            //        Password = Password,
            //        Group = Group
            //    };
            //    db.Students.Add(student);
            //}
            //else
            //{
            //    lec = new Lecturer()
            //    {
            //        Name = Name,
            //        Login = Login,
            //        Password = Password
            //    };
            //    db.Lecturers.Add(lec);
            //}
            //await db.SaveChangesAsync();

            return View();
        }
    }
}