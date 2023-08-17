using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTransporte
{
    class Taxi : TransportePublico
    {
        public Taxi(int cantPasajeros, int limitePasajeros) : base(cantPasajeros, limitePasajeros)
        {
            
        }
        public override string Avanzar()
        {
            throw new NotImplementedException();
        }

        public override string Detenerse()
        {
            throw new NotImplementedException();
        }
    }
}
