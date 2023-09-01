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
        private readonly int _opcion;
        private readonly CustomersLogic _clientes;
        public Menu()
        {
            _clientes = new CustomersLogic();
            _opcion = -1;
            while (_opcion != 5)
            {
                Console.WriteLine("1 - Listar Clientes");
                Console.WriteLine("2 - Agregar Cliente");
                Console.WriteLine("3 - Buscar Cliente por ID");
                Console.WriteLine("4 - ");
                Console.WriteLine("5 - Salir");
                Console.Write("Ingrese su opcion: ");

                int.TryParse(Console.ReadLine(), out _opcion);
                Console.Clear();

                switch (_opcion)
                {
                    case 1:
                        foreach(Customers cliente in _clientes.GetAll())
                        {
                            Console.WriteLine($"ID: {cliente.CustomerID} - Compania: {cliente.CompanyName} - Localizacion: {cliente.Country}");
                        }
                        EsperarUsuario();
                        break;
                    case 2:
                        AgregarCliente();
                        EsperarUsuario();
                        break;
                    case 3:
                        buscarCliente();
                        EsperarUsuario();
                        break;
                    case 4:
                        break;
                    case 5:
                        Console.WriteLine("Gracias por usar el programa");
                        break;
                    default:
                        Console.WriteLine("Ingresa un numero valido.");
                        break;
                }
            }
        }
        private void EsperarUsuario()
        {
            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }
        private void AgregarCliente()
        {
            Console.Write("Ingresa ID (maximo 5 caracteres): ");
            string id = Console.ReadLine();
            Console.Write("Ingresa nombre de la Compania: ");
            string compania = Console.ReadLine();
            Console.Write("Ingresa Pais: ");
            string pais = Console.ReadLine();

            try
            {
                _clientes.Add(new Customers
                {
                    CustomerID = id,
                    CompanyName = compania,
                    Country = pais
                }) ;
                Console.WriteLine("Cliente cargado exitosamente!");
            }
            catch (ExistentRegException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (DbEntityValidationException)
            {
                Console.WriteLine("Formato invalido. No se cargo el cliente");
            }
        }
        private void buscarCliente()
        {
            Console.WriteLine("Ingrese el ID del cliente (Maximo 5 caracteres)");
            string id = Console.ReadLine();
            Customers clienteBuscado;
            if(id.Length <= 5 && id.Length > 0)
            {
                  clienteBuscado = _clientes.GetById(id);
                    if (clienteBuscado != null)
                        Console.WriteLine($"ID: {clienteBuscado.CustomerID} - Compania: {clienteBuscado.CompanyName} - Localizacion: {clienteBuscado.Country}");
                    else
                        Console.WriteLine("No se encontro el cliente.");
            }
            else
            {
                Console.WriteLine("Ingreso invalido");
            }
        }
    }
}
