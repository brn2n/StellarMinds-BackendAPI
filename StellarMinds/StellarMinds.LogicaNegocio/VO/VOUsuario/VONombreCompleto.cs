using System;
using System.Collections.Generic;
using System.Text;

namespace StellarMinds.LogicaNegocio.VO
{
    public record VONombreCompleto
    {
        public string nombre { get; set; }
        public string apellido { get; set; }

        public VONombreCompleto(string nombre, string apellido)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            Validar();
        }

        private void Validar()
        {
            throw new NotImplementedException(); //AGREGAR VALIDACION
        }
    }
}
