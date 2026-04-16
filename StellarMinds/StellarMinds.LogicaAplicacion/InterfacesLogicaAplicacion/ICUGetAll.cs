using System;
using System.Collections.Generic;
using System.Text;

namespace StellarMinds.LogicaAplicacion.InterfacesLogicaAplicacion
{
    public interface ICUGetAll<T>
    {
        public IEnumerable<T> Ejecutar();
    }
}
