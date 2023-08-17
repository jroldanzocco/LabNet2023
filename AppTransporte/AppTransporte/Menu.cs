using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTransporte
{
    class Menu
    {
        private int _opcion;
        public Menu()
        {
            _opcion = -1;
            string input;
            while(_opcion != 0)
            {
                Console.WriteLine("1 - Ingresar la cantidad de pasajeros");
                Console.WriteLine("2 - ");
                Console.WriteLine("0 - Salir del programa.");
                Console.Write("Ingrese su opcion: " );
                input = Console.ReadLine();
                Console.Clear();

                if (esNumero(input))
                    _opcion = Convert.ToInt32(input);    
                
                switch (_opcion)
                {
                    case 1:
                        Console.WriteLine("HOLA");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Ingresa un numero valido...");
                        break;
                }

            }
        }
        private bool esNumero(string cadena)
        {
            bool valor = true ;
            if(cadena == string.Empty || cadena == null)
                valor = false;
            else 
                foreach(char caracter in cadena.ToCharArray())
                {
                    valor = valor && char.IsDigit(caracter);
                }
            return valor;
        }
        



    }
}
