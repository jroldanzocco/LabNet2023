using LINQ.Practica.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ.Practica.UI
{
    class Menu
    {
        private readonly bool _exit;
        private CustomerLogic _clientes;
        public Menu()
        {
            string opcion;
            _exit = false;
            while (!_exit)
            {
                Console.WriteLine("1 - Devolver objeto Customer");
                Console.WriteLine("2 - Devolver productos sin stock");
                Console.WriteLine("3 - Lanzar excepcion");
                Console.WriteLine("4 - Lanzar excepcion personalizada");
                Console.WriteLine("5 - Salir");
                Console.Write("Ingrese su opcion: ");

                opcion = Console.ReadLine();
                Console.Clear();

                switch (opcion)
                {
                    case "1":
                        MostrarObjetoCustomer();
                        EsperarUsuario();
                        break;
                    case "2":
                        EsperarUsuario();
                        break;
                    case "3":
                        EsperarUsuario();
                        break;
                    case "4":
                        EsperarUsuario();
                        break;
                    case "5":
                        _exit = true;
                        break;
                    default:
                        Console.WriteLine("Ingresa un numero valido.");
                        break;
                }
            }
        }
        private void EsperarUsuario()
        {
            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }
        void MostrarObjetoCustomer()
        {
            _clientes = new CustomerLogic();
            try
            {
                var clienteAMostrar = _clientes.ObtenerCliente();
                Console.WriteLine($"{clienteAMostrar.CompanyName} - Pais: {clienteAMostrar.Country}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
    }
}
