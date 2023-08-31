using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.To.EF.UI
{
    class Menu
    {
        private int _opcion;

        public Menu()
        {
            _opcion = -1;
            while (_opcion != 5)
            {
                Console.WriteLine("1 - ");
                Console.WriteLine("2 - ");
                Console.WriteLine("3 - ");
                Console.WriteLine("4 - ");
                Console.WriteLine("5 - ");
                Console.Write("Ingrese su opcion: ");

                int.TryParse(Console.ReadLine(), out _opcion);
                Console.Clear();

                switch (_opcion)
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
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
    }
}
