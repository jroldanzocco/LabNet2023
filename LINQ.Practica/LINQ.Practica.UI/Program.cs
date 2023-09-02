using LINQ.Practica.Entities;
using LINQ.Practica.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ.Practica.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerLogic clientes = new CustomerLogic();
            Customers cliente = clientes.ObtenerCliente();
            Console.WriteLine($"{cliente.CompanyName} - {cliente.CustomerID}" );

            Console.ReadKey();
        }
    }
}
