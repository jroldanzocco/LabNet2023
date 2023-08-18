using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTransporte
{
    public abstract class TransportePublico
    {
        public TransportePublico(int cantPasajeros, int limitePasajeros, int numeroVehiculo)
        {
            this.Pasajeros = cantPasajeros;
            this.LimitePasajeros = limitePasajeros;
            this.NumeroVehiculo = numeroVehiculo;
            EnMarcha = false;
        }
        public int Pasajeros { get; set; }
        public int LimitePasajeros { get; set; }
        public int NumeroVehiculo { get; set; }
        public bool EnMarcha { get; set; }
        public abstract string Avanzar();
        public abstract string Detenerse();

    }
}
