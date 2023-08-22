using System;

namespace ExceptionExtension
{
    class Logic
    {
        public void LanzarExcepcion()
        {
            throw new AccessViolationException();
        }
        public void LanzarExcepcionPersonalizada()
        {
            throw new NoPantsException("Debes estar vestido para la clase");
        }
    }
}
