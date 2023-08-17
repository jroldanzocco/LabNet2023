using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTransporte
{
    public abstract class TransportePublico
    {
        public int Pasajeros { get; }
        public abstract void Avanzar();
        public abstract void Detenerse();

    }
}
