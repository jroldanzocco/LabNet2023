using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTransporte
{
    public abstract class TransportePublico
    {
        public TransportePublico(int cantPasajeros, int limitePasajeros)
        {
            this.Pasajeros = cantPasajeros;
            this.LimitePasajeros = limitePasajeros;
        }
        public int Pasajeros { get; set; }
        public int LimitePasajeros { get; set; }
        public abstract string Avanzar();
        public abstract string Detenerse();

    }
}
