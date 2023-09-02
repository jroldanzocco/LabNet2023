using System;

namespace Northwind.To.EF.UI
{
    public class Menu
    {
        private MenuClientes menuClientes;
        private MenuEmpleados menuEmpleados;
        public Menu(){}
        public void Mostrar()
        {
            int opcion = -1;
            while (opcion != 3)
            {
                Console.WriteLine("1 - Clientes CRUD");
                Console.WriteLine("2 - Empleados CRUD");
                Console.WriteLine("3 - Salir");
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
                        menuEmpleados = new MenuEmpleados();
                        menuEmpleados.MostrarMenu();
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
