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
            for (int i = 0; i < 10; i++)
            {
                if (i >= 5)
                    _vehiculos.Add(new Taxi(0, 4, i - 4));
                else
                    _vehiculos.Add(new Omnibus(0, 100, i + 1));
            }
            _opcion = -1;

            while (_opcion != 5)
            {
                Console.WriteLine("1 - Registrar pasajeros");
                Console.WriteLine("2 - Ver cantidad de pasajeros");
                Console.WriteLine("3 - Avanzar");
                Console.WriteLine("4 - Detenerse");
                Console.WriteLine("5 - Salir del programa.");
                Console.Write("Ingrese su opcion: ");
                string input = Console.ReadLine();
                int.TryParse(input, out _opcion);
                Console.Clear();

                switch (_opcion)
                {
                    case 1:
                        RegistrarPasajeros();
                        Console.Clear();
                        break;
                    case 2:
                        VerPasajeros();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 3:
                        Iniciar();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 4:
                        Parar();
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
            int pasajeros;
            string input;

            foreach (TransportePublico vehiculo in _vehiculos)
            {
                pasajeros = 0;

                while (pasajeros == 0)
                {
                    Console.WriteLine($"Indique pasajeros para {vehiculo.GetType().Name} {vehiculo.NumeroVehiculo} (Maximo {vehiculo.LimitePasajeros})");
                    input = Console.ReadLine();
                    int.TryParse(input, out pasajeros);
                    if (pasajeros > 0 && pasajeros <= vehiculo.LimitePasajeros)
                    {
                        vehiculo.Pasajeros = pasajeros;
                    }
                    else
                    {
                        Console.WriteLine("Los pasajeros no pueden ser 0 ni mayor al maximo...");
                        pasajeros = 0;
                    }
                }
            }
        }

        private void VerPasajeros()
        {
            foreach (TransportePublico vehiculos in _vehiculos)
            {
                Console.WriteLine($"{vehiculos.GetType().Name} {vehiculos.NumeroVehiculo}: {vehiculos.Pasajeros} pasajeros.");
            }
        }
        private void Iniciar()
        {
            string input;
            int numOpcion = 1;
            Console.WriteLine("Indique el vehiculo");
            foreach (TransportePublico vehiculo in _vehiculos)
            {
                Console.WriteLine($"{numOpcion} - {vehiculo.GetType().Name} {vehiculo.NumeroVehiculo}.");
                numOpcion++;
            }
            input = Console.ReadLine();
            int.TryParse(input, out numOpcion);
            for(int i=0; i<_vehiculos.Count; i++)
            {
                if (i + 1 == numOpcion)
                    Console.WriteLine(_vehiculos[i].Avanzar());
            }
        }

        private void Parar()
        {
            string input;
            int numOpcion = 1;
            Console.WriteLine("Indique el vehiculo");
            foreach (TransportePublico vehiculo in _vehiculos)
            {
                Console.WriteLine($"{numOpcion} - {vehiculo.GetType().Name} {vehiculo.NumeroVehiculo}.");
                numOpcion++;
            }
            input = Console.ReadLine();
            int.TryParse(input, out numOpcion);
            for (int i = 0; i < _vehiculos.Count; i++)
            {
                if (i + 1 == numOpcion)
                    Console.WriteLine(_vehiculos[i].Detenerse());
            }
        }
    }
}
