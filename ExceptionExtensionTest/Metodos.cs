using System;

namespace ExceptionExtension
{
    public class Metodos
    {
        public void DivisionPorCero()
        {
            decimal primerNumero, segundoNumero = 0, resultado;

            try
            {
                primerNumero = ValidarInputDecimal("Ingresar dividendo: ");
                resultado = primerNumero.DividirPor(segundoNumero);
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Excepcion {ex.Message}");
            }
            finally
            {
                Console.WriteLine("La operacion finalizo.");
            }
        }
        public decimal DividirDosNumeros(decimal primerNumero, decimal segundoNumero)
        {
            decimal resultado;
            try
            {
                resultado = primerNumero.DividirPor(segundoNumero);
                return resultado;
            }
            catch (DivideByZeroException ex)
            {
                throw ex;
            }
        }
        public void MostrarExcepcion()
        {
            Logic logic = new Logic();

            try
            {
                logic.LanzarExcepcion();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.GetType().Name} - { ex.Message}");
            }
        }
        public void MostrarExcepcionPersonalizada()
        {
            Logic logic = new Logic();
            try
            {
                logic.LanzarExcepcionPersonalizada();
            }
            catch (NoPantsException ex)
            {
                Console.WriteLine($"{ex.GetType().Name} - {ex.Message}");
            }
        }
        public decimal ValidarInputDecimal(string mensajeSolicitando)
        {
            decimal numero = 0;
            bool inputValido = false;
            while(!inputValido)
            {
                try
                {
                    Console.WriteLine(mensajeSolicitando);
                    numero = decimal.Parse(Console.ReadLine());
                    inputValido = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("¡Seguro Ingreso una letra o no ingreso nada!");
                }
            }
            return numero;
            
        }
    }
}
