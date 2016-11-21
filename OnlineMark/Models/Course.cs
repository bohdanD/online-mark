﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineMark.Models
{
    public class Course
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Назва")]
        public string Name { get; set; }
        [Required]
        [HiddenInput(DisplayValue = false)]
        public int LecturerId { get; set; }
        public virtual Lecturer Lecturer { get; set; }
        public IEnumerable<Mark> Marks { get; set; }


        public virtual ICollection<Student> Students { get; set; }
        
        public Course()
        {
            Students = new HashSet<Student>();
        } 
    }
}