using Northwind.To.EF.Entities;
using Northwind.To.EF.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.To.EF.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomersLogic logicaClientes = new CustomersLogic();

            foreach(Customers cliente in logicaClientes.GetAll())
            {
                Console.WriteLine(cliente.CompanyName);
            }

            Console.ReadKey();
        }
    }
}
