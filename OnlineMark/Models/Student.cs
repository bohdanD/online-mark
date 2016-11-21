using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineMark.Models
{
    public class Student
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Ім'я")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Група")]
        public string Group { get; set; }
        [Required]
        [Display(Name = "Логін")]
        public string Login { get; set; }
        public virtual IEnumerable<Mark> Marks { get; set; }


        public virtual ICollection<Course> Courses { get; set; }
        public Student()
        {
            Courses = new HashSet<Course>();
        }
    }
}