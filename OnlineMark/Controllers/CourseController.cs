using Newtonsoft.Json;
using OnlineMark.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace OnlineMark.Controllers
{
    [Authorize(Roles = "Lecturer")]
    public class CourseController : Controller
    {
        MarksContext db = new MarksContext();
        
        // GET: Course
        public async Task<ActionResult> Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(AddCourseModel model)
        {
            if (AddCourseModel.IsCourseValid(model.Name))
            {
                if (AddCourseModel.IsGroupValid(model.SelectedGroup))
                {
                    int id = db.Lecturers.Where(i => i.Login.Equals(HttpContext.User.Identity.Name)).FirstOrDefault().Id;
                    var students = db.Students.Where(i => i.Group.Equals(model.SelectedGroup)).ToList();
                    Course course = new Course()
                    {
                        Name = model.Name,
                        LecturerId = id,
                        Aim = model.Aim,
                        ProgramOfCourse = model.ProgramOfCourse,
                        Themes = model.Themes,
                        Students = students
                    };

                    db.Courses.Add(course);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Не правильна назва групи, перевірте будь ласка");
                }
            }
            else
            {
                ModelState.AddModelError("", "Виберіть іншу назву, такий курс вже існує");
            }

            return View("Index", model);
        }

        [HttpGet]
        public ActionResult ShowCourses()
        {
            //TODO: зробити представлення для курсів авторизованого викладача
            int id = db.Lecturers.Where(i => i.Login.Equals(HttpContext.User.Identity.Name)).FirstOrDefault().Id;
            var courses = db.Courses.Where(i => i.LecturerId == id).ToList();
            ViewData["Courses"] = courses;
            ViewBag.CurLecName = db.Lecturers.Where(i => i.Login.Equals(HttpContext.User.Identity.Name)).FirstOrDefault().Name;
            return View();
        }
        [HttpPost]
        public ActionResult ChangeCourse(Course model)
        {
            int id = model.Id;
            if (!string.IsNullOrEmpty(model.Name))
            {
                Course course = db.Courses.Find(id);
                if (course != null)
                {
                    course.Name = model.Name;
                    course.ProgramOfCourse = model.ProgramOfCourse;
                    course.Aim = model.Aim;
                    course.Themes = model.Themes;
                    db.Entry(course).State = EntityState.Modified;
                }
                db.SaveChangesAsync();
            }
            else
            {
                ModelState.AddModelError("", "Не коректне ім'я");
            }
            return RedirectToAction("ShowCourses");
        }

        [HttpGet]
        public ActionResult ShowCourse(int courseId)
        {
            Session["course"] = db.Courses.Find(courseId);
            int id = (Session["course"] as Course).Id;
            var students = ((Course)Session["course"]).Students.ToList();
            int firstStudId = students.FirstOrDefault().Id;
            ViewData["mark1"] = db.Marks.Where(i => i.CourseId == id && i.StudentId == firstStudId).ToList();
            ViewData["students"] = students;
            foreach (var item in students)
            {
                item.Marks = db.Marks.Where(i => i.StudentId == item.Id && i.CourseId == courseId).AsEnumerable();
            }
            ViewData["course"] = Session["course"];

            return View();
        }
        [HttpPost]
        public ActionResult AddMark(AddMarkModel model)
        {
            Course _course = db.Courses.Find(int.Parse(model.returnUrl.Split('=')[1]));
            var students = _course.Students;
            foreach (var item in students)
            {
               
                  db.Marks.Add(new Mark() { Description = model.Description, CourseId = _course.Id, Date = model.Date,
                  StudentId = item.Id}) ;
            }
            db.SaveChanges();
            return Redirect(model.returnUrl);
        }

        [HttpPost]
        [JsonFilter(Param = "values", JsonDataType = typeof(List<SaveMarkVM>))]
        public JsonResult SaveChanges(List<SaveMarkVM> values)
        {
            foreach (var item in values)
            {
                int id = int.Parse(item.id);
                var mark = db.Marks.Where(m => m.Id == id).FirstOrDefault();
                if (mark != null)
                {
                    mark.Value = item.value;
                    mark.Description = item.description;
                    db.Entry(mark).State = EntityState.Modified;
                }
               
            }
            db.SaveChangesAsync();
            return Json(new { Result = "success"});
        }
        [HttpGet]
        public ActionResult ChangeCourse(int courseId)
        {
            Course course = db.Courses.Find(courseId);
            return View(course);
        }
    }
}