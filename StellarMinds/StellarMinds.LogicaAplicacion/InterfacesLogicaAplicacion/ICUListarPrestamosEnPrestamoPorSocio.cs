using StellarMinds.LogicaAplicacion.Dtos.PrestamoDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace StellarMinds.LogicaAplicacion.InterfacesLogicaAplicacion
{
    public interface ICUListarPrestamosEnPrestamoPorSocio<T>
    {
        IEnumerable<T> Execute(int socioId);
    }
}
