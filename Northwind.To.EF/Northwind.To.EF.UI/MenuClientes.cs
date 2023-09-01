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
    class MenuClientes : Menu
    {
        private readonly CustomersLogic _clientes;
        public MenuClientes()
        {
            
            _clientes = new CustomersLogic();
            
        }

        public void MostrarMenu()
        {
            int opcion = -1;
            while (opcion != 5)
            {
                Console.WriteLine("1 - Listar clientes");
                Console.WriteLine("2 - Agregar cliente");
                Console.WriteLine("3 - Buscar cliente por ID");
                Console.WriteLine("4 - Borrar cliente");
                Console.WriteLine("5 - Volver al menu anterior");
                Console.Write("Ingrese su opcion: ");

                int.TryParse(Console.ReadLine(), out opcion);
                Console.Clear();

                switch (opcion)
                {
                    case 1:
                        EsperarUsuario();
                        break;
                    case 2:
                        EsperarUsuario();
                        break;
                    case 3:
                        EsperarUsuario();
                        break;
                    case 4:
                        EsperarUsuario();
                        break;
                    case 5:
                        break;
                    default:
                        Console.WriteLine("Ingresa un numero valido.");
                        break;
                }
            }
        }
        private void MostrarClientes()
        {
            foreach (Customers cliente in _clientes.GetAll())
            {
                Console.WriteLine($"ID: {cliente.CustomerID} - Compania: {cliente.CompanyName} - Localizacion: {cliente.Country}");
            }
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
                });
                Console.WriteLine("Cliente cargado exitosamente!");
            }
            catch (ExistentRegException ex)
            {
                Console.WriteLine($"{ex.GetType().Name} - {ex.Message}");
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
            if (id.Length <= 5 && id.Length > 0)
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
        private void BorrarCliente()
        {
            Console.WriteLine("Ingresa el ID del cliente a borrar");
            string id = Console.ReadLine();
            Customers clienteABorrar;
            if (id.Length <= 5 && id.Length > 0)
            {
                clienteABorrar = _clientes.GetById(id);
                if (clienteABorrar != null)
                {
                    int opcion = -1;
                    while (opcion != 2)
                    {
                        Console.WriteLine("¿Seguro que desea eliminar el siguiente registro?");
                        Console.WriteLine($"ID: {clienteABorrar.CustomerID} - Compania: {clienteABorrar.CompanyName} - Localizacion: {clienteABorrar.Country}");
                        Console.WriteLine("\n1 - SI");
                        Console.WriteLine("2 - NO");
                        Console.Write("Ingrese la opcion: ");
                        int.TryParse(Console.ReadLine(), out opcion);

                        switch (opcion)
                        {
                            case 1:
                                _clientes.Delete(id);
                                Console.WriteLine("El registro se elimino exitosamente.");
                                opcion = 2;
                                break;
                            case 2:
                                break;
                            default:
                                Console.WriteLine("Ingreso invalido");
                                break;
                        }
                    }

                }
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

