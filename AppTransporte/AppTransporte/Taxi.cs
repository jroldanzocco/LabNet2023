using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTransporte
{
    class Taxi : TransportePublico
    {
        public Taxi(int cantPasajeros, int limitePasajeros, int numeroVehiculo) : base(cantPasajeros, limitePasajeros, numeroVehiculo)
        {
            
        }
        public override string Avanzar()
        {
            if (this.EnMarcha)
            {
                EnMarcha = true;
                return $"{this.GetType().Name} {this.NumeroVehiculo} enciende el reloj y comienza el recorrido. ";
            }
            else
                return $"{this.GetType().Name} {this.NumeroVehiculo} ya se encuentra en camino, llegara pronto.";
        }

        public override string Detenerse()
        {
            if (this.EnMarcha)
            {
                EnMarcha = false;
                return $"{this.GetType().Name} {this.NumeroVehiculo} se ha detenido o finalizo su recorrido.";
            }
            else
                return $"{this.GetType().Name} {this.NumeroVehiculo} no se encuentra en movimiento.";
        }
    }
}
