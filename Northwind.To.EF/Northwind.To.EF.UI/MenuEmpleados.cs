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
                Console.WriteLine("1 - Listar empleados");
                Console.WriteLine("2 - Agregar empleado");
                Console.WriteLine("3 - Buscar empleado por ID");
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

        private void Eliminar()
        {
            Console.WriteLine("Ingresa el ID del cliente a borrar");
            Employees empleadoABorrar;
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                empleadoABorrar = _empleados.GetById(id);
                if (empleadoABorrar != null)
                {
                    ConfirmacionBorrado(id, empleadoABorrar);
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
        private void ConfirmacionBorrado(int id, Employees empleado)
        {
            int opcion = -1;
            while (opcion != 2)
            {
                Console.WriteLine("¿Seguro que desea eliminar el siguiente registro?");
                Console.WriteLine($"ID: {empleado.EmployeeID} - {empleado.LastName}, {empleado.FirstName}");
                Console.WriteLine("\n1 - SI");
                Console.WriteLine("2 - NO");
                Console.Write("Ingrese la opcion: ");
                int.TryParse(Console.ReadLine(), out opcion);

                switch (opcion)
                {
                    case 1:
                        try
                        {
                            _empleados.Delete(id);
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

        private void Actualizar()
        {
            Console.WriteLine("Ingresa el ID del cliente a modificar");

            if (int.TryParse(Console.ReadLine(), out int id))
            {
                Employees empleadoAModificar = _empleados.GetById(id);
                if (empleadoAModificar != null)
                {
                    ConfirmacionUpdate(empleadoAModificar);
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

        private void Buscar()
        {
            Console.WriteLine("Ingrese el ID del empleado (Maximo 5 caracteres): ");
            Employees empleadoBuscado;
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                empleadoBuscado = _empleados.GetById(id);
                if (empleadoBuscado != null)
                    Console.WriteLine($"ID: {empleadoBuscado.EmployeeID} - {empleadoBuscado.LastName}, {empleadoBuscado.FirstName}");
                else
                    Console.WriteLine("No se encontro el cliente.");
            }
            else
            {
                Console.WriteLine("Ingreso invalido");
            }
        }

        private void Listar()
        {
            foreach (Employees empleados in _empleados.GetAll())
            {
                Console.WriteLine($"ID: {empleados.EmployeeID} Datos: {empleados.LastName}, {empleados.FirstName}");
            }
        }

        private void Agregar()
        {
            Console.Write("Ingresa nombre del empleado: ");
            string nombre = Console.ReadLine();
            Console.Write("Ingresa apellido del empleado: ");
            string apellido = Console.ReadLine();
            
            try
            {
                _empleados.Add(new Employees
                {
                    FirstName = nombre,
                    LastName = apellido
                }) ;
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
        private void ConfirmacionUpdate(Employees empleado)
        {
            int opcion = -1;
            while (opcion != 2)
            {
                Console.WriteLine("¿Seguro que desea modificar el siguiente registro?");
                Console.WriteLine($"ID: {empleado.EmployeeID} - {empleado.LastName}, {empleado.FirstName}");
                Console.WriteLine("\n1 - SI");
                Console.WriteLine("2 - NO");
                Console.Write("Ingrese la opcion: ");
                int.TryParse(Console.ReadLine(), out opcion);

                switch (opcion)
                {
                    case 1:
                        try
                        {
                            Console.WriteLine("Nombre empleado: ");
                            empleado.FirstName = Console.ReadLine();
                            Console.WriteLine("Apellido empleado: ");
                            empleado.LastName = Console.ReadLine();
                            _empleados.Update(empleado);
                            Console.WriteLine("El registro se modifico exitosamente.");
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Ingreso invalido - Nombre max 10 caracteres. Apellido max 20 caracteres");
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
