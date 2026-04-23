using System;
using System.Collections.Generic;
using System.Text;

namespace StellarMinds.LogicaAplicacion.InterfacesLogicaAplicacion
{
    public interface ICUDelete<T>
    {
        void Execute(int id);
    }
}
