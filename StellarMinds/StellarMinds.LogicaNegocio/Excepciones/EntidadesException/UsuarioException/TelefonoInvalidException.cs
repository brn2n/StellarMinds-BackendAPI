using StellarMinds.LogicaNegocio.Excepciones.VOExceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace StellarMinds.LogicaNegocio.Excepciones.EntidadesException.UsuarioException
{
    internal class TelefonoInvalidException : LogicaNegocioExcepcion
    {
        public TelefonoInvalidException()
        {
        }

        public TelefonoInvalidException(string? message) : base(message)
        {
        }
    }
}
