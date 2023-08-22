using System;

namespace ExceptionExtension
{
    public static class Metodos
    {
        public static void DivisionPorCero()
        {
            decimal primerNumero, segundoNumero = 0, resultado;

            try
            {
                Console.WriteLine("Division por cero (0)");
                primerNumero = ValidarInputDecimal("Ingrese el dividendo: ");
                resultado = primerNumero.DividirPor(segundoNumero);
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Excepcion: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("La operacion finalizo");
            }


        }
        public static void DividirDosNumeros()
        {
            decimal primerNumero, segundoNumero, resultado;

            try
            {
                Console.WriteLine("Division de dos numeros");
                primerNumero = ValidarInputDecimal("Ingrese el dividendo: ");
                segundoNumero = ValidarInputDecimal("Ingrese el divisor: ");
                resultado = primerNumero.DividirPor(segundoNumero);
                Console.WriteLine($"El resultado es: {resultado}");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"{ex.Message}... ¡Solo Chuck Norris divide por cero!");
            }
            finally
            {
                Console.WriteLine("La operacion finalizo");
            }
        }
        public static void MostrarExcepcion()
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
        public static void MostrarExcepcionPersonalizada()
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
        private static decimal ValidarInputDecimal(string mensajeSolicitando)
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
