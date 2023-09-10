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
        [RegularExpression(@"^[A-Za-záéíóúÁÉÍÓÚñÑ]+$", ErrorMessage = "El nombre solo puede contener letras y acentos.")]
        [Display()]
        public string Nombre { get; set; }
        [Required]
        [StringLength(10)]
        [RegularExpression(@"^[A-Za-záéíóúÁÉÍÓÚñÑ]+$", ErrorMessage = "El nombre solo puede contener letras y acentos.")]
        public string Apellido { get; set; }
        [Required]
        [StringLength(10)]
        public string Rol { get; set; }
    }
}