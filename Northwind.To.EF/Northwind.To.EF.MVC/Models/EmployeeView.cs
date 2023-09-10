using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Northwind.To.EF.MVC.Models
{
    public class EmployeeView
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
    }
}