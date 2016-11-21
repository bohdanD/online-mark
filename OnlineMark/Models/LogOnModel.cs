using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineMark.Models
{
    public class LogOnModel
    {
        [Required]
        [Display(Name = "Логін")]
        public string UserName{ get; set; }
        [Required]
        [Display(Name = "Пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Запам'ятати мене?")]
        public bool RememberMe { get; set; }
    }
}