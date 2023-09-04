using LINQ.Practica.Entities;
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
        private ProductsLogic _productos;
        public Menu()
        {
            string opcion;
            _exit = false;
            while (!_exit)
            {
                Console.WriteLine("1 - Devolver objeto Customer");
                Console.WriteLine("2 - Devolver productos sin stock");
                Console.WriteLine("3 - Devolver productos con stock y precio minimo de 3");
                Console.WriteLine("4 - Devolver clientes de region WA");
                Console.WriteLine("5 - Devolver producto con ID 789");
                Console.WriteLine("6 - Mostrar nombres de clientes");
                Console.WriteLine("7 - Devolver Join entre Customer y Order");
                Console.WriteLine("8 - Devolver primeros 3 clientes de region WA");
                Console.WriteLine("9 - Devolver productos ordenados por nombre");
                Console.WriteLine("10 - Devolver productos ordenados por stock descendente");
                Console.WriteLine("11 - Devolver productos por categoria");
                Console.WriteLine("12 - Salir");
                Console.WriteLine("13 - Salir");
                Console.WriteLine("0 - Salir");
                Console.Write("Ingrese su opcion: ");

                opcion = Console.ReadLine();
                Console.Clear();

                switch (opcion)
                {
                    case "0":
                        _exit = true;
                        break;
                    case "1":
                        MostrarObjetoCustomer();
                        EsperarUsuario();
                        break;
                    case "2":
                        MostrarProductosSinStock();
                        EsperarUsuario();
                        break;
                    case "3":
                        MostrarProductosConStock();
                        EsperarUsuario();
                        break;
                    case "4":
                        MostrarClientesEnWA();
                        EsperarUsuario();
                        break;
                    case "5":
                        MostrarProductoID();
                        EsperarUsuario();
                        break;
                    case "6":
                        MostrarNombreClientes();
                        EsperarUsuario();
                        break;
                    case "7":
                        DevolverJoinCustomerOrder();
                        EsperarUsuario();
                        break;
                    case "8":
                        DevolverTresClientesWA();
                        EsperarUsuario();
                        break;
                    case "9":
                        DevolverProductorPorNombre();
                        EsperarUsuario();
                        break;
                    case "10":
                        DevolverProdPorStockDesc();
                        EsperarUsuario();
                        break;
                    case "11":
                        DevolverProdPorCategoria();
                        EsperarUsuario();
                        break;
                    case "12":

                        EsperarUsuario();
                        break;
                    case "13":

                        EsperarUsuario();
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
        private void MostrarObjetoCustomer()
        {
            _clientes = new CustomerLogic();
            try
            {
                var clienteAMostrar = _clientes.GetCliente();
                Console.WriteLine($"{clienteAMostrar.CompanyName} - Pais: {clienteAMostrar.Country}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
        private void MostrarProductosSinStock()
        {
            _productos = new ProductsLogic();
            Console.WriteLine("PRODUCTOS FUERA DE STOCK\n");
            foreach(Products producto in _productos.GetOutStock())
            {
                Console.WriteLine($"Nombre: {producto.ProductName} - Stock: {producto.UnitsInStock} - Precio: {producto.UnitPrice.GetValueOrDefault():0.00}");
            }
        }
        private void MostrarProductosConStock()
        {
            _productos = new ProductsLogic();
            Console.WriteLine("PRODUCTOS CON STOCK Y PRECIO UNITARIO MAYOR A 3\n");
            foreach(Products producto in _productos.GetPlusThree())
            {
                Console.WriteLine($"Nombre: {producto.ProductName} - Stock: {producto.UnitsInStock} - Precio: {producto.UnitPrice.GetValueOrDefault():0.00}");
            }
        }
        private void MostrarClientesEnWA()
        {
            _clientes = new CustomerLogic();
            foreach(Customers cliente in _clientes.GetCustomersFromWA())
            {
                Console.WriteLine($"{cliente.CompanyName} - Pais {cliente.Country} - Region: {cliente.Region}");
            }
        }
        private void MostrarProductoID()
        {
            _productos = new ProductsLogic();
            try
            {
                var producto = _productos.GetBySpecificId(789);
                Console.WriteLine($"Nombre: {producto.ProductName} - Stock: {producto.UnitsInStock} - Precio: {producto.UnitPrice.GetValueOrDefault():0.00}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private void MostrarNombreClientes()
        {
            _clientes = new CustomerLogic();
            foreach(string nombreCliente in _clientes.GetCustomerNames())
            {
               
                if (nombreCliente != null)
                    Console.WriteLine($"{nombreCliente.ToLower()}\n{nombreCliente.ToUpper()}\n");
            }
        }
        private void DevolverJoinCustomerOrder()
        {
            _clientes = new CustomerLogic();
            foreach(CustomerOrder cliente in _clientes.GetCustomerOrderWA())
            {
                Console.WriteLine($"{cliente.CustomerID} - {cliente.CompanyName} - {cliente.Region} - {cliente.OrderDate?.ToShortDateString()}");
            }

        }
        private void DevolverTresClientesWA()
        {
            _clientes = new CustomerLogic();
            foreach (Customers cliente in _clientes.GetThreeCustomersFromWA())
            {
                Console.WriteLine($"{cliente.CustomerID} - {cliente.CompanyName} - {cliente.Region}");
            }
        }
        private void DevolverProductorPorNombre()
        {
            _productos = new ProductsLogic();

            foreach (Products producto in _productos.GetProductByName())
            {
                Console.WriteLine($"Nombre: {producto.ProductName} - Stock: {producto.UnitsInStock}");
            }
        }
        private void DevolverProdPorStockDesc()
        {
            _productos = new ProductsLogic();
            foreach (Products producto in _productos.GetProductByStock())
            {
                Console.WriteLine($"Nombre: {producto.ProductName} - Stock: {producto.UnitsInStock}");
            }
        }
        private void DevolverProdPorCategoria()
        {
            _productos = new ProductsLogic();
            foreach (ProductPerCategorie producto in _productos.GetProductoPorCategoria())
            {
                Console.WriteLine($"Categoria: {producto.Categoria} - ID: {producto.Id} - Producto: {producto.Producto} - ");
            }  
        }
    }
}
