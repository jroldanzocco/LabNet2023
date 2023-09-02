﻿using Northwind.To.EF.CommonComponents;
using Northwind.To.EF.Entities;
using Northwind.To.EF.Logic;
using System;
using System.Data.Entity.Validation;


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
            while (opcion != 6)
            {
                Console.WriteLine("1 - Listar clientes");
                Console.WriteLine("2 - Agregar cliente");
                Console.WriteLine("3 - Buscar cliente por ID");
                Console.WriteLine("4 - Actualizar cliente");
                Console.WriteLine("5 - Eliminar cliente");
                Console.WriteLine("6 - Volver al menu anterior");
                Console.Write("Ingrese su opcion: ");

                int.TryParse(Console.ReadLine(), out opcion);
                Console.Clear();

                switch (opcion)
                {
                    case 1:
                        Listar();
                        EsperarUsuario();
                        break;
                    case 2:
                        Agregar();
                        EsperarUsuario();
                        break;
                    case 3:
                        Buscar();
                        EsperarUsuario();
                        break;
                    case 4:
                        Actualizar();
                        EsperarUsuario();
                        break;
                    case 5:
                        Eliminar();
                        EsperarUsuario();
                        break;
                    case 6:
                        break;
                    default:
                        Console.WriteLine("Ingresa un numero valido.");
                        break;
                }
            }
        }
        private void Listar()
        {
            foreach (Customers cliente in _clientes.GetAll())
            {
                Console.WriteLine($"ID: {cliente.CustomerID} - Compania: {cliente.CompanyName} - Localizacion: {cliente.Country}");
            }
        }
        private void Agregar()
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
        private void Buscar()
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
        private void Eliminar()
        {
            Console.WriteLine("Ingresa el ID del cliente a borrar");
            string id = Console.ReadLine();
            Customers clienteABorrar;
            if (id.Length <= 5 && id.Length > 0)
            {
                clienteABorrar = _clientes.GetById(id);
                if (clienteABorrar != null)
                {
                    ConfirmacionBorrado(id, clienteABorrar);
                }
                else
                {
                    Console.WriteLine("No se encontro el cliente.");
                }
            }
            else
            {
                Console.WriteLine("Ingreso invalido");
            }
        }
        private void ConfirmacionBorrado(string id, Customers cliente)
        {
            int opcion = -1;
            while (opcion != 2)
            {
                Console.WriteLine("¿Seguro que desea eliminar el siguiente registro?");
                Console.WriteLine($"ID: {cliente.CustomerID} - Compania: {cliente.CompanyName} - Localizacion: {cliente.Country}");
                Console.WriteLine("\n1 - SI");
                Console.WriteLine("2 - NO");
                Console.Write("Ingrese la opcion: ");
                int.TryParse(Console.ReadLine(), out opcion);

                switch (opcion)
                {
                    case 1:
                        try
                        {
                            _clientes.Delete(id);
                            Console.WriteLine("El registro se elimino exitosamente.");
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("No se pudo eliminar el registro por conflictos de referencias");
                        }
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
        private void Actualizar() {
            Console.WriteLine("Ingresa el ID del cliente a modificar");
            string id = Console.ReadLine();
            
            if (id.Length <= 5 && id.Length > 0)
            {
                Customers clienteAModificar = _clientes.GetById(id);
                if (clienteAModificar != null)
                {
                    ConfirmacionUpdate(clienteAModificar);
                }
                else
                {
                    Console.WriteLine("No se encontro el cliente.");
                }
            }
            else
            {
                Console.WriteLine("Ingreso invalido");
            }
        }
        private void ConfirmacionUpdate(Customers cliente)
        {
            int opcion = -1;
            while (opcion != 2)
            {
                Console.WriteLine("¿Seguro que desea modificar el siguiente registro?");
                Console.WriteLine($"ID: {cliente.CustomerID} - Compania: {cliente.CompanyName} - Localizacion: {cliente.Country}");
                Console.WriteLine("\n1 - SI");
                Console.WriteLine("2 - NO");
                Console.Write("Ingrese la opcion: ");
                int.TryParse(Console.ReadLine(), out opcion);

                switch (opcion)
                {
                    case 1:
                        try
                        {
                            Console.WriteLine("Nombre Compania: ");
                            cliente.CompanyName = Console.ReadLine();
                            Console.WriteLine("Pais: ");
                            cliente.Country = Console.ReadLine();
                            _clientes.Update(cliente);
                            Console.WriteLine("El registro se modifico exitosamente.");
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Ingreso invalido - Compania max 50 caracteres. Pais max 15 caracteres");
                        }
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
    }
}

