using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineMark.Models
{
    public class AddCourseModel
    {
        [Required]
        [Display(Name = "Назва курсу")]
        public string Name { get; set; }
        [Display(Name = "Вииберіть групу")]
        public string SelectedGroup { get; set; }

        [Display(Name = "Мета викладання предмету")]
        public string Aim { get; set; }

        [Display(Name = "Програма курсу")]
        public string ProgramOfCourse { get; set; }

        [Display(Name = "Теми занять")]
        public string Themes { get; set; }

        public static bool IsGroupValid(string groupName)
        {
            using (MarksContext db = new MarksContext())
            {
                return db.Students.Any(i => i.Group.Equals(groupName));
            }
        }

        public static bool IsCourseValid(string courseName)
        {
            using (MarksContext db = new MarksContext())
            {
                return !db.Courses.Any(i => i.Name.Equals(courseName));
            }
        }
    }
}