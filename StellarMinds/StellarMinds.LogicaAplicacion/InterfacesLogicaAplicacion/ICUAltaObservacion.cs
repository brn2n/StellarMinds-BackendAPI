using System;
using System.Collections.Generic;
using System.Text;

namespace StellarMinds.LogicaAplicacion.InterfacesLogicaAplicacion
{
    public interface ICUAltaObservacion<T>
    {
        int Ejecutar(T dto, int socioId);
    }
}
