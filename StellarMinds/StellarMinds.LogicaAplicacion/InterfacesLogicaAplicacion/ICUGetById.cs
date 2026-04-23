using System;
using System.Collections.Generic;
using System.Text;

namespace StellarMinds.LogicaAplicacion.InterfacesLogicaAplicacion
{
    public interface ICUGetById<T>
    {
        T Execute(int id);
    }
}
