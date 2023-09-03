using LINQ.Practica.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ.Practica.Logic
{
    public class CustomerLogic : BaseLogic
    {
        public Customers GetCliente()
        {
            var cliente = _context.Customers.FirstOrDefault();
            if (cliente != null)
                return cliente;
            else
                throw new Exception("La tabla clientes esta vacia");
        }
        public IEnumerable<Customers> GetCustomersFromWA()
        {
            var customersFromWA = from customer in _context.Customers
                                  where customer.Region == "WA"
                                  orderby customer.CompanyName ascending
                                  select customer;

            return customersFromWA;
        }
    }
}

