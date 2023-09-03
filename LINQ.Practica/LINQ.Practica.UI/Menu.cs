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
                        MostrarProductosSinStock();
                        EsperarUsuario();
                        break;
                    case "3":
                        MostrarProductosConStock();
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
        private void MostrarObjetoCustomer()
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
    }
}
