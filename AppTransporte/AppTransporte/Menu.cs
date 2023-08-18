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
            bool inputCorrecto;
            _vehiculos = new List<TransportePublico>();
            for(int i=0; i<10; i++)
            {
                if (i >= 5)
                    _vehiculos.Add(new Taxi(0,4));
                else
                    _vehiculos.Add(new Omnibus(0,100));
            }
            _opcion = -1;
            
            while(_opcion != 3)
            {
                Console.WriteLine("1 - Registrar pasajeros");
                Console.WriteLine("2 - Ver cantidad de pasajeros");
                Console.WriteLine("3 - Salir del programa.");
                Console.Write("Ingrese su opcion: " );
                string input = Console.ReadLine();
                Console.Clear();

                inputCorrecto = int.TryParse(input, out _opcion);
               
                switch (_opcion)
                {
                    case 1:
                        RegistrarPasajeros();
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
        private void RegistrarPasajeros()
        {
            int contador = 1, pasajeros;
            string input;
            bool inputCorrecto;

            foreach (TransportePublico vehiculo in _vehiculos)
            {
                pasajeros = 0;

                if (contador > 5)
                    contador = 1;

                while (pasajeros == 0)
                {
                    Console.WriteLine($"Indique pasajeros para {vehiculo.GetType().Name} {contador} (Maximo {vehiculo.LimitePasajeros})");
                    input = Console.ReadLine();
                    inputCorrecto = int.TryParse(input, out pasajeros);
                    if (pasajeros > 0 && pasajeros <= vehiculo.LimitePasajeros && inputCorrecto)
                    {
                        vehiculo.Pasajeros = pasajeros;
                        contador++;
                    }
                    else
                    {
                        Console.WriteLine("Los pasajeros no pueden ser 0 ni mayor al maximo...");
                        pasajeros = 0;
                    }
                }
            }
        }
      
        private void verPasajeros()
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
