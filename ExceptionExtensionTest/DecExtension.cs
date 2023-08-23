using System;

namespace ExceptionExtension
{
    public static class DecExtension
    {
        public static decimal DividirPor(this decimal numeroUno, decimal numeroDos)
        {
            decimal resultado;
            try
            {
                resultado = numeroUno / numeroDos;
                return resultado;
            }
            catch (DivideByZeroException ex)
            {
                throw ex;
            }
        }
    }
}
