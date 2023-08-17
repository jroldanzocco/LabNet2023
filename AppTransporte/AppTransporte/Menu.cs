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
        private List<TransportePublico> _vehiculos;
        public Menu()
        {
            _vehiculos = new List<TransportePublico>();
            for(int i=0; i<10; i++)
            {
                if (i >= 5)
                    _vehiculos.Add(new Taxi(0,4));
                else
                    _vehiculos.Add(new Omnibus(0,100));
            }
            _opcion = -1;
            string input;
            while(_opcion != 0)
            {
                Console.WriteLine("1 - Registrar pasajeros");
                Console.WriteLine("2 - Ver cantidad de pasajeros");
                Console.WriteLine("0 - Salir del programa.");
                Console.Write("Ingrese su opcion: " );
                input = Console.ReadLine();
                Console.Clear();

                if (esNumero(input))
                    _opcion = Convert.ToInt32(input);    
                
                switch (_opcion)
                {
                    case 1:
                        registrarPasajeros();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 2:
                        verPasajeros();
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

        private void registrarPasajeros()
        {
            int contador = 1, pasajeros = 0;
            string input;
            
            foreach(var vehiculos in _vehiculos)
            {
                if (contador > 5)
                    contador = 1;
                Console.WriteLine($"Indique pasajeros para {vehiculos.GetType().Name} {contador} (Maximo {vehiculos.LimitePasajeros})");
                input = Console.ReadLine();
                if (esNumero(input))
                {
                    pasajeros = Convert.ToInt32(input);
                    if (pasajeros > 0 && pasajeros <= vehiculos.LimitePasajeros)
                        vehiculos.Pasajeros = pasajeros;
                }
                else
                {
                    pasajeros = 0;
                }
                contador++;
            }

        }
        void verPasajeros()
        {
            int contador = 1;
            foreach (var vehiculos in _vehiculos)
            {
                if (contador > 5)
                    contador = 1;
                Console.WriteLine($"{vehiculos.GetType().Name} {contador}: {vehiculos.Pasajeros} pasajeros.");

                contador++;
            }
        }

    }
}
