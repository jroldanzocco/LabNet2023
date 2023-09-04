using System;

namespace LINQ.Practica.Entities
{
    public class CustomerOrder
    {
        public string CustomerID { get; set; }
        public string CompanyName { get; set; }
        public string Region { get; set; }
        public DateTime? OrderDate { get; set; }
        public int Orders  { get; set; }
    }
}
