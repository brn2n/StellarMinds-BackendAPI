using System;
using System.Collections.Generic;
using System.Text;

namespace StellarMinds.LogicaAplicacion.InterfacesLogicaAplicacion
{
    public interface ICUAlta<T>
    {
        void Ejecutar(T obj);
    }
}
