using System;

namespace ExceptionExtension
{
    class Menu
    {
        private int _opcion;
        public Menu()
        {
            _opcion = -1;

            while(_opcion != 5)
            {
                Console.WriteLine("1 - Dividir por cero");
                Console.WriteLine("2 - Dividir dos numeros");
                Console.WriteLine("3 - Lanzar excepcion");
                Console.WriteLine("4 - Lanzar excepcion personalizada");
                Console.WriteLine("5 - Salir");
                Console.Write("Ingrese su opcion: ");

                int.TryParse(Console.ReadLine(), out _opcion);
                Console.Clear();

                switch (_opcion)
                {
                    case 1:
                        Metodos.DivisionPorCero();
                        EsperarUsuario();
                        break;
                    case 2:
                        Metodos.DividirDosNumeros();
                        EsperarUsuario();
                        break;
                    case 3:
                        Metodos.MostrarExcepcion();
                        EsperarUsuario();
                        break;
                    case 4:
                        Metodos.MostrarExcepcionPersonalizada();
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
    }
}
