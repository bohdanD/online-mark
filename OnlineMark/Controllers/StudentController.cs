using OnlineMark.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineMark.Controllers
{
    [Authorize(Roles = "Student")]
    public class StudentController : Controller
    {
        MarksContext db = new MarksContext();
        // GET: Student
        public ActionResult Index()
        {
            string Name = HttpContext.User.Identity.Name;
            Student student = db.Students.Where(s => s.Login == Name).FirstOrDefault();
            ViewData["courses"] = student.Courses.ToList();
            return View();
        }
        [HttpGet]
        public ActionResult ShowMarks(int id)
        {
            string Name = HttpContext.User.Identity.Name;
            Student student = db.Students.Where(s => s.Login == Name).FirstOrDefault();
            ViewData["marks"] = db.Marks.Where(m => m.CourseId == id && m.StudentId == student.Id).ToList();
            ViewBag.CourseName = db.Courses.Find(id).Name;
            return View();
        }
    }
}