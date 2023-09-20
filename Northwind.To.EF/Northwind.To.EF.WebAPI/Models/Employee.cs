using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Northwind.To.EF.WebAPI.Models
{
    public class Employee
    { 
        public int Id { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z]+( [a-zA-Z]+)*$", ErrorMessage = "Solo se permite letras")]
        [StringLength(10, ErrorMessage = "Maximo 10 caracteres")]
        [MinLength(2, ErrorMessage = "Minimo dos caracteres.")]
        public string FirstName { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z]+( [a-zA-Z]+)*$", ErrorMessage = "Solo se permite letras")]
        [StringLength(20, ErrorMessage = "Maximo 20 caracteres")]
        [MinLength(2, ErrorMessage = "Minimo dos caracteres.")]
        public string LastName { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z]+( [a-zA-Z]+)*$", ErrorMessage = "Solo se permite letras")]
        [StringLength(30, ErrorMessage = "Maximo 30 caracteres")]
        [MinLength(2, ErrorMessage = "Minimo dos caracteres.")]
        public string Title { get; set; }
    }
}