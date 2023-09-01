using Northwind.To.EF.CommonComponents;
using Northwind.To.EF.Entities;
using Northwind.To.EF.Logic;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.To.EF.UI
{
    class Menu
    {
        private MenuClientes menuClientes;
        public Menu(){}
        public void Mostrar()
        {
            int opcion = -1;
            while (opcion != 4)
            {
                Console.WriteLine("1 - Clientes CRUD");
                Console.WriteLine("2 - Empleados CRUD");
                Console.WriteLine("3 - Proveedores CRUD");
                Console.WriteLine("4 - Salir");
                Console.Write("Ingrese su opcion: ");

                int.TryParse(Console.ReadLine(), out opcion);

                Console.Clear();

                switch (opcion)
                {
                    case 1:
                        menuClientes = new MenuClientes();
                        menuClientes.MostrarMenu();
                        break;
                    case 2:

                        break;
                    case 3:

                        break;
                    case 4:
                        Console.WriteLine("Gracias por usar el programa");
                        EsperarUsuario();
                        break;
                    default:
                        Console.WriteLine("Ingresa un numero valido.");
                        break;
                }
            }
        }
        protected void EsperarUsuario()
        {
            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }
        
    }
}
