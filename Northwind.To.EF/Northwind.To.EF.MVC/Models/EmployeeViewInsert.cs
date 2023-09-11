using System.ComponentModel.DataAnnotations;

namespace Northwind.To.EF.MVC.Models
{
    public class EmployeeViewInsert
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