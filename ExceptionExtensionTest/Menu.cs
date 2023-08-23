using System;

namespace ExceptionExtension
{
    class Menu
    {
        private int _opcion;
        Metodos _metodos;
        public Menu()
        {
            _opcion = -1;
            _metodos = new Metodos();
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
                        _metodos.DivisionPorCero();
                        EsperarUsuario();
                        break;
                    case 2:
                        try
                        {
                            decimal resultado = _metodos.DividirDosNumeros(_metodos.ValidarInputDecimal("Ingresa dividendo"), _metodos.ValidarInputDecimal("Ingresa divisor"));
                            Console.WriteLine($"Resultado: {resultado}");
                        }
                        catch (DivideByZeroException ex)
                        {
                            Console.WriteLine($"¡Solo Chuck Norris divide por cero! - {ex.Message}");
                        }
                        
                        EsperarUsuario();
                        break;
                    case 3:
                        _metodos.MostrarExcepcion();
                        EsperarUsuario();
                        break;
                    case 4:
                        _metodos.MostrarExcepcionPersonalizada();
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
