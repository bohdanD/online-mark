using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineMark.Models
{
    public class Mark
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Display(Name = "Опис")]
        public string Description { get; set; }
        [Display(Name = "Оцінка")]
        public string Value { get; set; }
        [Required]
        [Display(Name = "Дата")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public virtual Student Student { get; set; }
        [Required]
        [HiddenInput(DisplayValue = false)]
        public int StudentId { get; set; }
        public virtual Course Course { get; set; }
        [Required]
        [HiddenInput(DisplayValue = false)]
        public int CourseId { get; set; }
    }
}