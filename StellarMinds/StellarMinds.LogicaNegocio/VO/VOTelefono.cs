using System;
using System.Collections.Generic;
using System.Text;

namespace StellarMinds.LogicaNegocio.VO.VOUsuario
{
    public record VOTelefono
    {
        public int Value { get; private set; }

        public VOTelefono(int value)
        {
            Value = value;

        }
    }
}
