using System;


namespace ExceptionExtension
{
    class NoPantsException : Exception
    {
        private string _mensaje;
        public NoPantsException(string mensajePersonalizado){
            _mensaje = mensajePersonalizado;
        }

        public override string Message => $"{_mensaje} - {base.Message}";

    }
}
