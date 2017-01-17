using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineMark.Models
{
    public class AddMarkModel
    {
        [Display(Name = "Опис(назва)")]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Дата")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public string returnUrl { get; set; }
        public AddMarkModel()
        {
            returnUrl = "";
        }
    }
}