using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OnlineMark.Models
{
    public class MarksDbInitializer : DropCreateDatabaseAlways<MarksContext>
    {
        protected override void Seed(MarksContext context)
        {

            Lecturer lec1 = new Lecturer()
            {
                Id = 1,
                Name = "Vasyl Vasylyovich",
                Login = "vasya",
                
            };
            Student stud = new Student()
            {
                Id = 1,
                Name = "Vasya Pupkin",
                Login = "pussydestroyer",
              
                Group = "fei-34"
            };
            Course course = new Course()
            {
                Id = 1,
                Name = "Hujnya",
                LecturerId = lec1.Id,
               Students = new List<Student>() { stud}
            };
            Mark mark = new Mark()
            {
                Id = 1,
                Value = "5",
                Description = "lab1",
                Date = DateTime.Today,
                CourseId = course.Id,
                StudentId = stud.Id
            };

            context.Students.Add(stud);
            context.Lecturers.Add(lec1);
            context.Courses.Add(course);
            context.Marks.Add(mark);

            base.Seed(context);
        }
    }
}