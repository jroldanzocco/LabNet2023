using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.To.EF.CommonComponents
{
    public class ExistentRegException : Exception
    {
        public ExistentRegException() { }

        public override string Message => $"El ID indicado ya se encuentra en uso";

    }
}
