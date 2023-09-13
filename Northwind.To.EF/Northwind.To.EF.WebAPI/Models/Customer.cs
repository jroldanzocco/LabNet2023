using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Northwind.To.EF.WebAPI.Models
{
    public class Customer
    {
        [Required]
        [StringLength(5,ErrorMessage = "ID Maximo 5 caracteres")]
        public string CustomerID { get; set; }
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public string ContactName { get; set; }
    }
}