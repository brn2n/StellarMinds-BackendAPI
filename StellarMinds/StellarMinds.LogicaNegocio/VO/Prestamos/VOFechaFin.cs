using System;
using System.Collections.Generic;
using System.Text;

namespace StellarMinds.LogicaNegocio.VO.Prestamos
{
    public record class VOFechaFin
    {
        public DateTime Value { get; set; }

        public VOFechaFin(DateTime value)
        {
            Value = value;
            Validar();
        }

        private void Validar()
        {
            throw new NotImplementedException(); //Validar que no sea menor que la fecha inicio
        }
    }
}
