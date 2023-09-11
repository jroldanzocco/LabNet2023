using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Northwind.To.EF.MVC.Models
{
    public class EmployeeView
    {
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        [RegularExpression(@"^[a-zA-Z]+(\s[a-zA-Z]+)*$", ErrorMessage = "Este campo solo permite letras")]
        [Display(Name = "Nombre")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(20)]
        [RegularExpression(@"^[a-zA-Z]+(\s[a-zA-Z]+)*$", ErrorMessage = "Este campo solo permite letras")]
        [Display(Name = "Apellido")]
        public string LastName { get; set; }

        [Required]
        [StringLength(30)]
        [RegularExpression(@"^[a-zA-Z]+(\s[a-zA-Z]+)*$", ErrorMessage = "Este campo solo permite letras")]
        [Display(Name = "Rol")]
        public string Title { get; set; }
    }
}


   