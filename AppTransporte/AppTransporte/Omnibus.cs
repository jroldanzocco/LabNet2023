using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTransporte
{
    class Omnibus : TransportePublico
    {
        public Omnibus(int cantPasajeros, int limitePasajeros, int numeroVehiculo) : base(cantPasajeros, limitePasajeros, numeroVehiculo)
        {
            
        }
        public override string Avanzar()
        {
            if (!this.EnMarcha)
            {
                EnMarcha = true;
                return $"{this.GetType().Name} {this.NumeroVehiculo} cierra sus puertas y comienza la marcha ";
            }
            else
                return $"{this.GetType().Name} {this.NumeroVehiculo} ya se encuentra en marcha.";
        }

        public override string Detenerse()
        {
            if (this.EnMarcha)
            {
                EnMarcha = false;
                return $"{this.GetType().Name} {this.NumeroVehiculo} llego a la parada o finalizo su recorrido.";
            } 
            else
                return $"{this.GetType().Name} {this.NumeroVehiculo} no se encuentra en movimiento.";
        }
    }
}
