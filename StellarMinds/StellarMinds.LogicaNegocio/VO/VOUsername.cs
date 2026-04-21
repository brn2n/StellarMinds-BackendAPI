using System;
using System.Collections.Generic;
using System.Text;

namespace StellarMinds.LogicaNegocio.VO.VOUsuario
{
    public record class VOUsername
    {
        public string Value { get; private set; }

        public VOUsername(string value)
        {
            Value = value;
            //Validar();
        }

        private void Validar()
        {
            throw new NotImplementedException(); // Aquí puedes implementar la lógica de validación 
        }
    }
}
