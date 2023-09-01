using Northwind.To.EF.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.To.EF.UI
{
    public class MenuEmpleados : Menu
    {
        private readonly EmployeesLogic _empleados;
        public MenuEmpleados()
        {
            _empleados = new EmployeesLogic();
        }

        public void MostrarMenu()
        {
            int opcion = -1;
            while (opcion != 6)
            {
                Console.WriteLine("1 - Listar clientes");
                Console.WriteLine("2 - Agregar cliente");
                Console.WriteLine("3 - Buscar cliente por ID");
                Console.WriteLine("4 - Actualizar empleado");
                Console.WriteLine("5 - Eliminar empleado");
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

        private void Actualizar()
        {
            throw new NotImplementedException();
        }

        private void Agregar()
        {
            throw new NotImplementedException();
        }

        private void Buscar()
        {
            throw new NotImplementedException();
        }

        private void Eliminar()
        {
            throw new NotImplementedException();
        }

        private void Listar()
        {
            throw new NotImplementedException();
        }

        
    }
}
