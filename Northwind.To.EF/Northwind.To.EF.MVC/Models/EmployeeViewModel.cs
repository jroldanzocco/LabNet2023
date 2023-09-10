﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Northwind.To.EF.MVC.Models
{
    public class EmployeeViewModel
    {
        [Required]
        [StringLength(10)]
        [RegularExpression(@"^[a-zA-Z]+(\s[a-zA-Z]+)*$", ErrorMessage = "Este campo solo permite letras")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }
        [Required]
        [StringLength(20)]
        [RegularExpression(@"^[a-zA-Z]+(\s[a-zA-Z]+)*$", ErrorMessage = "Este campo solo permite letras")]
        [Display(Name = "Apellido")]
        public string Apellido { get; set; }
        [Required]
        [StringLength(30)]
        [RegularExpression(@"^[a-zA-Z]+(\s[a-zA-Z]+)*$", ErrorMessage = "Este campo solo permite letras")]
        [Display(Name = "Rol")]
        public string Rol { get; set; }
    }
}