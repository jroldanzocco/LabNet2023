using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Northwind.To.EF.WebAPI.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
    }
}