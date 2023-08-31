using Northwind.To.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.To.EF.Logic
{
    public class CustomersLogic : BaseLogic, IABMLLogic<Customers, string>
    {
        public void Add(Customers newEntity)
        {
            _context.Customers.Add(newEntity);

            _context.SaveChanges();
        }

        public void Delete(string id)
        {
            var clienteABorrar = _context.Customers.Where(c => c.CustomerID == id).FirstOrDefault();
            if(clienteABorrar != null)
            {
                _context.Customers.Remove(clienteABorrar);
                _context.SaveChanges();
            }
        }

        public IQueryable<Customers> GetAll()
        {
            return _context.Customers.AsQueryable()
                .OrderByDescending(c => c.CustomerID);
        }

        public Customers GetById(string id)
        {
            var cliente = _context.Customers.Where(c => c.CustomerID == id).FirstOrDefault();

            return cliente;
        }

        public void Update(Customers entity)
        {
            var _clienteAModificar = _context.Customers.Where(c => c.CustomerID == entity.CustomerID).FirstOrDefault();
            if(_clienteAModificar != null)
            {
                _clienteAModificar.ContactName = entity.ContactName;
                _clienteAModificar.City = entity.City;
                _clienteAModificar.Country = entity.Country;
                _context.SaveChanges();
            }
        }
    }
}
