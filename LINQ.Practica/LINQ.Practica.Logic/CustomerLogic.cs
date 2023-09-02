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
        public Customers ObtenerCliente()
        {
            var cliente = _context.Customers.FirstOrDefault();
            if (cliente != null)
                return cliente;
            else
                throw new Exception("La tabla clientes esta vacia");
        }
    }
}
