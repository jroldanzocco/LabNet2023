using System;
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
        [RegularExpression(@"^[A-Za-záéíóúÁÉÍÓÚñÑ]+$")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }
        [Required]
        [StringLength(20)]
        [RegularExpression(@"^[A-Za-záéíóúÁÉÍÓÚñÑ]+$")]
        [Display(Name = "Apellido")]
        public string Apellido { get; set; }
        [Required]
        [StringLength(30)]
        [RegularExpression(@"^[A-Za-záéíóúÁÉÍÓÚñÑ]+$")]
        [Display(Name = "Rol")]
        public string Rol { get; set; }
    }
}