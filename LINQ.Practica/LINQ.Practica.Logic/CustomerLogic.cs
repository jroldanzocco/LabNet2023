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
        public List<string> GetCustomerNames()
        {
            var clientes = (from c in _context.Customers
                            orderby c.ContactName
                            select c.ContactName).ToList();

            return clientes;
        }
        public List<CustomerOrder> GetCustomerOrderWA()
        {
            DateTime fechaFiltro = new DateTime(1997, 1, 1);

            var clientJoin = (from c in _context.Customers
                              join o in _context.Orders
                              on c.CustomerID equals o.CustomerID
                              where c.Region == "WA" && o.OrderDate > fechaFiltro
                              select new CustomerOrder
                              {
                                  CustomerID = c.CustomerID,
                                  CompanyName = c.CompanyName,
                                  Region = c.Region,
                                  OrderDate = o.OrderDate
                              }).ToList();
            return clientJoin;
        }

        public List<Customers> GetThreeCustomersFromWA()
        {
            return _context.Customers.Where(c => c.Region == "WA")
                    .OrderBy(c => c.CompanyName)
                    .Take(3).ToList();
        }
    }
    
}

